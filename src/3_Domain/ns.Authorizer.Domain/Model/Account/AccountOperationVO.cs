using Newtonsoft.Json;
using ns.Authorizer.Domain.Model.Transaction;
using ns.Authorizer.Domain.Violations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ns.Authorizer.Domain.Model.Account
{
    public partial class AccountOperationVO
    {
        public const string Schema = @"{
  ""$schema"": ""http://json-schema.org/draft-04/schema#"",
  ""type"": ""object"",
  ""properties"": {
    ""account"": {
      ""type"": ""object"",
      ""properties"": {
        ""active-card"": {
          ""type"": ""boolean""
        },
        ""available-limit"": {
          ""type"": ""integer""
        }
      },
      ""required"": [
        ""active-card"",
        ""available-limit""
      ]
    }
  },
  ""required"": [
    ""account""
  ]
}";

        public AccountOperationVO(AccountDetails account = null)
        {
            Account = account == null ? new AccountDetails() : account;

            Violations = new List<string>();
        }

        [JsonProperty(PropertyName = "account")]
        public AccountDetails Account { get; private set; }

        [JsonProperty(PropertyName = "violations")]
        public List<string> Violations { get; private set; }

        public void AddViolation(IViolation violation)
        {
            Violations.Add(violation.Message());
        }

        public bool HasViolations()
        {
            return Violations.Any();
        }

        public bool HasTransactionViolations(TransactionDetails transactionDetails, List<TransactionDetails> lastTransactions)
        {
            bool hasTransactionViolations = WillBurstLimit(transactionDetails.Amount);
            hasTransactionViolations = WillViolateFrequencyExecution(transactionDetails, lastTransactions) || hasTransactionViolations;
            hasTransactionViolations = WillDoubleTransaction(transactionDetails, lastTransactions) || hasTransactionViolations;

            return hasTransactionViolations;
        }

        private bool WillBurstLimit(long amount)
        {
            if (Account.AvailableLimit < amount)
            {
                AddViolation(new InsufficientLimit());
                return true;
            }

            return false;
        }

        private bool WillViolateFrequencyExecution(TransactionDetails transactionDetails, List<TransactionDetails> lastTransactions)
        {
            IEnumerable<TransactionDetails> filteredTransactions = DefaultFilterTransactions(transactionDetails.Time, lastTransactions);

            if (filteredTransactions.Count() < 3)
                return false;

            AddViolation(new HighFrequencySmallInterval());
            return true;
        }

        private bool WillDoubleTransaction(TransactionDetails transactionDetails, List<TransactionDetails> lastTransactions)
        {
            IEnumerable<TransactionDetails> filteredTransactions = DefaultFilterTransactions(transactionDetails.Time, lastTransactions);

            if (filteredTransactions.Any(t => t.Amount == transactionDetails.Amount && t.Merchant == transactionDetails.Merchant))
            {
                AddViolation(new DoubledTransaction());
                return true;
            }

            return false;
        }

        private IEnumerable<TransactionDetails> DefaultFilterTransactions(DateTime transactionDateTime, List<TransactionDetails> lastTransactions)
        {
            return lastTransactions.Where(lt => lt.Time > transactionDateTime.AddMinutes(-2));
        }

        public bool IsCardInactive()
        {
            if (Account.ActiveCard != null && Account.ActiveCard == true)
                return false;

            AddViolation(new CardNotActive());
            return true;
        }

        public void ExecuteTransaction(long value)
        {
            Account.SubtractLimit(value);
        }
    }

    public class AccountDetails
    {
        public AccountDetails()
        {

        }

        public AccountDetails(bool? activeCard, long? availableLimit)
        {
            ActiveCard = activeCard;
            AvailableLimit = availableLimit;
        }

        [JsonProperty(PropertyName = "active-card", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ActiveCard { get; private set; }

        [JsonProperty(PropertyName = "available-limit", NullValueHandling = NullValueHandling.Ignore)]
        public long? AvailableLimit { get; private set; }

        internal void SubtractLimit(long value)
        {
            AvailableLimit = AvailableLimit - value;
        }
    }
}

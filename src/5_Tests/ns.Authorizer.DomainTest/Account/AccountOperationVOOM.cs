using Newtonsoft.Json;
using ns.Authorizer.Domain.Model.Account;
using ns.Authorizer.Domain.Model.Transaction;
using ns.Authorizer.Domain.Violations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ns.Authorizer.DomainTest.Account
{
    public class AccountOperationVOOM
    {
        private static readonly IViolation[] _violations = 
        {
            new AccountNotInitialized(),
            new CardNotActive(),
            new DoubledTransaction(),
            new HighFrequencySmallInterval(),
            new InsufficientLimit()
        };

        public static IViolation[] GetViolations(int violationsQuantity)
        {
            return _violations.Take(violationsQuantity).ToArray();
        }

        public static AccountOperationVO CreateAccountOperation(bool? activeCard = null, long? availableLimit = null)
        {
            AccountDetails accountDetails = new AccountDetails(activeCard, availableLimit);

            return new AccountOperationVO(accountDetails);
        }

        public static List<TransactionDetails> LastTransactions_NoViolations()
        {
            const string lastTransactionsJson =
@"[{""merchant"":""Vivara"",""amount"":1250,""time"":""2019-02-13T11:00:00.000Z""},
{""merchant"":""Samsung"",""amount"":2500,""time"":""2019-02-14T11:00:01.000Z""},
{""merchant"":""Nike"",""amount"":800,""time"":""2019-02-15T11:01:01.000Z""},
{""merchant"":""Uber"",""amount"":80,""time"":""2019-02-16T11:01:31.000Z""}]";

            return JsonConvert.DeserializeObject<List<TransactionDetails>>(lastTransactionsJson);
        }

        public static TransactionDetails TransactionDetails_NoViolations()
        {
            const string transactionDetailJson = @"{""merchant"":""Vivara"",""amount"":1250,""time"":""2019-02-17T11:00:00.000Z""}";

            return JsonConvert.DeserializeObject<TransactionDetails>(transactionDetailJson);
        }

        public static List<TransactionDetails> LastTransactions_HasViolations()
        {
            const string lastTransactionsJson =
@"[{""merchant"":""Vivara"",""amount"":1250,""time"":""2019-02-13T11:00:00.000Z""},
{""merchant"":""Samsung"",""amount"":2500,""time"":""2019-02-13T11:00:01.000Z""},
{""merchant"":""Nike"",""amount"":800,""time"":""2019-02-13T11:01:01.000Z""},
{""merchant"":""Uber"",""amount"":80,""time"":""2019-02-13T11:01:31.000Z""}]";

            return JsonConvert.DeserializeObject<List<TransactionDetails>>(lastTransactionsJson);
        }

        public static TransactionDetails TransactionDetails_HasViolations()
        {
            const string transactionDetailJson = @"{""merchant"":""Vivara"",""amount"":1300,""time"":""2019-02-13T11:00:00.000Z""}";

            return JsonConvert.DeserializeObject<TransactionDetails>(transactionDetailJson);
        }
    }
}

using Newtonsoft.Json;
using ns.Authorizer.Application.Account;
using ns.Authorizer.Application.Transaction;
using ns.Authorizer.Domain.Model.Account;
using ns.Authorizer.Domain.Model.Transaction;
using ns.Authorizer.JsonLib;
using ns.Authorizer.ResultLib;
using System.IO;
using System.Text;

namespace ns.Authorizer.Application.Service
{
    internal class ServiceAuthorizerOperationsImpl : IServiceAuthorizerOperations
    {
        IAccountOperator _accountOperator;
        ITransactionOperator _transactionOperator;

        public ServiceAuthorizerOperationsImpl(IAccountOperator accountOperator, ITransactionOperator transactionOperator)
        {
            _accountOperator = accountOperator;
            _transactionOperator = transactionOperator;
        }

        public string Execute(string operationsJson)
        {
            StringBuilder responseBuilder = new StringBuilder();

            StringReader reader = new StringReader(operationsJson);

            string line;

            while ((line = reader.ReadLine()) != null)
            {
                string lineResult = ProcessLine(line);
                responseBuilder.AppendLine(lineResult);
            }

            return responseBuilder.ToString().Trim();
        }

        private string ProcessLine(string line)
        {
            Result<AccountOperationVO> accountCreationResult = JsonHelper<AccountOperationVO>.CreateObject(line, AccountOperationVO.Schema);

            if (accountCreationResult.IsSuccess)
            {
                AccountOperationVO accountOperation = _accountOperator.Execute(accountCreationResult.ValueObject);

                return JsonConvert.SerializeObject(accountOperation);
            }

            Result<TransactionOperationVO> transactionCreationResult = JsonHelper<TransactionOperationVO>.CreateObject(line, TransactionOperationVO.Schema);

            if (transactionCreationResult.IsSuccess)
            {
                AccountOperationVO accountOperation = _transactionOperator.Execute(transactionCreationResult.ValueObject);

                return JsonConvert.SerializeObject(accountOperation);
            }

            return null;
        }
    }
}

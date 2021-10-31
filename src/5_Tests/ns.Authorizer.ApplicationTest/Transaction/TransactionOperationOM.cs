namespace ns.Authorizer.ApplicationTest.Transaction
{
    public class TransactionOperationOM
    {
        public const string ExecuteTransactionWithSuccess_Input =
@"{""account"":{""active-card"":true,""available-limit"":100}}
{""transaction"":{""merchant"":""Burger King"",""amount"":20,""time"":""2019-02-13T11:00:00.000Z""}}";

        public const string ExecuteTransactionWithSuccess_Output =
@"{""account"":{""active-card"":true,""available-limit"":100},""violations"":[]}
{""account"":{""active-card"":true,""available-limit"":80},""violations"":[]}";

        public const string ExecuteTransactionWithAccountNotInitialized_Input =
@"{""transaction"":{""merchant"":""Uber Eats"",""amount"":25,""time"":""2020-12-01T11:07:00.000Z""}}
{""account"":{""active-card"":true,""available-limit"":225}}
{""transaction"":{""merchant"":""Uber Eats"",""amount"":25,""time"":""2020-12-01T11:07:00.000Z""}}";

        public const string ExecuteTransactionWithAccountNotInitialized_Output =
@"{""account"":{},""violations"":[""account-not-initialized""]}
{""account"":{""active-card"":true,""available-limit"":225},""violations"":[]}
{""account"":{""active-card"":true,""available-limit"":200},""violations"":[]}";

        public const string ExecuteTransactionWithCardNotActive_Input =
@"{""account"":{""active-card"":false,""available-limit"":100}}
{""transaction"":{""merchant"":""Burger King"",""amount"":20,""time"":""2019-02-13T11:00:00.000Z""}}
{""transaction"":{""merchant"":""Habbib's"",""amount"":15,""time"":""2019-02-13T11:15:00.000Z""}}";

        public const string ExecuteTransactionWithCardNotActive_Output =
@"{""account"":{""active-card"":false,""available-limit"":100},""violations"":[]}
{""account"":{""active-card"":false,""available-limit"":100},""violations"":[""card-not-active""]}
{""account"":{""active-card"":false,""available-limit"":100},""violations"":[""card-not-active""]}";

        public const string ExecuteTransactionWithInsufficientLimit_Input =
@"{""account"":{""active-card"":true,""available-limit"":1000}}
{""transaction"":{""merchant"":""Vivara"",""amount"":1250,""time"":""2019-02-13T11:00:00.000Z""}}
{""transaction"":{""merchant"":""Samsung"",""amount"":2500,""time"":""2019-02-13T11:00:01.000Z""}}
{""transaction"":{""merchant"":""Nike"",""amount"":800,""time"":""2019-02-13T11:01:01.000Z""}}";

        public const string ExecuteTransactionWithInsufficientLimit_Output =
@"{""account"":{""active-card"":true,""available-limit"":1000},""violations"":[]}
{""account"":{""active-card"":true,""available-limit"":1000},""violations"":[""insufficient-limit""]}
{""account"":{""active-card"":true,""available-limit"":1000},""violations"":[""insufficient-limit""]}
{""account"":{""active-card"":true,""available-limit"":200},""violations"":[]}";

        public const string ExecuteTransactionWithHighFrequencySmallInterval_Input =
@"{""account"":{""active-card"":true,""available-limit"":100}}
{""transaction"":{""merchant"":""Burger King"",""amount"":20,""time"":""2019-02-13T11:00:00.000Z""}}
{""transaction"":{""merchant"":""Habbib's"",""amount"":20,""time"":""2019-02-13T11:00:01.000Z""}}
{""transaction"":{""merchant"":""McDonald's"",""amount"":20,""time"":""2019-02-13T11:01:01.000Z""}}
{""transaction"":{""merchant"":""Subway"",""amount"":10,""time"":""2019-02-13T11:01:31.000Z""}}
{""transaction"":{""merchant"":""Burger King"",""amount"":10,""time"":""2019-02-13T12:00:00.000Z""}}";

        public const string ExecuteTransactionWithHighFrequencySmallInterval_Output =
@"{""account"":{""active-card"":true,""available-limit"":100},""violations"":[]}
{""account"":{""active-card"":true,""available-limit"":80},""violations"":[]}
{""account"":{""active-card"":true,""available-limit"":60},""violations"":[]}
{""account"":{""active-card"":true,""available-limit"":40},""violations"":[]}
{""account"":{""active-card"":true,""available-limit"":40},""violations"":[""high-frequency-small-interval""]}
{""account"":{""active-card"":true,""available-limit"":30},""violations"":[]}";

        public const string ExecuteTransactionWithDoubledTransaction_Input =
@"{""account"":{""active-card"":true,""available-limit"":100}}
{""transaction"":{""merchant"":""Burger King"",""amount"":20,""time"":""2019-02-13T11:00:00.000Z""}}
{""transaction"":{""merchant"":""McDonald's"",""amount"":10,""time"":""2019-02-13T11:00:01.000Z""}}
{""transaction"":{""merchant"":""Burger King"",""amount"":20,""time"":""2019-02-13T11:00:02.000Z""}}
{""transaction"":{""merchant"":""Burger King"",""amount"":15,""time"":""2019-02-13T11:00:03.000Z""}}";

        public const string ExecuteTransactionWithDoubledTransaction_Output =
@"{""account"":{""active-card"":true,""available-limit"":100},""violations"":[]}
{""account"":{""active-card"":true,""available-limit"":80},""violations"":[]}
{""account"":{""active-card"":true,""available-limit"":70},""violations"":[]}
{""account"":{""active-card"":true,""available-limit"":70},""violations"":[""doubled-transaction""]}
{""account"":{""active-card"":true,""available-limit"":55},""violations"":[]}";

        public const string ExecuteTransactionWithMultipleViolations_Input =
@"{""account"":{""active-card"":true,""available-limit"":100}}
{""transaction"":{""merchant"":""McDonald's"",""amount"":10,""time"":""2019-02-13T11:00:01.000Z""}}
{""transaction"":{""merchant"":""Burger King"",""amount"":20,""time"":""2019-02-13T11:00:02.000Z""}}
{""transaction"":{""merchant"":""Burger King"",""amount"":5,""time"":""2019-02-13T11:00:07.000Z""}}
{""transaction"":{""merchant"":""Burger King"",""amount"":5,""time"":""2019-02-13T11:00:08.000Z""}}
{""transaction"":{""merchant"":""Burger King"",""amount"":150,""time"":""2019-02-13T11:00:18.000Z""}}
{""transaction"":{""merchant"":""Burger King"",""amount"":190,""time"":""2019-02-13T11:00:22.000Z""}}
{""transaction"":{""merchant"":""Burger King"",""amount"":15,""time"":""2019-02-13T12:00:27.000Z""}}";

        public const string ExecuteTransactionWithMultipleViolations_Output =
@"{""account"":{""active-card"":true,""available-limit"":100},""violations"":[]}
{""account"":{""active-card"":true,""available-limit"":90},""violations"":[]}
{""account"":{""active-card"":true,""available-limit"":70},""violations"":[]}
{""account"":{""active-card"":true,""available-limit"":65},""violations"":[]}
{""account"":{""active-card"":true,""available-limit"":65},""violations"":[""high-frequency-small-interval"",""doubled-transaction""]}
{""account"":{""active-card"":true,""available-limit"":65},""violations"":[""insufficient-limit"",""high-frequency-small-interval""]}
{""account"":{""active-card"":true,""available-limit"":65},""violations"":[""insufficient-limit"",""high-frequency-small-interval""]}
{""account"":{""active-card"":true,""available-limit"":50},""violations"":[]}";

        public const string ExecuteTransactionViolationsShouldNotBeStored_Input =
@"{""account"":{""active-card"":true,""available-limit"":1000}}
{""transaction"":{""merchant"":""Vivara"",""amount"":1250,""time"":""2019-02-13T11:00:00.000Z""}}
{""transaction"":{""merchant"":""Samsung"",""amount"":2500,""time"":""2019-02-13T11:00:01.000Z""}}
{""transaction"":{""merchant"":""Nike"",""amount"":800,""time"":""2019-02-13T11:01:01.000Z""}}
{""transaction"":{""merchant"":""Uber"",""amount"":80,""time"":""2019-02-13T11:01:31.000Z""}}";

        public const string ExecuteTransactionViolationsShouldNotBeStored_Output =
@"{""account"":{""active-card"":true,""available-limit"":1000},""violations"":[]}
{""account"":{""active-card"":true,""available-limit"":1000},""violations"":[""insufficient-limit""]}
{""account"":{""active-card"":true,""available-limit"":1000},""violations"":[""insufficient-limit""]}
{""account"":{""active-card"":true,""available-limit"":200},""violations"":[]}
{""account"":{""active-card"":true,""available-limit"":120},""violations"":[]}";

    }
}
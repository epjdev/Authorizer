namespace ns.Authorizer.ApplicationTest.Account
{
    public class AccountOperationOM
    {
        public const string CreateAccountWithSuccess_Input =
@"{""account"":{""active-card"":false,""available-limit"":750}}";

        public const string CreateAccountWithSuccess_Output =
@"{""account"":{""active-card"":false,""available-limit"":750},""violations"":[]}";

        public const string CreateAccountWithAccountAlreadyInitialized_Input =
@"{""account"":{""active-card"":true,""available-limit"":175}}
{""account"":{""active-card"":true,""available-limit"":350}}";

        public const string CreateAccountWithAccountAlreadyInitialized_Output =
@"{""account"":{""active-card"":true,""available-limit"":175},""violations"":[]}
{""account"":{""active-card"":true,""available-limit"":175},""violations"":[""account-already-initialized""]}";
    }
}

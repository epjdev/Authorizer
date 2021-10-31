namespace ns.Authorizer.Domain.Violations
{
    public class AccountAlreadyInitialized : IViolation
    {
        public string Message() => "account-already-initialized";
    }
}

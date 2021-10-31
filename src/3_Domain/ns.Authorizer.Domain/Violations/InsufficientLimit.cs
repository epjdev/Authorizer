namespace ns.Authorizer.Domain.Violations
{
    public class InsufficientLimit : IViolation
    {
        public string Message() => "insufficient-limit";
    }
}

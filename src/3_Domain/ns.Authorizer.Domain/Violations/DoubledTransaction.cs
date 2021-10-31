namespace ns.Authorizer.Domain.Violations
{
    public class DoubledTransaction : IViolation
    {
        public string Message() => "doubled-transaction";
    }
}

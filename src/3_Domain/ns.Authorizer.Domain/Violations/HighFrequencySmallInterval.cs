namespace ns.Authorizer.Domain.Violations
{
    public class HighFrequencySmallInterval : IViolation
    {
        public string Message() => "high-frequency-small-interval";
    }
}

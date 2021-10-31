namespace ns.Authorizer.Domain.Violations
{
    public class CardNotActive : IViolation
    {
        public string Message() => "card-not-active";
    }
}

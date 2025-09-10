namespace STANWEBAPI.DOMAIN.Entities
{
    public class Policy
    {
        public Policy(
            Guid policyId,
            string policyNumber
        )
        {
            PolicyId = policyId;
            PolicyNumber = policyNumber;
        }

        public Guid PolicyId { get; internal set; }
        public string PolicyNumber { get; internal set; }
    }
}
using System.Runtime.Serialization;

namespace Enterprise.Service.Shared.Contracts.FaultContracts
{
    public class IdFault
    {
        [DataMember]
        public string Operation { get; set; }

        [DataMember]
        public string ProblemType { get; set; }
    }
}
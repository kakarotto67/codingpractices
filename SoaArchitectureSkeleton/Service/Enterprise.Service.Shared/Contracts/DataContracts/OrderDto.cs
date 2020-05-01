using System;
using System.Runtime.Serialization;

namespace Enterprise.Service.Shared.Contracts.DataContracts
{
    [DataContract]
    public class OrderDto
    {
        [DataMember]
        public Int32 OrderID { get; set; }
        [DataMember]
        public String CustomerID { get; set; }
        [DataMember]
        public Int32? EmployeeID { get; set; }
    }
}
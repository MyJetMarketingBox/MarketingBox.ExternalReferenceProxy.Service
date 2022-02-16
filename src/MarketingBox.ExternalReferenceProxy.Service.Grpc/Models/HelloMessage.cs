using System.Runtime.Serialization;
using MarketingBox.ExternalReferenceProxy.Service.Domain.Models;

namespace MarketingBox.ExternalReferenceProxy.Service.Grpc.Models
{
    [DataContract]
    public class HelloMessage : IHelloMessage
    {
        [DataMember(Order = 1)]
        public string Message { get; set; }
    }
}
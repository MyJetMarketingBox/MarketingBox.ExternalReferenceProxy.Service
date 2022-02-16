using System.Runtime.Serialization;

namespace MarketingBox.ExternalReferenceProxy.Service.Grpc.Models
{
    [DataContract]
    public class GetProxyRefResponse
    {
        [DataMember(Order = 1)] public bool Success { get; set; }
        [DataMember(Order = 2)] public string ErrorMessage { get; set; }
        [DataMember(Order = 3)] public string ProxyLink { get; set; }
    }
}
using System.Runtime.Serialization;

namespace MarketingBox.ExternalReferenceProxy.Service.Grpc.Models
{
    [DataContract]
    public class GetProxyRefRequest
    {
        [DataMember(Order = 1)] public string BrandLink { get; set; }
        [DataMember(Order = 2)] public long RegistrationId { get; set; }
        [DataMember(Order = 3)] public string RegistrationUId { get; set; }
        [DataMember(Order = 4)] public string TenantId { get; set; }
    }
}
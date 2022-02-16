using System;

namespace MarketingBox.ExternalReferenceProxy.Service.Domain.Models
{
    public class RegistrationProxyEntity
    {
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string ProxyLink { get; set; }
        public string BrandLink { get; set; }
        public long RegistrationId { get; set; }
        public string RegistrationUId { get; set; }
        public string TenantId { get; set; }
    }
}
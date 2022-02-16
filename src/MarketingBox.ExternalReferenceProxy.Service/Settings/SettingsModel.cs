using MyJetWallet.Sdk.Service;
using MyYamlParser;

namespace MarketingBox.ExternalReferenceProxy.Service.Settings
{
    public class SettingsModel
    {
        [YamlProperty("ExternalReferenceProxyService.SeqServiceUrl")]
        public string SeqServiceUrl { get; set; }

        [YamlProperty("ExternalReferenceProxyService.ZipkinUrl")]
        public string ZipkinUrl { get; set; }

        [YamlProperty("ExternalReferenceProxyService.ElkLogs")]
        public LogElkSettings ElkLogs { get; set; }
        
        [YamlProperty("ExternalReferenceProxyService.ExternalReferenceProxyApiUrl")]
        public string ExternalReferenceProxyApiUrl { get; set; }

        [YamlProperty("ExternalReferenceProxyService.ExternalReferenceProxyApiUrlPath")]
        public string ExternalReferenceProxyApiUrlPath { get; set; }

        [YamlProperty("ExternalReferenceProxyService.ProxyLinkLifetimeInHours")]
        public int ProxyLinkLifetimeInHours { get; set; }

        [YamlProperty("ExternalReferenceProxyService.MyNoSqlWriterUrl")]
        public string MyNoSqlWriterUrl { get; set; }
    }
}

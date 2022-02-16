using MyJetWallet.Sdk.Service;
using MyYamlParser;

namespace MarketingBox.ExternalReferenceProxy.Service.Settings
{
    public class SettingsModel
    {
        [YamlProperty("ExternalReferenceProxy.Service.SeqServiceUrl")]
        public string SeqServiceUrl { get; set; }

        [YamlProperty("ExternalReferenceProxy.Service.ZipkinUrl")]
        public string ZipkinUrl { get; set; }

        [YamlProperty("ExternalReferenceProxy.Service.ElkLogs")]
        public LogElkSettings ElkLogs { get; set; }
    }
}

using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using MarketingBox.ExternalReferenceProxy.Service.Domain.Models;
using MarketingBox.ExternalReferenceProxy.Service.Engine;
using MyJetWallet.Sdk.NoSql;

namespace MarketingBox.ExternalReferenceProxy.Service.Modules
{
    public class ServiceModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterMyNoSqlWriter<RegistrationProxyEntityNoSql>(Program.ReloadedSettings(e => e.MyNoSqlWriterUrl), 
                RegistrationProxyEntityNoSql.TableName);

            builder
                .RegisterType<ExternalReferenceProxyEngine>()
                .AsSelf()
                .SingleInstance();
        }
    }
}
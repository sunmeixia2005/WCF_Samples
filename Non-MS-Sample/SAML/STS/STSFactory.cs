using STS.Const;
using System;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.Web.Configuration;

namespace STS
{
    public class STSFactory : ServiceHostFactory
    {
        private static Binding STSBinding
        {
            get
            {
                return new WS2007HttpBinding("STS-WS2007HttpBinding");
            }
        }

        public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
        {
            string issuerName = WebConfigurationManager.AppSettings[Common.IssuerName];
            string signingCertificateThumprint = WebConfigurationManager.AppSettings[Common.SigningCertificateThumbprint];
            string issuerCertificateThumprint = WebConfigurationManager.AppSettings[Common.IssuerCertificateThumprint];
            var config = new STSConfiguration(issuerName, signingCertificateThumprint, issuerCertificateThumprint);

            Uri baseUri = baseAddresses.FirstOrDefault(a => a.Scheme == Uri.UriSchemeHttps);

            if (baseUri == null)
            {
                throw new InvalidOperationException("The STS should be hosted under https.");
            }

            WSTrustServiceHost host = new WSTrustServiceHost(config, baseAddresses);
            host.AddServiceEndpoint(typeof(IWSTrust13SyncContract), STSBinding, baseUri.AbsoluteUri);
            return host;
        }
    }
}
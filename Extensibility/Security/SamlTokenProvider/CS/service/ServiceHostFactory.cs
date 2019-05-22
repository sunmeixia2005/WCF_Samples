using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Security;
using System.Text;

namespace Microsoft.Samples.SamlTokenProvider
{
    public class ServiceHostFactory : ServiceHostFactoryBase
    {
        public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
        {
            var host = new CalcServiceHost(baseAddresses);
            
            return host;
        }
    }

    public class CalcServiceHost : ServiceHost
    {
        #region BookStoreServiceHost Constructor
        /// <summary>
        /// Sets up the BookStoreService by loading relevant Application Settings
        /// </summary>
        public CalcServiceHost(params Uri[] addresses) : base(typeof(CalculatorService), addresses)
        {
            
            // Setting the certificateValidationMode to PeerOrChainTrust means that if the certificate 
            // is in the Trusted People store, then it will be trusted without performing a
            // validation of the certificate's issuer chain. This setting is used here for convenience 
            // so that the sample can be run without having to have certificates issued by a certificate 
            // authority (CA). This setting is less secure than the default, ChainTrust. The security 
            // implications of this setting should be carefully considered before using PeerOrChainTrust 
            // in production code. 
            this.Credentials.IssuedTokenAuthentication.CertificateValidationMode = X509CertificateValidationMode.PeerOrChainTrust;
        }
        #endregion
    }
}

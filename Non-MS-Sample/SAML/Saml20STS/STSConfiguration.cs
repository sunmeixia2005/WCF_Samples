using Saml20STS.Const;
using Saml20STS.Handlers;
using Saml20STS.Utils;
using System.IdentityModel.Configuration;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web.Configuration;

namespace Saml20STS
{
    public class STSConfiguration : SecurityTokenServiceConfiguration
    {  /// <summary>
        /// Initializes a new instance of the CustomSecurityTokenServiceConfiguration class.
        /// </summary>
        public STSConfiguration()
            : base(WebConfigurationManager.AppSettings[Common.IssuerName],
                new X509SigningCredentials(CertificateUtil.GetCertificateByThumbprint(
                    StoreName.My, StoreLocation.LocalMachine,
                    WebConfigurationManager.AppSettings[Common.SigningCertificateThumbprint])))
        {
            Init(WebConfigurationManager.AppSettings[Common.IssuerCertificateThumprint]);
        }

        /// <summary>
        /// Initializes a new instance of the GenesisSecurityTokenServiceConfiguration class.
        /// </summary>
        /// <param name="piIssuerName">Issuer name.</param>
        /// <param name="piSigningCertificateThumprint">Signing Certificate thumbprint.</param>
        /// <param name="piIssuerCertificateThumbprint">Issuer Certificate thumbprint.</param>
        public STSConfiguration(string piIssuerName, string piSigningCertificateThumprint, string piIssuerCertificateThumbprint)
            : base(piIssuerName, new X509SigningCredentials(CertificateUtil.GetCertificateByThumbprint(
                    StoreName.My, StoreLocation.LocalMachine, piSigningCertificateThumprint)))
        {
            Init(piSigningCertificateThumprint);
        }

        #region Private Methods

        /// <summary>
        /// Method responsible for initializing Security Token Service Configuration.
        /// </summary>
        private void Init(string piIssuerCertificateThumbprint)
        {
            var uh = new STSUserNameHandler();
            SecurityTokenService = typeof(STSService);
            uh.Configuration = new SecurityTokenHandlerConfiguration();
            uh.Configuration.AudienceRestriction = new System.IdentityModel.Tokens.AudienceRestriction();
            uh.Configuration.AudienceRestriction.AudienceMode = AudienceUriMode.Never;
            uh.Configuration.SaveBootstrapContext = true;
            uh.Configuration.IssuerNameRegistry = new STSIssuerNameRegistry(piIssuerCertificateThumbprint);
            SecurityTokenHandlers.AddOrReplace(uh);
        }
        #endregion Private Methods
    }
}
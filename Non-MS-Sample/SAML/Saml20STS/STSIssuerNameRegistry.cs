using System;
using System.IdentityModel.Tokens;

namespace Saml20STS
{
    public class STSIssuerNameRegistry : IssuerNameRegistry
    {
        #region Private Variables

        /// <summary>
        /// Isseuer Certifacte Thumbprint.
        /// </summary>
        private string issuerThumprint;

        #endregion Private Variables

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the GenesisIssuerNameRegistry class.
        /// </summary>
        /// <param name="issuerThumbPrint">issuerThumbPrint</param>
        public STSIssuerNameRegistry(string issuerThumbPrint)
        {
            issuerThumprint = issuerThumbPrint;
        }

        #endregion Constructors

        /// <summary>
        /// Overrides the base class. Validates the given issuer token. For a incoming SAML token
        /// the issuer token is the Certificate that signed the SAML token.
        /// </summary>
        /// <param name="securityToken">Issuer token to be validated.</param>
        /// <returns>Friendly name representing the Issuer.</returns>
        public override string GetIssuerName(SecurityToken securityToken)
        {
            X509SecurityToken x509Token = securityToken as X509SecurityToken;

            if (x509Token != null)
            {
                if (string.Equals(x509Token.Certificate.Thumbprint, issuerThumprint, StringComparison.InvariantCultureIgnoreCase))
                {
                    return x509Token.Certificate.SubjectName.Name;
                }
            }

            throw new SecurityTokenException("Untrusted issuer.");
        }
    }
}
using STS.Const;
using STS.Utils;
using System;
using System.IdentityModel;
using System.IdentityModel.Configuration;
using System.IdentityModel.Protocols.WSTrust;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Web.Configuration;

namespace STS
{
    public class STSService : SecurityTokenService
    {
        /// <summary>
        /// Name of claim idenity
        /// </summary>
        private const string ClaimIdentityName = "STS-Demo-Federation";

        /// <summary>
        /// Holds signing credentials.
        /// </summary>
        private readonly SigningCredentials _signingCreds;

        /// <summary>
        /// Holds encrypting credentials.
        /// </summary>
        private readonly EncryptingCredentials _encryptingCreds;

        /// <summary>
        /// Initializes a new instance of the GenesisSecurityTokenService class.
        /// </summary>
        /// <param name="configuration">Configuration for the service.</param>
        public STSService(SecurityTokenServiceConfiguration configuration)
            : base(configuration)
        {
            _signingCreds = new X509SigningCredentials(
                CertificateUtil.GetCertificateByThumbprint(StoreName.My, StoreLocation.LocalMachine, WebConfigurationManager.AppSettings[Common.SigningCertificateThumbprint]));

            if (!string.IsNullOrWhiteSpace(WebConfigurationManager.AppSettings[Common.EncryptingCertificateName]))
            {
                _encryptingCreds = new X509EncryptingCredentials(
                    CertificateUtil.GetCertificateByThumbprint(StoreName.My, StoreLocation.LocalMachine, WebConfigurationManager.AppSettings[Common.EncryptingCertificateName]));
            }
        }

        

        /// <summary>
        /// Logic for obtaining token lifetime.
        /// </summary>
        /// <param name="requestLifetime">A Lifetime that represents the requested lifetime. Not used here.</param>
        /// <returns>Granted lifetime.</returns>
        protected override Lifetime GetTokenLifetime(Lifetime requestLifetime)
        {
            if (requestLifetime != null)
            {
                return requestLifetime;
            }
            var lifeTime = new Lifetime(DateTime.Now, DateTime.Now.AddMinutes(30));
            return lifeTime;
        }

        /// <summary>
        /// This methods returns the configuration for the token issuance request. The configuration
        /// is represented by the Scope class. In our case, we are only capable to issue a token for a
        /// single RP identity represented by CN=localhost.
        /// </summary>
        /// <param name="principal">The caller's principal.</param>
        /// <param name="request">The incoming RST.</param>
        /// <returns>A Scope that encapsulates the RP information associated with the request. </returns>
        protected override Scope GetScope(ClaimsPrincipal principal, RequestSecurityToken request)
        {
            /// Create the scope using the request AppliesTo address and the STS signing certificate
            Scope scope = new Scope(request.AppliesTo.Uri.ToString(), _signingCreds);

            //IssuedToken.MaxIssuedTokenCachingTime
            // We only support a single RP identity represented by CN=localhost. Set the RP certificate for encryption
            if (_encryptingCreds != null)
            {
                // If you have multiple RPs for the STS you would select the certificate that is specific to
                // the RP that requests the token and then use that for encryptingCreds
                scope.EncryptingCredentials = _encryptingCreds;
            }
            else
            {
                scope.TokenEncryptionRequired = false;
            }

            if (Uri.IsWellFormedUriString(request.ReplyTo, UriKind.Absolute))
            {
                if (request.AppliesTo.Uri.Host != new Uri(request.ReplyTo).Host)
                    scope.ReplyToAddress = request.AppliesTo.Uri.AbsoluteUri;
                else
                    scope.ReplyToAddress = request.ReplyTo;
            }
            else
            {
                Uri resultUri = null;

                if (Uri.TryCreate(request.AppliesTo.Uri, request.ReplyTo, out resultUri))
                    scope.ReplyToAddress = resultUri.AbsoluteUri;
                else
                    scope.ReplyToAddress = request.AppliesTo.Uri.ToString();
            }

            return scope;
        }

        /// <summary>
        /// This method returns the content of the issued token. The content is represented as a set of
        /// ClaimIdentity intances, each instance corresponds to a single issued token.
        /// </summary>
        /// <param name="scope">The scope that was previously returned by GetScope method.</param>
        /// <param name="principal">The caller's principal.</param>
        /// <param name="request">The incoming RST.</param>
        /// <returns></returns>
        protected override ClaimsIdentity GetOutputClaimsIdentity(ClaimsPrincipal principal, RequestSecurityToken request, Scope scope)
        {
            ClaimsIdentity callerIdentity = principal.Identities.First();
            ClaimsIdentity outputIdentity = new ClaimsIdentity(ClaimIdentityName);
            CopyClaims(callerIdentity, outputIdentity);

            return outputIdentity;
        }

        /// <summary>
        /// Do a deep-copy of ClaimsIdentity except the issuer.
        /// </summary>
        /// <param name="srcIdentity">Source Identity.</param>
        /// <param name="dstIdentity">Destination Identity.</param>
        private static void CopyClaims(ClaimsIdentity srcIdentity, ClaimsIdentity dstIdentity)
        {
            foreach (Claim claim in srcIdentity.Claims)
            {
                // We don't copy the issuer because it is not needed in this case.
                // The STS always issues claims using its own identity.
                Claim newClaim = new Claim(claim.Type, claim.Value, claim.ValueType);

                // Copy all claim properties
                foreach (string key in claim.Properties.Keys)
                {
                    newClaim.Properties.Add(key, claim.Properties[key]);
                }

                // Add claim to the destination identity
                dstIdentity.AddClaim(newClaim);
            }

            // Recursively copy claims from the source identity delegates
            if (srcIdentity.Actor != null)
            {
                dstIdentity.Actor = new ClaimsIdentity();
                CopyClaims(srcIdentity.Actor, dstIdentity.Actor);
            }
        }

        /// <summary>
        /// Creates new Security Token Descriptor.
        /// </summary>
        /// <param name="request">The incoming token request.</param>
        /// <param name="scope">The Scope object returned from GetScope.</param>
        /// <returns>New security token descriptor.</returns>
        protected override SecurityTokenDescriptor CreateSecurityTokenDescriptor(RequestSecurityToken request, Scope scope)
        {
            return base.CreateSecurityTokenDescriptor(request, scope);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.ServiceModel;

namespace Saml20STS.Handlers
{
    public class STSUserNameHandler : UserNameSecurityTokenHandler
    {
        /// <summary>
        /// Gets value indicating whether tokens validation is supported.
        /// </summary>
        public override bool CanValidateToken
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets Type of token.
        /// </summary>
        public override Type TokenType
        {
            get { return typeof(UserNameSecurityToken); }
        }

        /// <summary>
        /// Get the TokenTypeIdentifier of the token that this handler can work with.
        /// </summary>
        /// <returns>TokenTypeIdentifier array.</returns>
        public override string[] GetTokenTypeIdentifiers()
        {
            return new string[]
			{
				SecurityTokenTypes.UserName
			};
        }

        /// <summary>
        /// Validates a token and returns its claims.
        /// </summary>
        /// <param name="token">Token to be validated.</param>
        /// <returns>Collection of claims.</returns>
        public override ReadOnlyCollection<System.Security.Claims.ClaimsIdentity> ValidateToken(SecurityToken token)
        {
            var userToken = token as UserNameSecurityToken;
            if(userToken == null)
            {
                throw new FaultException("Incorrect user name or password.");
            }
            ValidateUserCredentials(userToken);
            return new ReadOnlyCollection<ClaimsIdentity>(ExtractClaims(userToken));
        }
        private IList<System.Security.Claims.ClaimsIdentity> ExtractClaims(UserNameSecurityToken userToken)
        {
            const string Label = "UserIdentity";
            const string AdminUser = "Admin";
            const string SuperAdmin = "SuperAdmin";
            var email =  string.Format("{0}@{1}.org",userToken.UserName.ToLower(),Label.ToLower());
            ClaimsIdentity outgoingIdentity = new ClaimsIdentity(Label);
            outgoingIdentity.Label = Label;
            outgoingIdentity.AddClaim(new Claim(ClaimTypes.Name, userToken.UserName));
            outgoingIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, "Saml2.0-Demo"));
            outgoingIdentity.AddClaim(new Claim(ClaimTypes.Country, "US"));
            outgoingIdentity.AddClaim(new Claim(ClaimTypes.Email, email));
            if (userToken.UserName.Equals(SuperAdmin))
            {
                outgoingIdentity.AddClaim(new Claim(ClaimTypes.Role, SuperAdmin));
                outgoingIdentity.AddClaim(new Claim(ClaimTypes.Role, AdminUser));
            }
            if(userToken.UserName.Equals(AdminUser))
            {
                outgoingIdentity.AddClaim(new Claim(ClaimTypes.Role, AdminUser));
            }
            outgoingIdentity.AddClaim(new Claim(ClaimTypes.Role, "User"));
            var identityList = new List<ClaimsIdentity> { outgoingIdentity };

            return identityList;
        }

        private void ValidateUserCredentials(UserNameSecurityToken userToken)
        {

            if (!userToken.UserName.Equals(userToken.Password))
            {
                throw new FaultException("Incorrect user name or password.");
            }
        }

        public override SecurityToken CreateToken(SecurityTokenDescriptor tokenDescriptor)
        {
            return base.CreateToken(tokenDescriptor);
        }
    }
}
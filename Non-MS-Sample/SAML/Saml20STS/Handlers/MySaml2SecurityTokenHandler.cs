using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saml20STS.Handlers
{
    public class MySaml2SecurityTokenHandler : Saml2SecurityTokenHandler
    {
        public override bool CanWriteToken
        {
            get
            {
                return true;
            }
        }

        public override SecurityToken CreateToken(SecurityTokenDescriptor tokenDescriptor)
        {
            return base.CreateToken(tokenDescriptor);
        }
    }
}

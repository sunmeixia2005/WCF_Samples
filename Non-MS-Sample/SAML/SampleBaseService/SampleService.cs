using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SampleBaseService
{
    public abstract class SampleService
    {
        protected string ServiceName;

        protected virtual string GenerateResponse(string input)
        {
            var claimsPrincipal = OperationContext.Current.ClaimsPrincipal;
            var builder = new StringBuilder();
            builder.Append("Computed by Sample Service:").AppendLine(ServiceName);
            builder.AppendLine("Input received from client:" + input);

            if (claimsPrincipal != null)
            {
                var identity = claimsPrincipal.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    builder.AppendLine("Client Name:" + identity.Name);
                    builder.AppendLine("IsAuthenticated:" + identity.IsAuthenticated);
                }
                builder.AppendLine("The service received the following issued claims of the client:");

                foreach (var claim in claimsPrincipal.Claims)
                {
                    builder.AppendLine("ClaimType :" + claim.Type + "   ClaimValue:" + claim.Value);
                }
            }

            return builder.ToString();
        }
    }
}

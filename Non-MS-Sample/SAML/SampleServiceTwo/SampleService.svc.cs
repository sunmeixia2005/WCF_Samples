using System.ServiceModel;
using System.ServiceModel.Security;
using SampleBaseService;

namespace SampleServiceTwo
{
    public class SampleServiceTwo : SampleService, ISampleServiceTwo
    {
        public SampleServiceTwo()
        {
            ServiceName = "Service Two";
        }

        public string ComputeResponse(string input)
        {
            VerifyUserPermissions("User");
            return GenerateResponse(input);
        }

        public string ComputeResponseAdmin(string input)
        {
            VerifyUserPermissions("Admin");
            return GenerateResponse(input);
        }

        public string ComputeResponseSuperAdmin(string input)
        {
            VerifyUserPermissions("SuperAdmin");
            return GenerateResponse(input);
        }

        private void VerifyUserPermissions(string role)
        {
            var claimsPrincipal = OperationContext.Current.ClaimsPrincipal;
            if (!claimsPrincipal.Identity.IsAuthenticated || !claimsPrincipal.IsInRole(role))
            {
                throw new FaultException("Access denied.");
            }
        }
    }
}
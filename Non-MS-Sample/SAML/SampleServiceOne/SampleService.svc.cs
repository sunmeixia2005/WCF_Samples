using System.Security.Permissions;
using System.ServiceModel.Activation;
using SampleBaseService;

namespace SampleServiceOne
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class SampleServiceOne : SampleService, ISampleServiceOne
    {
        public SampleServiceOne()
        {
            ServiceName = "Service One";
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "User", Authenticated = true)]
        public string ComputeResponse(string input)
        {
            return GenerateResponse(input);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Admin", Authenticated = true)]
        public string ComputeResponseAdmin(string input)
        {
            return GenerateResponse(input);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "SuperAdmin", Authenticated = true)]
        public string ComputeResponseSuperAdmin(string input)
        {
            return GenerateResponse(input);
        }
    }
}
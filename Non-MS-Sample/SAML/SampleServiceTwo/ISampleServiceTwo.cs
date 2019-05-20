using System.ServiceModel;

namespace SampleServiceTwo
{
    [ServiceContract]
    public interface ISampleServiceTwo
    {
        [OperationContract]
        string ComputeResponse(string input);

        [OperationContract]
        string ComputeResponseAdmin(string input);

        [OperationContract]
        string ComputeResponseSuperAdmin(string input);
    }
}
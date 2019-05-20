using System.ServiceModel;

namespace SampleServiceOne
{
    [ServiceContract]
    public interface ISampleServiceOne
    {
        [OperationContract]
        string ComputeResponse(string input);

        [OperationContract]
        string ComputeResponseAdmin(string input);

        [OperationContract]
        string ComputeResponseSuperAdmin(string input);
    }
}

//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.IO;
using System.ServiceModel;

namespace Microsoft.Samples.Certificate
{
    // Define a service contract.
    [ServiceContract(Namespace="http://Microsoft.Samples.Certificate")]
    public interface ICalculator
    {
        [OperationContract]
        string GetCallerIdentity();
        [OperationContract]
        double Add(double n1, double n2);
        [OperationContract]
        double Subtract(double n1, double n2);
        [OperationContract]
        double Multiply(double n1, double n2);
        [OperationContract]
        double Divide(double n1, double n2);

        [OperationContract]
        int Upload(Stream data);
    }

    // Service class which implements the service contract.
    // Added code to access identity of incoming certificate
    public class CalculatorService : ICalculator
    {

        public string GetCallerIdentity()
        {
            // The client certificate is not mapped to a Windows identity by default
            // ServiceSecurityContext.PrimaryIdentity is populated based on the information
            // in the certificate that the client used to authenticate itself to the service
            return ServiceSecurityContext.Current.PrimaryIdentity.Name;
        }

        public double Add(double n1, double n2)
        {
            double result = n1 + n2;
            return result;
        }

        public double Subtract(double n1, double n2)
        {
            double result = n1 - n2;
            return result;
        }

        public double Multiply(double n1, double n2)
        {
            double result = n1 * n2;
            return result;
        }

        public double Divide(double n1, double n2)
        {
            double result = n1 / n2;
            return result;
        }

        public int Upload(Stream data)
        {
            int size = 0;
            int bytesRead = 0;
            byte[] buffer = new byte[1024];

            // Read all the data from the stream
            do
            {
                bytesRead = data.Read(buffer, 0, buffer.Length);
                size += bytesRead;
            } while (bytesRead > 0);
            data.Close();

            return size;
        }
    }

}


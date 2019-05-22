
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.Text;
using System.ServiceModel;
using System.IO;

namespace Microsoft.Samples.UserName
{
    //The service contract is defined in generatedClient.cs, generated from the service by the svcutil tool.

    //Client implementation code.
    class Client
    {
        static void Main()
        {
            Console.WriteLine("WCF client tweaked by tedy");
            Console.WriteLine("Username authentication required.");
            Console.WriteLine("Provide a valid machine or domain account. [domain\\user]");
            Console.Write("   Enter username:");
            string username = Console.ReadLine();
            Console.Write("   Enter password:");
            StringBuilder password = new StringBuilder();

            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    password.Append(info.KeyChar);
                    info = Console.ReadKey(true);
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (password.Length != 0)
                    {
                        password.Remove(password.Length - 1, 1);
                    }
                    info = Console.ReadKey(true);
                }
            }

            for (int i = 0; i < password.Length; i++)
                Console.Write("*");

            Console.WriteLine();

            // Create a client
            CalculatorClient client = new CalculatorClient();

            // Configure client with valid machine or domain account (username,password)
            client.ClientCredentials.UserName.UserName = username;
            client.ClientCredentials.UserName.Password = password.ToString();

            try
            {
                // Call GetCallerIdentity service operation
                Console.WriteLine(client.GetCallerIdentity());
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception met, detials: {0}", ex.Message);
                if(ex.InnerException != null)
                {
                    Console.WriteLine("{0}", ex.InnerException.Message);
                }
                Console.Write("Type anything to exit:");
                Console.ReadLine();
                Environment.Exit(-1);
            }

            // Call the Add service operation.
            double value1 = 100.00D;
            double value2 = 15.99D;
            double result = client.Add(value1, value2);
            Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);

            // Call the Subtract service operation.
            value1 = 145.00D;
            value2 = 76.54D;
            result = client.Subtract(value1, value2);
            Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result);

            // Call the Multiply service operation.
            value1 = 9.00D;
            value2 = 81.25D;
            result = client.Multiply(value1, value2);
            Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result);

            // Call the Divide service operation.
            value1 = 22.00D;
            value2 = 7.00D;
            result = client.Divide(value1, value2);
            Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result);

            // Call the upload service operation.
            Console.WriteLine("Next to test MTOM uploading");
            Console.Write("   Enter how many random bytes to upload, defaults=1000, input 0 to skip:");
            int bytes = 1000;
            Int32.TryParse(Console.ReadLine(), out bytes);
            if (bytes > 0)
            {
                MemoryStream stream = null;
                try
                {
                    byte[] binaryData = new byte[bytes];
                    stream = new MemoryStream(binaryData);
                    Console.WriteLine("   {0} bytes uploaded successfully.", client.Upload(stream));
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception met, detials: {0}", ex.Message);
                    if (ex.InnerException != null)
                    {
                        Console.WriteLine("{0}", ex.InnerException.Message);
                    }
                    Console.Write("Type anything to exit:");
                    Console.ReadLine();
                    Environment.Exit(-1);
                }
                finally
                {
                    if(stream != null) stream.Close();
                }
            }
            else
            {
                Console.WriteLine("   Skipped by user.");
            }

            //Closing the client gracefully closes the connection and cleans up resources
            client.Close();

            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();
        }
    }
}


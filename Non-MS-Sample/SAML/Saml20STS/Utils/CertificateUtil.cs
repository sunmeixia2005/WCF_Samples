using System;
using System.Security.Cryptography.X509Certificates;

namespace Saml20STS.Utils
{
    public static class CertificateUtil
    {
        // <summary>
        /// gets certificates from thumbprint.
        /// </summary>
        /// <param name="name">Certificate store name to open.</param>
        /// <param name="location">Store location for the certificate.</param>
        /// <param name="thumbprint">Thumbprint to be processed.</param>
        /// <returns></returns>
        public static X509Certificate2 GetCertificateByThumbprint(StoreName name, StoreLocation location, string thumbprint)
        {
            X509Store store = new X509Store(name, location);
            X509Certificate2Collection certificates = null;
            store.Open(OpenFlags.ReadOnly);
            X509Certificate2 result = null;
            try
            {
                // Every time we call store.Certificates property, a new collection will be returned.
                certificates = store.Certificates;
                if (certificates.Count > 0)
                {
                    foreach (var c in certificates)
                    {
                        if (string.Equals(c.Thumbprint, thumbprint, StringComparison.InvariantCultureIgnoreCase))
                        {
                            result = c;
                            break;
                        }
                    }
                }

                if (result == null)
                {
                    throw new ApplicationException(string.Format("No certificate was found for thumbprint {0}", thumbprint));
                }

                return result;
            }
            finally
            {
                if (certificates != null)
                {
                    for (int i = 0; i < certificates.Count; i++)
                    {
                        var cert = certificates[i];
                        if (result == null || (result != null && !string.Equals(cert.Thumbprint, result.Thumbprint)))
                        {
                            cert.Reset();
                        }
                    }
                }

                store.Close();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.ServiceModel;

namespace SampleServiceApi
{
    public class ServiceApiFactory : IDisposable
    {
        private readonly List<ICommunicationObject> _activeServices;
        private readonly SecurityToken _authToken;

        public ServiceApiFactory(SecurityToken token)
        {
            _activeServices = new List<ICommunicationObject>();
            _authToken = token;
        }

        public void Dispose()
        {
            foreach (var service in _activeServices)
            {
                try
                {
                    service.Close();
                }
                catch (CommunicationObjectFaultedException)
                {
                    service.Abort();
                }
                catch (TimeoutException)
                {
                    service.Abort();
                }
            }
        }

        public T GetService<T>(string endpointConfigurationName)
        {
            var factory = new ChannelFactory<T>(endpointConfigurationName);
            _activeServices.Add(factory);

            return factory.CreateChannelWithIssuedToken(_authToken);
        }
    }
}
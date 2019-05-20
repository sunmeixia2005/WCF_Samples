# SAML
Security Assertion Markup Language (SAML, pronounced sam-el) is an open standard for exchanging authentication and authorization data between parties, in particular, between an identity provider and a service provider. SAML is an XML-based markup language for security assertions (statements that service providers use to make access-control decisions). 

Learn more from wikipedia:
- [SAML 1.1](https://en.wikipedia.org/wiki/SAML_1.1)
- [SAML 2.0](https://en.wikipedia.org/wiki/SAML_2.0)

# Based on Work
Credits should go to Tomasz Krawczyk's blog [WCF services with claims-based authentication and authorization](https://www.future-processing.pl/blog/wcf_services_with_claims-based_authentication_and_authorization/) published on June 2015, which gives me a very good basis of STS solution to start work on, including both client and server sample projects of WCF and WIF 4.5, although the SAML assertion in use is 1.1. I'm really grateful to the original author for the wonderful project.

# What has been done?
I added a Saml20STS project to decouple from old STS project, however this is not he key point.
The key point in client side: set rst.TokenType to the offical SAML 2.0 specificaiton URL. Then WCF framework espeically federatedBinding and Security Token Service will do the rest work for you. If you don't specify this tokenType, then it will by default use SAML 1.0 assertion.

```C#
private void AuthInStsOfSaml20(string userName, string userPassword)
{
	ServicePointManager.ServerCertificateValidationCallback =
		((sender, certificate, chain, sslPolicyErrors) => true);
	var rst = new RequestSecurityToken(RequestTypes.Issue);
	rst.AppliesTo = new EndpointReference("https://RelyingParty/*");
	rst.KeyType = KeyTypes.Bearer;
	rst.TokenType = "http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.1#SAMLV2.0";

	using (var trustChannelFactory = new WSTrustChannelFactory("WS2007HttpBinding_IWSTrust13_Saml20Sync"))
	{
		trustChannelFactory.Credentials.UserName.UserName = userName;
		trustChannelFactory.Credentials.UserName.Password = userPassword;

		var channel = (WSTrustChannel)trustChannelFactory.CreateChannel();
		try
		{
			_authToken = channel.Issue(rst);
		}
		catch (MessageSecurityException ex)
		{
			channel.Abort();
			throw new SecurityTokenException(ex.InnerException.Message, ex);
		}
		catch(Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		UserIdenity = CreateUserIdentityFromSecurityToken(_authToken);
	}
}	
```


# How to use
Just fetch the whole solution, open the .sln in Visual Studio and replace globally all occurrences of `cdf97a2b88f4cc367b5788f4e0e9ab43594d6541` to the thumprint of the certifcate on your LocalMachine/Personal folder that you choose to use. Run the solution, then you are ready to go!

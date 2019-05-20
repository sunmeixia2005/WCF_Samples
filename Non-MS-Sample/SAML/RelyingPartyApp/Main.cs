using System;
using System.Security;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Text;
using System.Windows.Forms;
using STS.RelyingPartyApp.SampleServiceOne;
using SampleServiceApi;
using STS.RelyingPartyApp.SampleServiceTwo;
using STS.RelyingPartyApp.CalculatorService;

namespace STS.RelyingPartyApp
{
    public partial class Main : Form
    {
        private readonly AuthController _authController = new AuthController();

        public Main()
        {
            InitializeComponent();
        }

        private void Login(string userName, string userPassword)
        {
            try
            {
                _authController.Login(userName, userPassword);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ViewClaims();
        }

        private void Logout()
        {
            _authController.Logout();
            ViewClaims();
        }

        private void ViewClaims()
        {
            rtbClaims.Clear();
            rtbClaims.Text = "Not logged.";
            chbIsAdmin.Checked = chbIsSuperAdmin.Checked = chbIsUser.Checked = false;
            if (_authController.isAuthenticated())
            {
                var identity = _authController.UserIdenity;
                var sb = new StringBuilder();                
                foreach (var claim in identity.Claims)
                {
                    sb.AppendFormat("Claim:{0} Value:{1}", claim.Type, claim.Value);
                    sb.AppendLine();
                }
                rtbClaims.Text = sb.ToString();
                chbIsAdmin.Checked = identity.IsInRole("Admin");
                chbIsSuperAdmin.Checked = identity.IsInRole("SuperAdmin");
                chbIsUser.Checked = identity.IsInRole("User");
            }
        }

        private void Login_Click(object sender, EventArgs e)
        {
            if (ValidateUserCredentials())
            {
                Login(txtLogin.Text, txtPassword.Text);
            }
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private bool ValidateUserCredentials()
        {
            const string error = "Can't be empty!";
            var result = true;
            errProv.SetError(txtLogin, string.Empty);
            errProv.SetError(txtLogin, string.Empty);
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                errProv.SetError(txtPassword, error);
                txtPassword.Focus();
                result = false;
            }
            if (string.IsNullOrEmpty(txtLogin.Text))
            {
                errProv.SetError(txtLogin, error);
                txtLogin.Focus();
                result = false;
            }

            return result;
        }


        private void btnServiceOne_Click(object sender, EventArgs e)
        {
            rtbClaims.Clear();
            var request = "Test";
            using (var serviceApi = new ServiceApiFactory(_authController.GeToken()))
            {
                rtbClaims.AppendText("Call to Service One:");
                var client = serviceApi.GetService<ISampleServiceOne>("WS2007FederationHttpBinding_ISampleServiceOne");
                try
                {
                    rtbClaims.AppendText("Method ComputeResponse");
                    var response = client.ComputeResponse(request);
                    rtbClaims.AppendText(response);
                    rtbClaims.AppendText("Method ComputeResponseAdmin");
                    response = client.ComputeResponseAdmin(request);
                    rtbClaims.AppendText(response);
                    rtbClaims.AppendText("Method ComputeResponseSuperAdmin");
                    response = client.ComputeResponseSuperAdmin(request);
                    rtbClaims.AppendText(response);
                }
                catch (SecurityAccessDeniedException ex)
                {
                    rtbClaims.AppendText(Environment.NewLine);
                    rtbClaims.AppendText(string.Format("ACCESS ERROR:{0}", ex.Message));
                }
                catch (MessageSecurityException ex)
                {
                    rtbClaims.AppendText(Environment.NewLine);
                    rtbClaims.AppendText(string.Format("SECURITY ERROR:{0}", ex.Message));
                    if(ex.InnerException != null)
                    {
                        rtbClaims.AppendText(string.Format("\tINNER ERROR:{0}", ex.InnerException.Message));
                    }
                }
                catch (Exception ex)
                {
                    rtbClaims.AppendText(Environment.NewLine);
                    rtbClaims.AppendText(string.Format("GENERAL ERROR:{0}", ex.Message));
                    if (ex.InnerException != null)
                    {
                        rtbClaims.AppendText(string.Format("\tINNER ERROR:{0}", ex.InnerException.Message));
                    }
                }
            }
        }

        private void btnServiceTwo_Click(object sender, EventArgs e)
        {
            rtbClaims.Clear();
            var request = "Test";
            using (var serviceApi = new ServiceApiFactory(_authController.GeToken()))
            {
                rtbClaims.AppendText("Call to Service Two:");
                var client = serviceApi.GetService<ISampleServiceTwo>("WS2007FederationHttpBinding_ISampleServiceTwo");
                try
                {
                    rtbClaims.AppendText("Method ComputeResponse");
                    var response = client.ComputeResponse(request);
                    rtbClaims.AppendText(response);
                    rtbClaims.AppendText("Method ComputeResponseAdmin");
                    response = client.ComputeResponseAdmin(request);
                    rtbClaims.AppendText(response);
                    rtbClaims.AppendText("Method ComputeResponseSuperAdmin");
                    response = client.ComputeResponseSuperAdmin(request);
                    rtbClaims.AppendText(response);
                }
                catch (MessageSecurityException ex)
                {
                    rtbClaims.AppendText(Environment.NewLine);
                    rtbClaims.AppendText(string.Format("SECURITY ERROR:{0}", ex.Message));
                    if (ex.InnerException != null)
                    {
                        rtbClaims.AppendText(string.Format("\tINNER ERROR:{0}", ex.InnerException.Message));
                    }
                }                
                catch (FaultException ex)
                {
                    rtbClaims.AppendText(Environment.NewLine);
                    rtbClaims.AppendText(string.Format("ERROR:{0}", ex.Message));
                }
                catch (Exception ex)
                {
                    rtbClaims.AppendText(Environment.NewLine);
                    rtbClaims.AppendText(string.Format("GENERAL ERROR:{0}", ex.Message));
                    if (ex.InnerException != null)
                    {
                        rtbClaims.AppendText(string.Format("\tINNER ERROR:{0}", ex.InnerException.Message));
                    }
                }
            }
        }

        private void btnLoginViaSaml20_Click(object sender, EventArgs e)
        {
            if (ValidateUserCredentials())
            {
                rtbClaims.Clear();
                rtbClaims.Text = "sending RST of SAML 2.0 format";
                try
                {
                    _authController.LoginViaSaml20(txtLogin.Text, txtPassword.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                ViewClaims();
            }
           
        }

        private void BtnCalc_Click(object sender, EventArgs e)
        {
            rtbClaims.Clear();            
            using (var serviceApi = new ServiceApiFactory(_authController.GeToken()))
            {
                rtbClaims.AppendText("Call to Calculator Service:\n");
                var client = serviceApi.GetService<ICalculator>("WS2007FederationHttpBinding_ICalculator");
                try
                {
                    // Call the Add service operation.
                    double value1 = 100.00D;
                    double value2 = 15.99D;
                    double result = client.Add(value1, value2);
                    rtbClaims.AppendText(String.Format("Add({0},{1}) = {2}\n", value1, value2, result));


                    // Call the Subtract service operation.
                    value1 = 145.00D;
                    value2 = 76.54D;
                    result = client.Subtract(value1, value2);
                    rtbClaims.AppendText(String.Format("Subtract({0},{1}) = {2}\n", value1, value2, result));

                    // Call the Multiply service operation.
                    value1 = 9.00D;
                    value2 = 81.25D;
                    result = client.Multiply(value1, value2);
                    rtbClaims.AppendText(String.Format("Multiply({0},{1}) = {2}\n", value1, value2, result));

                    // Call the Divide service operation.
                    value1 = 22.00D;
                    value2 = 7.00D;
                    result = client.Divide(value1, value2);
                    rtbClaims.AppendText(String.Format("Divide({0},{1}) = {2}\n", value1, value2, result));
                }
                catch (MessageSecurityException ex)
                {
                    rtbClaims.AppendText(Environment.NewLine);
                    rtbClaims.AppendText(string.Format("ERROR:{0}", ex.InnerException != null
                        ? ex.InnerException.Message
                        : ex.Message));
                }
                catch (FaultException ex)
                {
                    rtbClaims.AppendText(Environment.NewLine);
                    rtbClaims.AppendText(string.Format("ERROR:{0}", ex.Message));
                }
                catch (Exception ex)
                {
                    rtbClaims.AppendText(Environment.NewLine);
                    rtbClaims.AppendText(string.Format("GENERAL ERROR:{0}", ex.Message));
                    if (ex.InnerException != null)
                    {
                        rtbClaims.AppendText(string.Format("\tINNER ERROR:{0}", ex.InnerException.Message));
                    }
                }
            }
        }
    }
}
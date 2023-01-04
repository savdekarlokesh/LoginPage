using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Net.Http;
using System.Windows;


namespace LoginPage
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (txtUserName.Text.ToString().Trim() != "" && txtPassword.Text.ToString().Trim() != "")
            {
                //Used HttpClient to call rest api
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44309/");
                    LoginCredential ObjLogin = new LoginCredential { UserName = txtUserName.Text.ToString(), Password = txtPassword.Text.ToString() };
                    var response = client.PostAsJsonAsync("api/login", ObjLogin).Result;
                    var txtResponse = response.Content.ReadAsStringAsync();

                    //Used Microsoft.Toolkit.Uwp.Notifications Pkg for Toast Message
                    new ToastContentBuilder()
                    .AddText(Convert.ToString(txtResponse.Result))
                    .Show();

                }
            }
            else if (txtUserName.Text.ToString().Trim() == "" && txtPassword.Text.ToString().Trim() == "")
            {
                new ToastContentBuilder()
                    .AddText("Please enter the UserName and password")
                    .Show();
            }
            else if (txtUserName.Text.ToString().Trim() == "")
            {
                new ToastContentBuilder()
                    .AddText("Please enter the UserName")
                    .Show();
            }
            else if (txtPassword.Text.ToString().Trim() == "")
            {
                new ToastContentBuilder()
                    .AddText("Please enter the password")
                    .Show();
            }
        }

        public class LoginCredential
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Configuration;
using System.Data.SqlClient;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Azure.Core;

namespace sampleazureapp.Pages
{
    public class ContactModel : PageModel
    {
        public bool hasData = false;
        public string firstName = "";
        public string lastName = "";
        public string message = ""; 
        public void OnGet()
        {
        }

        public void OnPost()
        {
            hasData = true;
            firstName = Request.Form["firstname"];
            lastName = Request.Form["lastname"];
            message = Request.Form["message"];

            //get secret
            SecretClientOptions options = new SecretClientOptions()
                {
                    Retry =
                    {
                        Delay= TimeSpan.FromSeconds(2),
                        MaxDelay = TimeSpan.FromSeconds(16),
                        MaxRetries = 5,
                        Mode = RetryMode.Exponential
                    }
                };
            var client = new SecretClient(new Uri("https://keyvault38c64193.vault.azure.net/"), new DefaultAzureCredential(), options);

            KeyVaultSecret secret = client.GetSecret("samplepassword");

            string secretValue = secret.Value;

            //query 
            string newquery = "INSERT INTO contact (firstname, lastname, msg) VALUES ('" + firstName + "', '" + lastName + "', '" + message + "');";

            using (SqlConnection sqlConnection = new SqlConnection("Server = tcp:sampleserver92734.database.windows.net,1433; Initial Catalog = sampleappdb; Persist Security Info = False; User ID = sampleadmin; Password = "+secretValue+"; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;"))
            {
                SqlCommand cmd = new SqlCommand(newquery, sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

            }
        }
    }
}

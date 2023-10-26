using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace DisasterAlleviationFoundation.Pages
{


    public partial class LoginForm : PageModel
    {
        private object username;
        private object password;

        public string PasswordTextBox { get; private set; }
        public string UsernameTextBox { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string Username = (string)UsernameTextBox;
            string Password = (string)PasswordTextBox;


            // Perform authentication (replace this with your authentication logic)
            try
            {
                // Database connection
                SqlConnection sqlconnect = new SqlConnection("Server=tcp:assigndata.database.windows.net,1433;Initial Catalog=DisasterFund;Persist Security Info=False;User ID=Admin30;Password=nomzamo55*;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                sqlconnect.Open();

                //inserting into table
                SqlCommand Sq = new SqlCommand("INSERT INTO Login(Username, Password)" +
                                     " values(@Username, @Password)", sqlconnect);


                Sq.Parameters.AddWithValue("@Username", username);
                Sq.Parameters.AddWithValue("@Password", password);
                Sq.ExecuteNonQuery();
                sqlconnect.Close();
                Response.WriteAsJsonAsync(" Sucessful ! : Please click on Next");

            }
            catch
            {
                Response.WriteAsJsonAsync("error ! : Please try again");
            }

        }

        private bool Authenticate(string username, string password)
        {
            // Replace this with your actual authentication logic, e.g., checking against a database
            if (username == "yourusername" && password == "yourpassword")
            {
                return true;
            }
            return false;
        }
    }
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}


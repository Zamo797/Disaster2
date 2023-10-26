using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace DisasterAlleviationFoundation.Pages
{
    public partial class SignUpModel : PageModel
    {

        public object UsernameTextBox { get; private set; }
        public object EmailTextBox { get; private set; }
        public object PasswordTextBox { get; private set; }
        public object ConfirmPasswordTextBox { get; private set; }

        private void SignUpButton_Click(object sender, EventArgs e)
        {
            string username = (string)UsernameTextBox;
            string email = (string)EmailTextBox;
            string password = (string)PasswordTextBox;
            string confirmPassword = (string)ConfirmPasswordTextBox;

            try
            {
                // Database connection
                SqlConnection sqlconnect = new SqlConnection("Server=tcp:assigndata.database.windows.net,1433;Initial Catalog=DisasterFund;Persist Security Info=False;User ID=Admin30;Password=nomzamo55*;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                sqlconnect.Open();

                //inserting into table
                SqlCommand Sq = new SqlCommand("INSERT INTO SignUp(Username, Email, Password, )" +
                                     " values(@Username, @Email, @Password)", sqlconnect);


                Sq.Parameters.AddWithValue("@Username", username);
                Sq.Parameters.AddWithValue("@Email", email);
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

        private static void OnGet()
        {
        }
    }
}





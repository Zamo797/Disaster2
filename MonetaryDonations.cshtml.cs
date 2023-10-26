using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Xml.Linq;

namespace DisasterAlleviationFoundation.Pages
{
    public class MonetaryDonationsModel : PageModel
    {
        private object donationamount;

        public object NameTextBox { get; private set; }
        public object EmailTextBox { get; private set; }
        public object AnonymousCheckBox { get; private set; }
        public string CurrencyTextBox { get; private set; }
        public object CurrencyComboBox { get; private set; }
        public object DonationDateDatePicker { get; private set; }

        private void DonateButton_Click(object sender, EventArgs e)
        {
            string name = (string)NameTextBox;
            string email = (string)EmailTextBox;
            bool anonymous = (bool)AnonymousCheckBox;
            decimal amount = 0;
            string currency = (string)CurrencyTextBox;
            
            try
            {
                // Database connection
                SqlConnection sqlconnect = new SqlConnection("Server=tcp:assigndata.database.windows.net,1433;Initial Catalog=DisasterFund;Persist Security Info=False;User ID=Admin30;Password=nomzamo55*;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                sqlconnect.Open();

                //inserting into table
                SqlCommand Sq = new SqlCommand("INSERT INTO MonetaryDonations(Name, Email, Anonymous, DonationAmount, Currency, DonationDate )" +
                                     " values(@Name, @Email, @Anonymous, @DonationAmount, @Currency, @DonationDate)", sqlconnect);


                Sq.Parameters.AddWithValue("@Name", name);
                Sq.Parameters.AddWithValue("@Email", email);
                Sq.Parameters.AddWithValue("@Anonymous", anonymous);
                Sq.Parameters.AddWithValue("@DonationAmount", donationamount);
                Sq.Parameters.AddWithValue(" @Currency", currency);
               // Sq.Parameters.AddWithValue("@DonationDate", donationDate);
                Sq.ExecuteNonQuery();
                sqlconnect.Close();
                Response.WriteAsJsonAsync(" Sucessful! Thank you for your donation ");

            }
            catch
            {
                Response.WriteAsJsonAsync("error ! : Please try again");
            }

            string Scurrency = CurrencyComboBox.ToString();
            DateTime donationDate = (DateTime)DonationDateDatePicker;

        }
         
        public void OnGet()
        {
        }
    }
}



using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace DisasterAlleviationFoundation.Pages
{
    public class GoodsDonationsModel : PageModel
    {
        private object donationCategory;

        public object NameTextBox { get; private set; }
        public string EmailTextBox { get; private set; }
        public bool AnonymousCheckBox { get; private set; }
        public object DonationDateDatePicker { get; private set; }
        public string DescriptionTextBox { get; private set; }
        public string NewCategoryTextBox { get; private set; }
        public object ClothingCheckBox { get; private set; }
        public bool NonPerishableFoodsCheckBox { get; private set; }

        private void DonateButton_Click(object sender, EventArgs e)
        {
            string name = (string)NameTextBox;
            string email = EmailTextBox;
            bool anonymous = AnonymousCheckBox;
            DateTime donationDate = (DateTime)DonationDateDatePicker;
            string donationDescription = DescriptionTextBox;
            string[] selectedCategories = GetSelectedCategories();
            string newCategory = NewCategoryTextBox;
            int numberOfItems = 0;

            try
            {
                // Database connection
                SqlConnection sqlconnect = new SqlConnection("Server=tcp:assigndata.database.windows.net,1433;Initial Catalog=DisasterFund;Persist Security Info=False;User ID=Admin30;Password=nomzamo55*;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                sqlconnect.Open();

                //inserting into table
                SqlCommand Sq = new SqlCommand("INSERT INTO GoodsDonations(Name, Email, Anonymous, DonationDate, DonationCategory, DonationDescription, NewCategory, NumberOfItems )" +
                                     " values(@Name, @Email, @Anonymous,  @DonationDate, @DonationCategory, @DonationDescription, @NewCategory), @NumberOfItems", sqlconnect);


                Sq.Parameters.AddWithValue("@Name", name);
                Sq.Parameters.AddWithValue("@Email", email);
                Sq.Parameters.AddWithValue("@Anonymous", anonymous);
                Sq.Parameters.AddWithValue("@DonationDate", donationDate);
                Sq.Parameters.AddWithValue("@DonationCategory", donationCategory);
                Sq.Parameters.AddWithValue("@DonationDescription", donationDescription);
                Sq.Parameters.AddWithValue("@NewCategory", newCategory);
                Sq.Parameters.AddWithValue("@NumberOfItems", numberOfItems);
                Sq.ExecuteNonQuery();
                sqlconnect.Close();
                Response.WriteAsJsonAsync(" Sucessful! Thank you for your donation");

            }
            catch
            {
                Response.WriteAsJsonAsync("error ! : Please try again");
            }

        }

        private string[] GetSelectedCategories()
        {
            var selectedCategories = new System.Collections.Generic.List<string>();
            if ((bool)ClothingCheckBox)
                selectedCategories.Add("Clothing");
            if (NonPerishableFoodsCheckBox)
                selectedCategories.Add("Non-perishable foods");

            // Add more categories as needed
            return selectedCategories.ToArray();
        }

        public void OnGet()
        {
        }
    }
}


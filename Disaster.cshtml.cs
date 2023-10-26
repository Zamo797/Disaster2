using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DisasterAlleviationFoundation.Pages
{
    public class DisasterModel : PageModel
    {
        public object MessageBoxButtons { get; private set; }
        public object StartDateDatePicker { get; private set; }
        public DateTime EndDateDatePicker { get; private set; }
        public object LocationTextBox { get; private set; }
        public string DisasterDescriptionTextBox { get; private set; }
        public string RequiredAidTextBox { get; private set; }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            
            DateTime startDate = (DateTime)StartDateDatePicker;
            DateTime endDate = (DateTime)EndDateDatePicker;
            string location = (string)LocationTextBox;
            string disasterDescription = DisasterDescriptionTextBox;
            string requiredAid = RequiredAidTextBox;

            // Save or process the disaster information as needed (e.g., send to a server, display on screen, etc.)

            Task task = Response.WriteAsJsonAsync("Disaster information submitted successfully!");
        }
        public void OnGet()
        {
        }
    }
}

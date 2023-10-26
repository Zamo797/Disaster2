using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DisasterAlleviationFoundation.Pages
{
    public class ActiveDisasterModel : PageModel
    {
        public void OnGet()
        {
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";

            string action = context.Request.Form["action"];

            if (action == "allocateMoney")
            {
                // Process allocation of money
                string amount = context.Request.Form["amount"];
                string disaster = context.Request.Form["disaster"];

                // Add code to handle money allocation here
            }
            else if (action == "allocateGoods")
            {
                // Process allocation of goods
                string goods = context.Request.Form["goods"];
                string disaster = context.Request.Form["disaster"];

                // Add code to handle goods allocation here
            }
            else if (action == "capturePurchase")
            {
                // Process capturing purchase
                string item = context.Request.Form["item"];
                string cost = context.Request.Form["cost"];
                string disaster = context.Request.Form["disaster"];

                // Add code to handle purchase capturing here
            }

            // Redirect to a success or error page
            context.Response.Redirect("success");
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }

}


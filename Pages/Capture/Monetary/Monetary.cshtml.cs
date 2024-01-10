using DAF_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DAF_Project.Pages.Capture.CaptureMoney
{
    public class CaptureMoneyModel : PageModel
    {
        private readonly db_donationsContext _context;
        public String newDate = "";
        public String newAmount = "";
        public String newDonor = "";
        public String errorMessage = "";
        public String successMessage = "";
        public CaptureMoneyModel(db_donationsContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }
        public void OnPost()
        {
            newDate = Request.Form["date"];
            newAmount = Request.Form["amount"];
            newDonor = Request.Form["donor"];

            try
            {
                var monetary = new Models.Monetary
                {
                    Date = Convert.ToDateTime(newDate).Date,
                    Amount = Convert.ToDecimal(newAmount),
                    Donor = newDonor
                };

                _context.Add(monetary);
                _context.SaveChanges();

            } catch(Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
            successMessage = "captured successfully!";
        }
    }
}

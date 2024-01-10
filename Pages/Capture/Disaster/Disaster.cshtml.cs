using DAF_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DAF_Project.Pages.Capture.CaptureDisaster
{
    public class CaptureDisasterModel : PageModel
    {
        private readonly db_donationsContext _context;
        public String newStartDate = "";
        public String newEndDate = "";
        public String newLocation = "";
        public String newDescription = "";
        public String newType = "";
        public String errorMessage = "";
        public String successMessage = "";
        public CaptureDisasterModel(db_donationsContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            newStartDate = Request.Form["start_date"];
            newEndDate = Request.Form["end_date"];
            newLocation = Request.Form["location"];
            newDescription = Request.Form["description"];
            newType = Request.Form["type"];

            try
            {
                var disaster = new Models.Disaster
                {
                    StartDate = Convert.ToDateTime(newStartDate).Date,
                    EndDate = Convert.ToDateTime(newEndDate).Date,
                    Location = newLocation,
                    Description = newDescription,
                    Type = newType
                };

                _context.Add(disaster);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
            successMessage = "captured successfully!";
        }
    }
}

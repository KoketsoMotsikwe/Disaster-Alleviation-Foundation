using DAF_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DAF_Project.Pages.Allocate
{
    public class AllocateModel : PageModel
    {
        private readonly db_donationsContext _context;
        public List<SelectListItem>? OptionsDisaster { get; set; }
        public String disaster = "";
        public Decimal amount;
        public Decimal availableAmount;
        public String description = "";
        public String successMessage = "";
        public String errorMessage = "";
        public AllocateModel(db_donationsContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            OptionsDisaster = _context.Disasters.Select(a => new SelectListItem
            {
                Text = a.Description,
            }).ToList();
        }

        public void OnPost()
        {
            disaster = Request.Form["disaster"];
            amount = Convert.ToDecimal(Request.Form["amount"]);
            description = Request.Form["goods"];

            try
            {
                // get the active disaster
                var disasterEntity = _context.Disasters.Where(e => e.Description == disaster).First();
                disasterEntity.Amount = amount;
                disasterEntity.Type = description;
                _context.Update(disasterEntity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
            successMessage = "Money & Goods have been allocated to the Disaster";
        }
    }
}

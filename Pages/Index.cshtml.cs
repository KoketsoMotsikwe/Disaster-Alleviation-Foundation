using DAF_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DAF_Project.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly db_donationsContext _context;
        public dynamic? money;
        public dynamic? goods;
        public dynamic? disaster;
        public dynamic? disasterMoney;
        public dynamic? disasterGoods;
        public String errorMessage = "";
        public IndexModel(ILogger<IndexModel> logger, db_donationsContext context)
        {
            _logger = logger;
            _context = context;
        }
        public void OnGet()
        {
            try
            {
                money = _context.Monetaries.Select(e => e.Amount).Sum();
                goods = _context.Goods.Select(e => e.NumberOfItems).Sum();
                // get the active disaster data
                var activeDisaster = _context.Disasters.Where(e => e.StartDate >= DateTime.Now.Date && DateTime.Now.Date <= e.EndDate).First();
                disaster = activeDisaster.Description;
                disasterMoney = activeDisaster.Amount;
                disasterGoods = activeDisaster.Type;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
        }
        public void OnPost()
        {
            OnGetMyOnClick();
            Response.Redirect("/Index");
        }
        public void OnGetMyOnClick()
        {
            HttpContext.Session.Clear();
        }
    }
}
using DAF_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DAF_Project.Pages.ViewAll
{
    public class ViewModel : PageModel
    {
        private readonly db_donationsContext _context;
        public dynamic money = "";
        public dynamic goods = "";
        public dynamic disaster = "";
        public ViewModel(db_donationsContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            money = _context.Monetaries.Where(e => e.Date == DateTime.Now.Date && e.Amount > 0).Select(e => e.Amount).Sum();
            var good = _context.Goods.Where(e => e.Date == DateTime.Now.Date).First();
            goods = good.Description;
        }
        public void OnPost()
        {
            var good = _context.Goods.Where(e => e.Date == DateTime.Now.Date);
        }
    }
}

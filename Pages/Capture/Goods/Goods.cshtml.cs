using DAF_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DAF_Project.Pages.Capture.CaptureGoods
{
    public class CaptureGoodsModel : PageModel
    {
        private readonly db_donationsContext _context;
        public List<SelectListItem>? Options { get; set; }
        public String newDate = "";
        public int newNumberOfItems;
        public String newCategory = "";
        public String newDescription = "";
        public String newDonor = "";
        public String errorMessage = "";
        public String successMessage = "";
        public CaptureGoodsModel(db_donationsContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Options = _context.GoodsCategories.Select(a => new SelectListItem
            {
                Text = a.Category.ToString(),
            }).ToList();
        }
        public void OnPost()
        {
            newDate = Request.Form["date"];
            newNumberOfItems = (int)Convert.ToInt64(Request.Form["number_of_items"]);
            if (Request.Form["type"]=="Add-New-Item")
            {
                newCategory = Request.Form["category"];

                // add new category to category table
                try
                {
                    var goodsCategory = new Models.GoodsCategory
                    {
                        Category = newCategory
                    };

                    _context.GoodsCategories.Add(goodsCategory);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    errorMessage = ex.Message;
                    return;
                }
            }
            else
            {
                newCategory = Request.Form["type"];
            }
            newDescription = Request.Form["description"];
            newDonor = Request.Form["donor"];

            try
            {
                var goods = new Models.Good
                {
                    Date = Convert.ToDateTime(newDate).Date,
                    NumberOfItems = newNumberOfItems,
                    Category = newCategory,
                    Description = newDescription,
                    Donor = newDonor
                };

                _context.Add(goods);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
            // add back after page changes
            Options = _context.GoodsCategories.Select(a => new SelectListItem
            {
                Text = a.Category.ToString(),
            }).ToList();
            successMessage = "captured successfully!";
        }
    }
}

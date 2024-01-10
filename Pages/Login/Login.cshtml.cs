using DAF_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace DAF_Project.Pages.Login
{
    public class LoginModel : PageModel
    {
        private readonly db_donationsContext _context;
        public String userName = "";
        public String userPassword = "";
        public string newUserName = "";
        public string newPassword = "";
        public String userType = "";
        public bool checkProfile = false;
        public String successMessage = "";
        public String errorMessage = "";
        public LoginModel(db_donationsContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            dynamic? user = null;
            if (errorMessage.Length == 0)
            {
                newUserName = Request.Form["name"];
                newPassword = Request.Form["password"];
            }

            try
            {
                user = _context.Users.Where(e => e.UserName == newUserName).First();
                userName = user.UserName;
                userPassword = user.Password;
                userType = user.UserType;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            string password = HashPassword(newPassword);

            if (newUserName.Length == 0 || newPassword.Length == 0)
            {
                errorMessage = "All fields are required";
                return;
            }
            else if (newUserName != userName)
            {
                errorMessage = "User does not have a profile, please click button to create a new profile";
                checkProfile = true;
                return;
            }
            else if (password != userPassword)
            {
                errorMessage = "Wrong password entered";
                return;
            }
            HttpContext.Session.SetString("userType", userType);
            successMessage = "Logged In";
            Response.Redirect("/Index");
        }
        public string HashPassword(string password)
        {
            var sha = SHA256.Create();
            var asByteArray = Encoding.Default.GetBytes(password);
            var hashedPassword = sha.ComputeHash(asByteArray);
            return Convert.ToBase64String(hashedPassword);
        }
    }
}

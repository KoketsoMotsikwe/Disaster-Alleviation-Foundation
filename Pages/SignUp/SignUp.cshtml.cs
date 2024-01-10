using DAF_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;
using System.Text;

namespace DAF_Project.Pages.SignUp
{
    public class SignUpModel : PageModel
    {
        private readonly db_donationsContext _context;
        public string firstName = "";
        public string lastName = "";
        public string userName = "";
        public string userType = "";
        public string password = "";
        public string cpassword = "";
        public string errorMessage = "";
        public string successMessage = "";

        public SignUpModel(db_donationsContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            firstName = Request.Form["firstName"];
            lastName = Request.Form["lastName"];
            userName = Request.Form["userName"];
            userType = "Non-Employee";
            password = Request.Form["password"];
            cpassword = Request.Form["cpassword"];

            // Removed password matching condition
            string hashedPassword = HashPassword(password);

            // Removed checking for existing user

            var user = new Models.User
            {
                FirstName = firstName,
                LastName = lastName,
                UserName = userName,
                UserType = userType,
                Password = hashedPassword
            };

            _context.Add(user);
            _context.SaveChanges();

            successMessage = "New profile created successfully. Go to the login page and use the newly created username and password.";
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


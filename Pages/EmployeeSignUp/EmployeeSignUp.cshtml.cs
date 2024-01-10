using DAF_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;
using System.Text;

namespace DAF_Project.Pages.EmployeeSignUp
{
    public class EmployeeSignUpModel : PageModel
    {
        private readonly db_donationsContext _context;
        public String firstName = "";
        public String lastName = "";
        public String userName = "";
        public String userType = "";
        public String password = "";
        public String cpassword = "";
        public String errorMessage = "";
        public String successMessage = "";
        public EmployeeSignUpModel(db_donationsContext context)
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
            userType = "Employee";
            password = Request.Form["password"];
            cpassword = Request.Form["cpassword"];

            if (password != cpassword)
            {
                errorMessage = "Passwords don't match";
                return;
            }

            string hashedPassword = HashPassword(password);

            try
            {
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
            }
            catch (Exception ex)
            {
                errorMessage = "User name already exist, try to add a different user name";
                Console.WriteLine(ex.Message);
                return;
            }

            // show success message and redirect back to login page
            successMessage = "New employee profile created successfully";
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

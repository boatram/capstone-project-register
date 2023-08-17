using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CapstoneProject.Repository.Model;
using CapstoneProject.Service;

namespace CapstoneProjectRegister.Web.Pages.StudentManagement
{
    public class IndexModel : PageModel
    {
        private readonly StudentService _context;

        public IndexModel(StudentService context)
        {
            _context = context;
        }

        public IEnumerable<Student> Student { get;set; }

        public async Task OnGetAsync()
        {
            Student = _context.GetStudents();
        }
    }
}

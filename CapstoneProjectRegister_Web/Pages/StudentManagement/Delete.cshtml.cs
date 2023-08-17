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
    public class DeleteModel : PageModel
    {
        private readonly StudentService _context;

        public DeleteModel(StudentService context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = _context.GetStudentByID(id);

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (Student != null)
            {
                bool delete = _context.Delete(Student.Id);
            }

            return RedirectToPage("./Index");
        }
    }
}

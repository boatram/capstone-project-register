using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CapstoneProject.Repository.Model;
using CapstoneProject.Service;

namespace CapstoneProjectRegister.Web.Pages.StudentManagement
{
    public class CreateModel : PageModel
    {
        private readonly StudentService _context;

        public CreateModel(StudentService context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Create(Student);

            return RedirectToPage("./Index");
        }
    }
}

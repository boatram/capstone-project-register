using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CapstoneProject.Repository.Model;
using CapstoneProject.Service;

namespace CapstoneProjectRegister.Web.Pages.StudentInGroupManagement
{
    public class EditModel : PageModel
    {
        private readonly StudentInGroupService _context;
        private readonly StudentService _student;

        public EditModel(StudentInGroupService context,  StudentService studentService)
        {
            _context = context;
            _student = studentService;
        }

        [BindProperty]
        public StudentInGroup StudentInGroup { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StudentInGroup = _context.GetStudentInGroupByID(id);

            if (StudentInGroup == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_student.GetStudents(), "Id", "Code");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _context.Update(StudentInGroup);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentInGroupExists(StudentInGroup.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StudentInGroupExists(int id)
        {
            var s = _context.GetStudentInGroupByID(id);
            if (s == null)
                return false;
            return true;
        }
    }
}

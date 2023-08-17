using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CapstoneProject.Repository.Model;
using CapstoneProject.Service;
using CapstoneProjectRegister.Web.Pages.Helper;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace CapstoneProjectRegister.Web.Pages.StudentInGroupManagement
{
    public class CreateModel : PageModel
    {
        private readonly StudentInGroupService _context;
        private readonly StudentService _student;

        public CreateModel(StudentInGroupService context, StudentService studentService)
        {
            _context = context;
            _student = studentService;
        }

        public IActionResult OnGet()
        {
        ViewData["StudentId"] = new SelectList(_student.GetStudents(), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public StudentInGroup StudentInGroup { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var grId = SessionHelper.GetObjectFromJson<int>(HttpContext.Session, "GroupId");
            StudentInGroup.GroupId = grId;
            _context.Create(StudentInGroup);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "GroupId", grId);
            
            return RedirectToPage("./Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CapstoneProject.Repository.Model;
using CapstoneProject.Service;
using CapstoneProject.Repository.DTO;

namespace CapstoneProjectRegister.Web.Pages.TopicOfLecturerManagement
{
    public class CreateModel : PageModel
    {
        private readonly TopicService _context;
        private readonly LecturerService lecturer;
        private readonly SemesterService semester;

        public CreateModel(TopicService context, LecturerService lecturerr, SemesterService semesterr)
        {
            _context = context;
            lecturer = lecturerr;
            semester = semesterr;
        }

        public IActionResult OnGet()
        {
            ViewData["SemesterCode"] = new SelectList(semester.GetSemesters(), "Code", "Code");
            ViewData["SuperLecturerEmail"] = new SelectList(lecturer.GetLecturers(), "Email", "Email");
            ViewData["LecturerName"] = new SelectList(lecturer.GetLecturers(),"Name", "Name");
            return Page();
        }

        [BindProperty]
        public TopicView TopicView { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Create(TopicView);

            return RedirectToPage("./Index");
        }
    }
}

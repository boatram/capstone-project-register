using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CapstoneProject.Repository.Model;
using CapstoneProject.Service;

namespace CapstoneProjectRegister.Web.Pages.GroupProjectManagement
{
    public class CreateModel : PageModel
    {
        private readonly GroupService _context;
        private readonly SemesterService _semesterService;
        private readonly TopicService _topicService;

        public CreateModel(GroupService context, SemesterService semesterService, TopicService topicService)
        {
            _context = context;
            _semesterService=semesterService;
            _topicService=topicService;
        }

        public IActionResult OnGet()
        {
        ViewData["SemesterId"] = new SelectList(_semesterService.GetSemesters(), "Id", "Code");
        ViewData["TopicId"] = new SelectList(_topicService.GetTopics(), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public GroupProject Group { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Create(Group);

            return RedirectToPage("./Index");
        }
    }
}

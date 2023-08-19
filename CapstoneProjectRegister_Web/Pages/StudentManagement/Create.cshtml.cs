using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CapstoneProject.Repository.Model;
using CapstoneProject.Service;
using System.Collections;
using Microsoft.AspNetCore.Http;

namespace CapstoneProjectRegister.Web.Pages.StudentManagement
{
    public class CreateModel : PageModel
    {
        private readonly StudentService _context;
        private readonly FirebaseStorageService _fileStorageService;

        public CreateModel(StudentService context, FirebaseStorageService fileStorageService)
        {
            _context = context;
            _fileStorageService = fileStorageService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(IFormFile? userDisplayPic)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (userDisplayPic != null && userDisplayPic.Length > 0)
            {
                string url = await _fileStorageService.UploadFileToDefaultAsync(userDisplayPic.OpenReadStream(), userDisplayPic.FileName);
                Student.Avatar = url;
            }

            _context.Create(Student);

            return RedirectToPage("./Index");
        }
    }
}

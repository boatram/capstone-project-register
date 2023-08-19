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
using System.Collections;
using Microsoft.AspNetCore.Http;

namespace CapstoneProjectRegister.Web.Pages.StudentManagement
{
    public class EditModel : PageModel
    {
        private readonly StudentService _context;
        private readonly FirebaseStorageService _fileStorageService;

        public EditModel(StudentService context, FirebaseStorageService firebaseStorageService)
        {
            _context = context;
            _fileStorageService = firebaseStorageService;
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(IFormFile userDisplayPic)
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
            try
            {
                _context.Update(Student);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(Student.Id))
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

        private bool StudentExists(int id)
        {
            Student st = _context.GetStudentByID(id);
            if (st  == null)
            {
                return false;
            }
            return true;
        }
    }
}

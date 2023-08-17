using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CapstoneProject.Repository.Model;
using CapstoneProject.Service;
using CapstoneProject.Repository.DTO;
using CapstoneProjectRegister.Web.Pages.Helper;

namespace CapstoneProjectRegister.Web.Pages.StudentInGroupManagement
{
    public class IndexModel : PageModel
    {
        private readonly StudentInGroupService _context;

        public IndexModel(StudentInGroupService context)
        {
            _context = context;
        }
        public IEnumerable<StudentInGroup> StudentInGroup { get;set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            int i = SessionHelper.GetObjectFromJson<int>(HttpContext.Session, "GroupId");
            if (i == 0)
            {
                StudentInGroup = _context.GetStudentInGroups(id);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "GroupId", id);
            }
            else
            {
                StudentInGroup = _context.GetStudentInGroups(i);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "GroupId", id);
            }
                  
            return Page();
        }
    }
}

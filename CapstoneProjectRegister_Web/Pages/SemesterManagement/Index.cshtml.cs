using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CapstoneProject.Repository.Model;
using CapstoneProject.Service;

namespace CapstoneProjectRegister.Web.Pages.SemesterManagement
{
    public class IndexModel : PageModel
    {
        private readonly SemesterService _context;

        public IndexModel(SemesterService context)
        {
            _context = context;
        }

        public IEnumerable<Semester> Semester { get;set; }

        public async Task OnGetAsync()
        {
            Semester = _context.GetSemesters();
        }
    }
}

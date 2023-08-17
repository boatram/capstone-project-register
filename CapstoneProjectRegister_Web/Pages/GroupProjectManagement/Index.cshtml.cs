using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CapstoneProject.Repository.Model;
using CapstoneProject.Service;

namespace CapstoneProjectRegister.Web.Pages.GroupProjectManagement
{
    public class IndexModel : PageModel
    {
        private readonly GroupService _context;

        public IndexModel(GroupService context)
        {
            _context = context;
        }

        public IEnumerable<GroupProject> GroupProject { get;set; }

        public async Task OnGetAsync()
        {
            GroupProject =  _context.GetGroupProjects();
        }
    }
}

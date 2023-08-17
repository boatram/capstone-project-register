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

namespace CapstoneProjectRegister.Web.Pages.TopicOfLecturerManagement
{
    public class IndexModel : PageModel
    {
        private readonly TopicOfLecturerService _context;

        public IndexModel(TopicOfLecturerService context)
        {
            _context = context;
        }

        public IEnumerable<TopicView> TopicVew { get;set; }

        public async Task OnGetAsync()
        {
            TopicVew = _context.GetTopic();
        }
    }
}

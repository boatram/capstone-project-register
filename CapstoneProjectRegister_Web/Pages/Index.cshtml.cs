using AutoMapper;
using CapstoneProject.Repository.DTO;
using CapstoneProject.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneProjectRegister.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly LecturerService _service;
        private IConfiguration configuration;
        public IMapper mapper;

        public IndexModel(LecturerService service, IMapper mapper, IConfiguration confi)
        {
            _service = service;
            this.mapper = mapper;
            configuration = confi;
        }

        [BindProperty]
        public LoginLecturer Lecturer { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Lecturer == null)
            {
                return Page();
            }
            else
            {
                if (Lecturer.Email.Equals(configuration["User:Email"]) && Lecturer.Password.Equals(configuration["User:Password"]))
                {
                    return RedirectToPage("/AdminPages/Index");
                }
                else
                {
                    Lecturer = mapper.Map<LoginLecturer>(_service.GetLecturer(Lecturer.Email, Lecturer.Password));
                    //SessionHelper.SetObjectAsJson(HttpContext.Session, "Email", Lecturer.Email);
                    //HttpContext.Session.SetObjectAsJson("Email", Lecturer.Email);
                    return RedirectToPage("/TopicOfLecturerManagement/Index");
                }
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using school.models;

namespace school.Pages
{
    public class IndexModel : PageModel
    {
        public List<student> students = new List<student>();
        [BindProperty]
        public string search { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            using (schooldbcontext dbcontext = new schooldbcontext())
            {
                students = dbcontext.students.Include(s => s.classrooms).ToList();
            }
        }
        public void OnPost()
        {
            using (schooldbcontext dbcontext = new schooldbcontext())
            {
                string[] F_and_Lname = search.Split(' ');
                string firstname =F_and_Lname[0];
                string lastname;
                if (F_and_Lname.Count()==2)
                {
                    lastname = F_and_Lname[1];
                    students = dbcontext.students.Where(s => s.fname.Contains(firstname) ==true || s.lname.Contains(lastname)==true).Include(s => s.classrooms).ToList();
                }
                else if(F_and_Lname.Count()==1)
                {
                    students = dbcontext.students.Where(s => s.fname.Contains(firstname) == true).Include(s => s.classrooms).ToList();
                }
                else
                {
                    lastname = F_and_Lname[1];
                    students = dbcontext.students.Where(s => s.fname.Contains(firstname) == true || s.lname.Contains(lastname) == true).Include(s => s.classrooms).ToList();
                }
            }

        }
    }
}
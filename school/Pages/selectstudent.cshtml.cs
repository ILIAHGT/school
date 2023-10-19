using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using school.models;

namespace school.Pages
{
    public class selectstudentModel : PageModel
    {
        [BindProperty(SupportsGet =true)]
        public Guid studentid { get; set; }
        public List<student> students = new List<student>();
        public void OnGet()
        {
            using (schooldbcontext dbcontext = new schooldbcontext())
            {
                students = dbcontext.students.Include(s => s.classrooms).ToList();
            }
            if(studentid != Guid.Empty)
            {
                string url = "./setreportcard?studentid=" + studentid;
                Response.Redirect(url);
            }
        }
    }
}

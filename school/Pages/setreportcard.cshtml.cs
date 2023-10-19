using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using school.models;

namespace school.Pages
{
    public class setreportcardModel : PageModel
    {
        [BindProperty]
        public reportcard reportcard { get; set; }
        [BindProperty(SupportsGet =true)]
        public Guid studentid { get; set; }
        public List<classroom> classrooms = new List<classroom>();
        public IActionResult OnGet()
        {
            using (schooldbcontext dbcontext = new schooldbcontext())
            {
                classrooms = dbcontext.students.Where(s => s.id == studentid).Include(s => s.classrooms).FirstOrDefault().classrooms.ToList();
                return Page();
            }
        }
        public IActionResult OnPost()
        {
            using (schooldbcontext dbcontext = new schooldbcontext())
            {
                reportcard.Student = dbcontext.students.Where(s => s.id == studentid).Include(s => s.classrooms).FirstOrDefault();
                reportcard.classroom = dbcontext.classrooms.Where(c => c.id == reportcard.classroom.id).Include(s => s.students).FirstOrDefault();
                reportcard.issuedate = Convert.ToDateTime(DateTime.Now.ToString("yyy/M/d h:m:s"));
                dbcontext.reportcards.Add(reportcard);
                dbcontext.SaveChanges();
                return RedirectToPage("index");
            }
        }
    }
}

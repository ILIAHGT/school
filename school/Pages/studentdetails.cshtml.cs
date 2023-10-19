using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using school.models;

namespace school.Pages
{
    public class studentdetailsModel : PageModel
    {
        [BindProperty(SupportsGet =true)]
        public Guid studentid { get; set; }
        [BindProperty(SupportsGet = true)]
        public string delete {  get; set; }
        public List<reportcard> reportcards = new List<reportcard>();
        public student student;
        public void OnGet()
        {
            using (schooldbcontext dbcontext = new schooldbcontext())
            {
                reportcards= dbcontext.reportcards.Where(r=>r.Student.id == studentid).ToList();
                student = dbcontext.students.Where(s => s.id == studentid).Include(s => s.classrooms).FirstOrDefault();
            }
            
        }
        public void OnPost()
        {
            using (schooldbcontext dbcontext = new schooldbcontext())
            {
                student = dbcontext.students.Where(s => s.id == studentid).Include(s => s.classrooms).FirstOrDefault();
                dbcontext.students.Remove(student);
                dbcontext.SaveChanges();
                Response.Redirect("index");
                
            }
        }
    }
}

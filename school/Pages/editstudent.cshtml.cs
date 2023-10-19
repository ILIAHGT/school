using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using school.models;

namespace school.Pages
{
    public class editstudentModel : PageModel
    {
        [BindProperty(SupportsGet =true)]
        public Guid studentid { get; set; }
        [BindProperty]
        public student student { get; set; }
        public void OnGet()
        {
            using (schooldbcontext dbcontext = new schooldbcontext())
            {
                student = dbcontext.students.Where(s => s.id == studentid).Include(s => s.classrooms).FirstOrDefault();
            }
        }
        public IActionResult OnPost() 
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                using (schooldbcontext dbcontext = new schooldbcontext())
                {
                    student.id = studentid;
                    dbcontext.students.Update(student);
                    dbcontext.SaveChanges();
                    return RedirectToPage("/index");
                }
            }
        }
    }
}

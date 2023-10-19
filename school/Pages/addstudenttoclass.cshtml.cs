using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using school.models;

namespace school.Pages
{
    public class addstudenttoclassModel : PageModel
    {
        [BindProperty]
        public Guid studentid { get; set; }
        [BindProperty]
        public Guid classroomid { get; set; }
        public List<student> students = new List<student>();
        public List<classroom> classrooms =new List<classroom>();

        public void OnGet()
        {
            using (schooldbcontext dbcontext = new schooldbcontext())
            {
                students=dbcontext.students.Include(s=>s.classrooms).ToList();
                classrooms=dbcontext.classrooms.Include(c=>c.students).ToList();
            }
                
        }
        public IActionResult OnPost() 
        {
            using (schooldbcontext dbcontext = new schooldbcontext())
            {
                var _student = dbcontext.students.Where(s => s.id == studentid).Include(s => s.classrooms).FirstOrDefault();
                var _classroom = dbcontext.classrooms.Where(c => c.id == classroomid).Include(c => c.students).FirstOrDefault();
                _classroom.numberofstudents= _classroom.students.Count();
                _classroom.students.Add(_student);
                _student.classrooms.Add(_classroom);
                dbcontext.SaveChanges();
            }
            return RedirectToPage("index");
        }
    }
}

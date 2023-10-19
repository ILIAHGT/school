using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using school.models;

namespace school.Pages
{
    public class createclassModel : PageModel
    {
        [BindProperty]
        public classroom classroom { get; set; }
        public void OnGet()
        {

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
                    classroom.numberofstudents = 0;
                    dbcontext.classrooms.Add(classroom);
                    dbcontext.SaveChanges();
                    return RedirectToPage("/addstudenttoclass");
                }
            }

        }
    }
}

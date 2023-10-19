using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using school.models;

namespace school.Pages.Shared
{
    public class addstudentModel : PageModel
    {
        [BindProperty]
        public student student { get; set; }
        public IActionResult OnGet()
        {
            return Page();
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
                    dbcontext.students.Add(student);
                    dbcontext.SaveChanges();
                    return RedirectToPage("/createclass");
                }
            }
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace school.models
{
    public class reportcard
    {
        [Key]
        public Guid id { get; set; }
        [Required(ErrorMessage = "نام دانش اموز نمیتواند خالی باشد!")]
        [Display(Name ="نام دانش اموز" , Prompt ="مثال:فلی احمدی")]
        public student Student { get; set; }
        [Display(Name = "نام کلاس", Prompt = "مثال:فلی احمدی")]
        [Required(ErrorMessage = "نام کلاس نمیتواند خالی باشد!")]
        public classroom classroom { get; set; }
        [Required(ErrorMessage = "نمره نمیتواند خالی باشد!")]
        [Range(0, 20,ErrorMessage ="نمره نامعتبر است!")]      
        [Display(Name ="نمره دانش اموز" , Prompt ="مثال:19.75")]
        public double? score { get; set; }
        public DateTime issuedate {  get; set; }
    }
}

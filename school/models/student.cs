using System.ComponentModel.DataAnnotations;

namespace school.models
{
    public class student
    {
        [Key]
        public Guid id { get; set; }
        [Required(ErrorMessage = "نام کوچک نمیتواند خالی باشد!")]
        [Display(Name ="تام کوچک",Prompt ="مثال:علی")]
        public string fname { get; set; }
        [Display(Name = "تام خوانوادگی", Prompt = "مثال:احمدی")]
        [Required(ErrorMessage = "نام خوانوادگی نمیتواند خالی باشد!")]
        public string lname { get; set; }
        [Required(ErrorMessage = "سن نمیتواند خالی باشد!")]
        [Range(0,110,ErrorMessage = "لطفا سن معتبر وارد نمایید!")]
        [Display(Name = "سن", Prompt = "مثال:۱۴")]
        public int? age { get; set;}
        [Required(ErrorMessage = "کد ملی نمیتواند خالی باشد!")]
        [Display(Name = "کدملی", Prompt = "مثال:۰۱۵۱۱۱۱۱۱۱")]
        [MaxLength(10,ErrorMessage ="کد ملی نامعتبر است!")]
        public string nationalcode { get; set; }
        [Required(ErrorMessage = "نام پدر نمیتواند خالی باشد!")]
        [Display(Name = "تام پدر", Prompt = "مثال:علی")]
        public string fathername { get; set;}
        [Required(ErrorMessage = "پایه تحصیلی نمیتواند خالی باشد!")]
        [Range(1,12,ErrorMessage ="پایه تحصیلی نا معتبر است!")]
        [Display(Name = "پایه تحصیلی", Prompt = "مثال:۹")]
        public int? grade { get; set;}
        public List<classroom>? classrooms { get; set;}
    }
}

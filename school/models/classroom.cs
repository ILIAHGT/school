using System.ComponentModel.DataAnnotations;

namespace school.models
{
    public class classroom
    {
        [Key]
        public Guid id { get; set; }
        [Required(ErrorMessage = "نام کلاس نمیتواند خالی باشد!")]
        [Display(Name ="نام کلاس",Prompt ="مثال:سی شارپ مقدماتی")]
        public string classname { get; set; }
        [Display(Name = "نام معلم", Prompt = "مثال:غلی احمدی")]
        [Required(ErrorMessage = "نام معلم نمیتواند خالی باشد!")]
        public string teachername { get; set; }
        public int? numberofstudents { get; set; }
        [Required(ErrorMessage = "ساعت طول کشیدن دوره نمیتواند خالی باشد!")]
        [Display(Name = "ساعت طول کشیدن دوره", Prompt = "مثال:۴۵")]
        public int? durationofcoursebyhour { get; set; }
        public List<student>? students { get; set;}
        

    }
}

using System.ComponentModel.DataAnnotations;

namespace TaminApp.ViewModels.Degree
{
    public class DegreeCreateViewModel
    {

        [Required(ErrorMessage = "عنوان الزامی است.")]
        [MaxLength(50, ErrorMessage = "نام مدرک تحصیلی  نمی‌تواند بیشتر از 50 کاراکتر باشد.")]
        public string DegreeName { get; set; }
    }
}

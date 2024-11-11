using System.ComponentModel.DataAnnotations;

namespace TaminApp.ViewModels.DiseaseType
{
    public class DiseaseTypeCreateViewModel
    {
        [Required(ErrorMessage = "عنوان الزامی است.")]
        [MaxLength(50, ErrorMessage = "نام بیماری نمی‌تواند بیشتر از 50 کاراکتر باشد.")]

        public string DiseaseName { get; set; } //نام بیماری
    }
}

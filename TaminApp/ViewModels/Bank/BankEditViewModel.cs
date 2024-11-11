using System.ComponentModel.DataAnnotations;

namespace TaminApp.ViewModels.Bank
{
    public class BankEditViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "عنوان الزامی است.")]
        [MaxLength(70, ErrorMessage = "نام بانک  نمی‌تواند بیشتر از 70 کاراکتر باشد.")]
        public string BankName { get; set; }
        public bool IsActive { get; set; }
    }
}

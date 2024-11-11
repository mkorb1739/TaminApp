namespace TaminApp.ViewModels.people
{
    public class PeopleCreateViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public int TEl { get; set; }
        public int mobile { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public bool  gender { get; set; }
        public DateTime BirchDate { get; set; }
        public DateTime DeathDate { get; set; }// تاریخ مرگ
        public string BirthcertificateNumber { get; set; }//شماره شناسنامه
        public string NationalCode { get; set; }
        public int MembershipNumber { get; set; }//شماره عضویت
        public DateTime MembershipDate { get; set; } //تاریخ عضویت
        public DateTime HokmDate { get; set; }// تاریخ حکم کارگزینی
        public int pensionNumber { get; set; }//شماره مستمری
        public string Birthcertificateseries { get; set; } //سریال شناسنامه
        public int DegreeID { get; set; }//مدرک تحصیلی
       public int InsuranceType { get; set; }//نوع بیمه1=مستمریبگیر2=ازکارافتاده3=بازمانده
        public int TaminCode { get; set; }//کد شعبه تامین اجتماعی
        public bool HousingType { get; set; } //نوع مسکن 1=ملکی 0= استیجاری
        public int SacrificeID { get; set; } //وضعیت ایثارگری   1=ایثارگر 2=جانباز3=خانواده شهدا
        public bool marriage { get; set; }//وضعیت تاهل 1=متاهل 0=مجرد
        public int BankID { get; set; }
        public string Description { get; set; }//توضیحات
        public DateTime UpdatedDate { get; set; }
    }
}

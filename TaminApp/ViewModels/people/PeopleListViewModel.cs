using TaminApp.Entity;

namespace TaminApp.ViewModels.people
{
    public class PeopleListViewModel
    {
        public int ID { get; set; }
        public int MembershipNumber { get; set; }//شماره عضویت
        public string NationalCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int mobile { get; set; }
        public bool IsActive { get; set; }

    }
}

namespace TaminApp.Entity
{
    public class Bank :BaseClass 
    {
        public string BankName { get; set; }
        public  DateTime UpdatedDate { get; set; }
        public virtual ICollection<people> People { get; set; }
    }
}

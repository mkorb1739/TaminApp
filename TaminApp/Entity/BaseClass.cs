namespace TaminApp.Entity
{
    public class BaseClass
    {
        public BaseClass()
        {
            IsActive = true;
            RegisterDate = DateTime.Now;
        }
        public int ID { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public DateTime RegisterDate { get; set; }
      
    }
}

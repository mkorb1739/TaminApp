namespace TaminApp.Entity
{
    public class Degree : BaseClass 
    {
        public  string DegreeName { get; set; } //مدرک تحصیلی 
        public DateTime UpdatedDate { get; set; }
        public virtual ICollection<people> People { get; set; }
    }
}

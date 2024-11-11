namespace TaminApp.Entity
{
    public class DiseaseType : BaseClass 
    {
        public string DiseaseName { get; set; } //نام بیماری
        public DateTime UpdatedDate { get; set; }
        public virtual ICollection<PeopleDiseaseType> PeopleDiseaseTypes { get; set; }
    }
}

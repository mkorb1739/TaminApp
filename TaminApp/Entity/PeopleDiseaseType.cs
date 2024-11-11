namespace TaminApp.Entity
{
    public class PeopleDiseaseType : BaseClass 
    {
        public int PeopleId { get; set; }
        public int DiseaseTypeId { get; set; }
        public DateTime DiseaseDate { get; set; }//مدت زمان بیماری
        public string Description { get; set; }//توضیحات{ get; set; }
        public virtual people People { get; set; }
        public  virtual DiseaseType DiseaseType { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}

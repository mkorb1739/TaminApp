using AutoMapper;
using TaminApp.Entity;
using TaminApp.ViewModels.Bank;
using TaminApp.ViewModels.Degree;
using TaminApp.ViewModels.DiseaseType;
using TaminApp.ViewModels.people;
namespace TaminApp.ExtentionClass

{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            //  Bank
            CreateMap<Bank, BankListViewModel>();
            CreateMap<Bank, BankCreateViewModel >().ReverseMap();
            CreateMap<Bank, BankEditViewModel >().ReverseMap();
            //  Degree
            CreateMap<Degree , DegreeListViewModel >();
            CreateMap<Degree , DegreeCreateViewModel >().ReverseMap();
            CreateMap<Degree , DegreeEditViewModel >().ReverseMap();
            //Disease
            CreateMap<DiseaseType , DiseaseTypeListViewModel >();
            CreateMap<DiseaseType , DiseaseTypeCreateViewModel >().ReverseMap();
            CreateMap<DiseaseType , DiseaseTypeEditViewModel >().ReverseMap();
            //people
            CreateMap<people, PeopleListViewModel>();
            CreateMap<people, PeopleCreateViewModel>().ReverseMap();
            CreateMap<people, PeopleEditViewModel>().ReverseMap();
            CreateMap<Degree, PeopleComboBoxDegreeViewModel >();
            CreateMap<DiseaseType ,PeopleComboBoxDiseaseTypeViewModel >();

        }
    }

}

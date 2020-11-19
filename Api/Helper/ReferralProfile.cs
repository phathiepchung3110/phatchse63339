using AutoMapper;

namespace Api.Helper
{
    public class ReferralProfile : Profile
    { 
        public ReferralProfile()
        {
            // Job
            //JobResquest
            CreateMap<Data.Entities.Job, DTOS.Job.JobRequest>();
            CreateMap<DTOS.Job.JobRequest, Data.Entities.Job>();
            //JobResponse
            CreateMap<DTOS.Job.JobResponse, Data.Entities.Job>();
            CreateMap<Data.Entities.Job, DTOS.Job.JobResponse>();


            //Company
            //CompanyRequest
            CreateMap<Data.Entities.Company, DTOS.Company.CompanyRequest>();
            CreateMap<DTOS.Company.CompanyRequest, Data.Entities.Company>();
            //CompanyResponse
            CreateMap<DTOS.Company.CompanyResponse, Data.Entities.Company>();
            CreateMap<Data.Entities.Company, DTOS.Company.CompanyResponse>();
            //StudentRequest
            CreateMap<Data.Entities.Student, DTOS.Student.StudentRequest>();
            CreateMap<DTOS.Student.StudentRequest, Data.Entities.Student>();
            //StudentResponse
            CreateMap<Data.Entities.Student, DTOS.Student.StudentResponse>();
            CreateMap<DTOS.Student.StudentResponse, Data.Entities.Student>();
        }
    }
}
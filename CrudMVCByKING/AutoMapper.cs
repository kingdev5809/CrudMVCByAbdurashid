using AutoMapper;
using CrudMVCByKING.Models;
using CrudMVCByKING.Models.DTOs;


namespace CrudMVCByKING
{
    public class AutoMapper : Profile
    {
       public AutoMapper() {
            CreateMap<AboutDto,  About> ();
            CreateMap<About , AboutDto> ();
            CreateMap<Comments, CommentsDto> ();
            CreateMap<CommentsDto, Comments>();
            CreateMap<ContactDto, Contact>();
            CreateMap<Contact,  ContactDto> ();
            CreateMap<CoursesDto, Courses>();
            CreateMap<Courses, CoursesDto>()
                             .ForMember(dest => dest.Image, opt => opt.Ignore());
            CreateMap<FaqDto, Faq>();
            CreateMap<Faq,  FaqDto> ();
            CreateMap<Homeworks, HomeworkDto>();
            CreateMap<HomeworkDto, Homeworks>();
            CreateMap<LessonExcerpt,  LessonExcerptDto> ();
            CreateMap<ResultDto, Result>();
            CreateMap<Result, ResultDto>();
            CreateMap<Teachers, TeachersDto>();
            CreateMap<TeachersDto, Teachers>();
            CreateMap<UserDTO, Users>();
            CreateMap<Users, UserDTO > ();
            CreateMap<UserDto, Users>();
            CreateMap<Users, UserDto>();
            CreateMap<LoginDto, Users>();
            CreateMap<Users, LoginDto>();
            CreateMap<Lessons, LessonsDto>();
            CreateMap<LessonsDto ,Lessons>();

        }
    }
}

using AutoMapper;
using TodoApp.Shared.Entities;
using TodoApp.Shared.Models;

namespace TodoApp.BusinessLogic.MappingProfiles
{
    public class TodoProfile : Profile
    {
        public TodoProfile()
        {
            CreateMap<TodoEntity, TodoModel>()
                .ReverseMap();
        }
    }
}

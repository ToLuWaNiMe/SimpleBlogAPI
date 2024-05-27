using AutoMapper;
using SimpleBlogAPI.DTOs;
using SimpleBlogAPI.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // User mappings
        CreateMap<User, UserDTO>();
        CreateMap<UserForRegistrationDTO, User>();
        CreateMap<UserForLoginDTO, User>();

        // Post mappings
        CreateMap<Post, PostDTO>().ReverseMap();

        // Comment mappings
        CreateMap<CommentDTO, Comment>();
        CreateMap<Comment, CommentDTO>();

    }
}

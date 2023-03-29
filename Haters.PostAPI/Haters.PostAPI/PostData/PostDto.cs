using AutoMapper;
using Haters.PostAPI.Common.Mapping;
using Haters.PostAPI.Posts.Commands.CreatePost;

namespace Haters.PostAPI.PostData
{
    public class PostDto : IMapWith<CreatePostCommand>
    {
        public string UserName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PostDto, CreatePostCommand>()
                .ForMember(postCommand => postCommand.Title,
                    opt => opt.MapFrom(postDto => postDto.Title))
                .ForMember(postCommand => postCommand.Content,
                    opt => opt.MapFrom(postDto => postDto.Content))
                .ForMember(postCommand => postCommand.UserName,
                    opt => opt.MapFrom(postDto => postDto.UserName));
        }
    }
}

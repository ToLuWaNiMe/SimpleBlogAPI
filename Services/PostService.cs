using AutoMapper;
using SimpleBlogAPI.DTOs;
using SimpleBlogAPI.Models;
using SimpleBlogAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleBlogAPI.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostService(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PostDTO>> GetAllPostsAsync()
        {
            var posts = await _postRepository.GetAllPostsAsync();
            return _mapper.Map<IEnumerable<PostDTO>>(posts);
        }

        public async Task<PostDTO> GetPostByIdAsync(string id)
        {
            var post = await _postRepository.GetPostByIdAsync(id);
            return _mapper.Map<PostDTO>(post);
        }

        public async Task CreatePostAsync(PostDTO postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            await _postRepository.CreatePostAsync(post);
        }

        public async Task UpdatePostAsync(string id, PostDTO postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            await _postRepository.UpdatePostAsync(id, post);
        }

        public async Task DeletePostAsync(string id)
        {
            await _postRepository.DeletePostAsync(id);
        }
    }
}

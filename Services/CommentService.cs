using AutoMapper;
using SimpleBlogAPI.DTOs;
using SimpleBlogAPI.Models;
using SimpleBlogAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleBlogAPI.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CommentDTO>> GetCommentsByPostIdAsync(string postId)
        {
            var comments = await _commentRepository.GetCommentsByPostIdAsync(postId);
            return _mapper.Map<IEnumerable<CommentDTO>>(comments);
        }

        public async Task<CommentDTO> GetCommentByIdAsync(string id)
        {
            var comment = await _commentRepository.GetCommentByIdAsync(id);
            return _mapper.Map<CommentDTO>(comment);
        }

        public async Task CreateCommentAsync(CommentDTO commentDto)
        {
            var comment = _mapper.Map<Comment>(commentDto);
            await _commentRepository.CreateCommentAsync(comment);
        }

        public async Task UpdateCommentAsync(string id, CommentDTO commentDto)
        {
            var comment = _mapper.Map<Comment>(commentDto);
            await _commentRepository.UpdateCommentAsync(id, comment);
        }

        public async Task DeleteCommentAsync(string id)
        {
            await _commentRepository.DeleteCommentAsync(id);
        }
    }
}

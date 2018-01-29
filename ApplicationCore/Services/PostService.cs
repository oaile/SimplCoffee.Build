using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationCore.Services
{
    public class PostService : IPostService
    {
        private readonly IRepository<Post> _postRepository;

        public PostService(IRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }

        public IEnumerable<Post> GetPosts()
        {
            return _postRepository.ListAll();
        }
    }
}

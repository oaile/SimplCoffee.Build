using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplCoffee.API.Models
{
    public class PostModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
    }
}

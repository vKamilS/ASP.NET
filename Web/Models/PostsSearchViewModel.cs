using Core.Models;

namespace Web.Models
{
    public class PostsSearchViewModel
    {
        public IEnumerable<PostModel> Model { get; set; }
        public int Page { get; set; }
    }
}

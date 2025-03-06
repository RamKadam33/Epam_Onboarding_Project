using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestCharp
{
    
    public class PostModule
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public List<string> Tags { get; set; }
        public Reactions Reactions { get; set; }
        public int Views { get; set; }
        public List<Comment> Comments { get; set; }
        public Metadata Metadata { get; set; }
        public int UserId { get; set; }
    }

    public class Reactions
    {
        public int Likes { get; set; }
        public int Dislikes { get; set; }
    }

    public class Comment
    {
        public int UserId { get; set; }
        public string CommentText { get; set; }
    }

    public class Metadata
    {
        public string PublishedDate { get; set; }
        public Author Author { get; set; }
    }

    public class Author
    {
        public string Name { get; set; }
        public string Profile { get; set; }
    }
}

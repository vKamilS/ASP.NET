﻿namespace KLearn.DataAccess
{
    public class Post
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Edited { get; set; }
    }
}

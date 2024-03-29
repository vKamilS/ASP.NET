﻿namespace Core.Models
{
    public class PostModel
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime? Created { get; set; }
        public string? CreatedAsString { get; set; }
        public DateTime? Edited { get; set; }
        public string? EditedAsString { get; set; }
    }
}

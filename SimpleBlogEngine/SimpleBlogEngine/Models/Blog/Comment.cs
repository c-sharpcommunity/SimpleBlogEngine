﻿using System.ComponentModel.DataAnnotations;

namespace SimpleBlogEngine.Models.Blog
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public int PostId { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }

        //public DateTime CreatedDate { get; set; }
        //public DateTime UpdatedDate { get; set; }

        public virtual Post Post { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EfLearn
{
    public class Blog
    {
        public  int Id { get; set; }
        public  string Title { get; set; }
        public  string Content { get; set; }
        public  DateTime CreateTime { get; set; }
        public List<Post> Posts { get; set; }
        [ForeignKey("Parentid")] 
        public Blog ParentBlog { get; set; }
        public    List<Blog> Blogs { get; set; } 
        
    }
    public class Post
    {
        public  int Id { get; set; }
        public  string Title { get; set; }
        public  string Content { get; set; }
        public  Blog Blog { get; set; }
        public  DateTime CreateTime { get; set; }
    }

    public class BlogPostCount
    {
        public  string Title { get; set; }
        public  int total { get; set; }
    }

    public class UserInfo
    {
        public  int Id { get; set; }
        public  string UserName { get; set; }
        public  string Password { get; set; }
        public  Guid Token { get; set; }
    }
}
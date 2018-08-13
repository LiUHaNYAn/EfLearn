using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace EfLearn
{
    class Program
    {
        static void Main(string[] args)
        {
            
            EfDemoDbContext demoDbContext=new EfDemoDbContext();
            demoDbContext.Blogs.Add(new Blog(){Title = "java 入门必看1",Content = "java 很好的入门系列1",CreateTime = DateTime.Now});
            var data = demoDbContext.BlogPostCounts.OrderByDescending(p => p.total).Skip(1).Take(1).ToList();
            foreach (var postCount in data.ToList())
            {
                Console.WriteLine(postCount.Title+":"+postCount.total);
            }
            demoDbContext.SaveChanges();
            Console.ReadLine();
        }
    }
}
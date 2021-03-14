using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Recycling.Data;
using Recycling.Models;

namespace Recycling.Services
{
    public class NewsService
    {
        private ApplicationDbContext _dbcontext;

        public NewsService(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public List<News> GetAllNewsDesc()
        {
            return _dbcontext.News
                .Where(n => n.Enabled)
                .Include(n => n.Author)
                .Select(n =>
                    new News
                    {
                        Id = n.Id,
                        Author = n.Author,
                        Content = "",
                        CreateTime = n.CreateTime,
                        Enabled = n.Enabled,
                        Replies = new List<Reply>(),
                        Title = n.Title
                    })
                .ToList();
        }

        public News GetNewsById(int id)
        {
            return _dbcontext.News
                .Include(n=>n.Author)
                .Include(n => n.Replies)
                .ThenInclude(r=>r.User)
                .FirstOrDefault(n => n.Id == id);
        }

        public void AddReply(int newsId, Reply reply)
        {
            GetNewsById(newsId).Replies.Add(reply);
            _dbcontext.SaveChanges();
        }
    }
}
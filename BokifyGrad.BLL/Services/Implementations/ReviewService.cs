using BokifyGrad.BLL.DTOs.Reviews;
using BokifyGrad.BLL.Services.Interfaces;
using BokifyGrad.DAL;
using BokifyGrad.DAL.Models;
using Microsoft.EntityFrameworkCore;    
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokifyGrad.BLL.Services.Implementations
{
    public class ReviewService : IReviewService
    {
        private readonly AppDBContext _context;

        public ReviewService(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ReviewDto>> GetForRoom(int roomId)
        {
            return await _context.Reviews
                .Where(r => r.RoomId == roomId)
                .Include(r => r.User)
                .Select(r => new ReviewDto
                {
                    ReviewId = r.ReviewId,
                    UserName = r.User.FullName,
                    Rating = r.Rating,
                    Comment = r.Comment,
                    CreatedAt = r.CreatedAt
                }).ToListAsync();
        }

        public async Task<int> CreateAsync(string userId, CreateReviewDto dto)
        {
            var review = new Review
            {
                RoomId = dto.RoomId,
                UserId = userId,
                Rating = dto.Rating,
                Comment = dto.Comment,
                CreatedAt = DateTimeOffset.UtcNow
            };

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            return review.ReviewId;
        }

        public async Task<bool> DeleteAsync(int id, string userId)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null || review.UserId != userId)
                return false;

            review.IsDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }
    }

}

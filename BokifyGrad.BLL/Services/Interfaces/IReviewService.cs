using BokifyGrad.BLL.DTOs.Reviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokifyGrad.BLL.Services.Interfaces
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewDto>> GetForRoom(int roomId);
        Task<int> CreateAsync(string userId, CreateReviewDto dto);
        Task<bool> DeleteAsync(int id, string userId);
    }

}

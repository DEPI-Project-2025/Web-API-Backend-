using BokifyGrad.BLL.DTOs.Bookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokifyGrad.BLL.Services.Interfaces
{
    public interface IBookingService
    {
        Task<IEnumerable<BookingDto>> GetUserBookings(string userId);
        Task<IEnumerable<BookingDto>> GetAllBookings();
        Task<BookingDto> GetById(int id);
        Task<int> CreateAsync(string userId, CreateBookingDto dto);
        Task<bool> CancelAsync(int id, string userId);
    }

}

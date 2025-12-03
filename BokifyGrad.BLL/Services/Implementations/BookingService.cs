using BokifyGrad.BLL.DTOs.Bookings;
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
    public class BookingService : IBookingService
    {
        private readonly AppDBContext _context;

        public BookingService(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BookingDto>> GetUserBookings(string userId)
        {
            return await _context.Bookings
                .Where(b => b.UserId == userId)
                .Include(b => b.Room)
                .Select(b => new BookingDto
                {
                    BookingId = b.BookingId,
                    RoomId = b.RoomId,
                    RoomNumber = b.Room.RoomNumber,
                    CheckInDate = b.CheckInDate,
                    CheckOutDate = b.CheckOutDate,
                    TotalPrice = b.TotalPrice,
                    Status = b.Status
                }).ToListAsync();
        }

        public async Task<IEnumerable<BookingDto>> GetAllBookings()
        {
            return await _context.Bookings
                .Include(b => b.Room)
                .Select(b => new BookingDto
                {
                    BookingId = b.BookingId,
                    RoomId = b.RoomId,
                    RoomNumber = b.Room.RoomNumber,
                    CheckInDate = b.CheckInDate,
                    CheckOutDate = b.CheckOutDate,
                    TotalPrice = b.TotalPrice,
                    Status = b.Status
                }).ToListAsync();
        }

        public async Task<BookingDto> GetById(int id)
        {
            var b = await _context.Bookings.Include(x => x.Room)
                                           .FirstOrDefaultAsync(x => x.BookingId == id);

            if (b == null) return null;

            return new BookingDto
            {
                BookingId = b.BookingId,
                RoomId = b.RoomId,
                RoomNumber = b.Room.RoomNumber,
                CheckInDate = b.CheckInDate,
                CheckOutDate = b.CheckOutDate,
                TotalPrice = b.TotalPrice,
                Status = b.Status
            };
        }

        public async Task<int> CreateAsync(string userId, CreateBookingDto dto)
        {
            var room = await _context.Rooms.FindAsync(dto.RoomId);
            if (room == null)
                throw new Exception("Room not found");

            // Check availability
            bool notAvailable = await _context.Bookings.AnyAsync(b =>
                b.RoomId == dto.RoomId &&
                b.Status != "Cancelled" &&
                dto.CheckInDate < b.CheckOutDate &&
                dto.CheckOutDate > b.CheckInDate
            );

            if (notAvailable)
                throw new Exception("Room is not available");

            var days = (dto.CheckOutDate - dto.CheckInDate).TotalDays;

            var totalPrice = room.RoomType.BasePrice * (decimal)days;

            var booking = new Booking
            {
                UserId = userId,
                RoomId = dto.RoomId,
                CheckInDate = dto.CheckInDate,
                CheckOutDate = dto.CheckOutDate,
                TotalPrice = totalPrice,
                Status = "Pending",
                CreatedAt = DateTimeOffset.UtcNow
            };


            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return booking.BookingId;
        }

        public async Task<bool> CancelAsync(int id, string userId)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null) return false;
            if (booking.UserId != userId) return false;

            booking.Status = "Cancelled";
            booking.UpdatedAt = DateTimeOffset.UtcNow;
            await _context.SaveChangesAsync();

            return true;
        }
    }

}

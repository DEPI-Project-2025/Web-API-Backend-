using BokifyGrad.BLL.DTOs.Payments;
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
    public class PaymentService : IPaymentService
    {
        private readonly AppDBContext _context;

        public PaymentService(AppDBContext context)
        {
            _context = context;
        }

        public async Task<PaymentDto> GetByBookingId(int bookingId)
        {
            var p = await _context.Payments
                .FirstOrDefaultAsync(x => x.BookingId == bookingId);

            if (p == null) return null;

            return new PaymentDto
            {
                PaymentId = p.PaymentId,
                BookingId = p.BookingId,
                Amount = p.Amount,
                Status = p.Status,
                PaymentDate = p.PaymentDate
            };
        }

        public async Task<int> CreateAsync(CreatePaymentDto dto)
        {
            var booking = await _context.Bookings.FindAsync(dto.BookingId);
            if (booking == null) throw new Exception("Booking not found");

            var payment = new Payment
            {
                BookingId = dto.BookingId,
                Amount = booking.TotalPrice,
                StripeTransactionId = dto.StripeTransactionId,
                Status = "Succeeded",
                PaymentDate = DateTimeOffset.UtcNow,
                CreatedAt = DateTimeOffset.UtcNow
            };

            _context.Payments.Add(payment);
            booking.Status = "Confirmed";

            await _context.SaveChangesAsync();
            return payment.PaymentId;
        }
    }

}

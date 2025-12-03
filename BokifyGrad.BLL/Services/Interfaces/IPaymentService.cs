using BokifyGrad.BLL.DTOs.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokifyGrad.BLL.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<PaymentDto> GetByBookingId(int bookingId);
        Task<int> CreateAsync(CreatePaymentDto dto);
    }

}

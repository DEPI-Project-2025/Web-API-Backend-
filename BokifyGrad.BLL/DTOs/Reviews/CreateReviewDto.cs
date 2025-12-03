using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokifyGrad.BLL.DTOs.Reviews
{
    public class CreateReviewDto
    {
        public int RoomId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}

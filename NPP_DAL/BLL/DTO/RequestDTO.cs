using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class RequestDTO
    {
        public int Id { get; set; }
        public RequestType Type { get; set; }
        public string Reason { get; set; }
        public bool IsVoucher { get; set; }
        public DateTime DurationFrom { get; set; }
        public DateTime DurationTo { get; set; }
    }

    public enum RequestType
    {
        Annual,
        Study,
        Social,
        Creative,
        Unpaid
    }
}

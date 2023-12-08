using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Request
    {
        public int Id { get; set; }
        public RequestType Type { get; set; }
        public string Reason { get; set; }
        public bool IsVoucher { get; set; }
        public DateTime DurationFrom { get; set; }
        public DateTime DurationTo { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
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

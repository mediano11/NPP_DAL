using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Login { get; set; }
        public string DepartmentTitle { get; set; }
        public string PositionTitle { get; set; }
        public string PositionDescription { get; set; }
        public int NPPId { get; set; }

        public IEnumerable<Request> Requests { get; set; }
    }
}

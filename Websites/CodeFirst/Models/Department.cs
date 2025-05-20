using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Models
{
    public class Department
    {
        [Key]
        public int DeptNo { get; set; }

        public string DeptName { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}

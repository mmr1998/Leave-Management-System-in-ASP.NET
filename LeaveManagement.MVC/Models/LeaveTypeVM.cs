using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.MVC.Models
{
    public class LeaveTypeVM : CreateLeaveTypeVM
    {
        public int LeaveTypeId { get; set; }
    }


    public class CreateLeaveTypeVM
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Default Number of Days")]
        public int DefaultDays { get; set; }
    }
}

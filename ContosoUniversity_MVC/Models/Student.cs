using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity_MVC.Models
{
    public class Student
    {
        public int ID { get; set; }
        [Required,StringLength(50),Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required, Display(Name = "First Name"), StringLength(50, ErrorMessage = "First name should not exceed 50 letters")]
        [Column("FirstName")]
        public string FirstMidName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }
        [Display(Name = "Full Name")]
        public string FullName => $"{LastName}, {FirstMidName}";

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
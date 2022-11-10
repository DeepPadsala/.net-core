using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Crud_operation_MVC.Models
{
    public class StudentModel
    {
        [Display(Name="Id")]
        public int Id { get; set; }

        [Required(ErrorMessage ="name is Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "MiddleName is Required")]

        public string MiddleName { get; set; }

        [Required(ErrorMessage = "LastName is Required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "BirthDate is Required")]

        public string BirthDate { get; set; }

        [Required(ErrorMessage = "Coursrname is Required")]

        public string Coursrname { get; set; }

        [Required(ErrorMessage = "city is Required")]

        public string City { get; set; }

        [Required(ErrorMessage ="Address is Required")]
        public string Address { get; set; }
    }
}
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
        public string Name { get; set; }

        [Required(ErrorMessage ="city is Required")]
        public string City { get; set; }

        [Required(ErrorMessage ="Address is Required")]
        public string Address { get; set; }
    }
}
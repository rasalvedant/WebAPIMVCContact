using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class MVCContactModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Phone number not valid. It should be 10 digit.")]
        public int PhoneNumber { get; set; }       
        public bool Status { get; set; }
    }
}
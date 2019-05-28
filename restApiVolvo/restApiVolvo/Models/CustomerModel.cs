using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace restApiVolvo.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Surname {get; set;}

        [Required]
        [RegularExpression(@"^\d{4}\-(0?[1-9]|1[012])\-(0?[1-9]|[12][0-9]|3[01])$")]
        [Display(Name = "Date of Birth")]
        public string Birthdate { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Gender must be specified")]
        public string Gender { get; set; }
    }
}
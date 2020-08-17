using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneApp.API.Models
{
    public class Entry
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }        
        
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$", 
            ErrorMessage = "Please enter a valid phone number eg. 0115551245 / (012)-554-5784")]
        public string PhoneNumber { get; set; }        

    }
}

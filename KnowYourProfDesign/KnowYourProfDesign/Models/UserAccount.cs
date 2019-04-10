using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KnowYourProfDesign.Models
{
    public class UserAccount
    {
        [Key]
        public int UserID { get; set; }
        [Required(ErrorMessage = "Name is required!")]
     
        public string FullName { get; set; }


        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Required(ErrorMessage = "Email is required!")]
        [StringLength(450)]
        [Index(IsUnique = true)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Username is required!")]
        [StringLength(450)]
        [Index(IsUnique = true)]
        public string Username { get; set; }
      
       
        [Required(ErrorMessage = "Password is required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

   
    }
}
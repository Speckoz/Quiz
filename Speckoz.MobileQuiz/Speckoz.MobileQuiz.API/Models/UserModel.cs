using Speckoz.MobileQuiz.Dependencies.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Speckoz.MobileQuiz.API.Models
{
    public class UserModel : IUser
    {
        public int UserID { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public int Level { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

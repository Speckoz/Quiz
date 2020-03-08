using Quiz.Dependencies.Enums;

using System;
using System.ComponentModel.DataAnnotations;

namespace Quiz.Dependencies.Models
{
    public class UserBaseModel
    {
        public Guid UserID { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public int Level { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public UserTypeEnum UserType { get; set; }
    }
}
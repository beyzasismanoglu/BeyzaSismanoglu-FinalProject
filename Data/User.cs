using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace BeyzaSismanoglu_FinalProject.Data
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        public string RoleName { get; set; }
        [Required]

        public string Username { get; set; }
        [Required]

        public string Password { get; set; }

    }
}

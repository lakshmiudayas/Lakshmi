using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineQuiz.Models
{
    public class Login
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Isadmin { get; set; }
    
    }
    public class LoginEntities : DbContext
    {
        public DbSet<Login> login { get; set; }
    }

}
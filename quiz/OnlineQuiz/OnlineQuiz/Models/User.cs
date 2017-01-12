using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineQuiz.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
              
    }
    public class UserData : DbContext
    {
        public DbSet<User> user { get; set; }
    }
}
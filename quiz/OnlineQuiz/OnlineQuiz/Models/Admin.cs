using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineQuiz.Models
{
    public class Admin
    {
        public int ID { get; set; }
        public string Question { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string Answer { get; set; }
        public List<string> OptionList { get; set; }
        public string SelectedAnswer { set; get; }
        public int Score { get; set; }
        
    }
    public class AdminData : DbContext
    {
        public DbSet<Admin> admin { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Person(int id, string name, string username, string password)
        {
            this.Id = id;
            this.Name = name;
            this.Username = username;
            this.Password = password;
        }

    }
}
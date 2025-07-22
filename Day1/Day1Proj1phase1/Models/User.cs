using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1.Proj1phase1.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public User(int id, string name, string role)
        {
            Id = id;
            Name = name;
            Role = role;
        }
        public void DisplayUser()
        {
           Console.WriteLine("Name:" + Name);

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class User
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 100, MinimumLength = 3, ErrorMessage = "Value can't be less than 3")]
        public string Name { get; set; } = null!;

        public override string ToString()
        {
            return $"{Id} -> {Name}";
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1.Models
{
    public class Animal
    {
        public int Id { get; set; }

        [MinLength(20, ErrorMessage = "Value should be greater than 20 characters")]
        public string Color { get; set; } = null!;

        public override string ToString()
        {
            return $"{Id} -> {Color}";
        }
    }
}

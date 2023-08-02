using ConsoleApp1.Contexts;
using ConsoleApp1.Models;
using System.Data.Entity.Validation;
using System.Text;

// Mock connection
var connection = Effort.DbConnectionFactory.CreateTransient();

using var appDbContext = new AppDbContext(connection);

var users = new List<User>
{
    new User { Name = "Diego" },
    new User { Name = string.Empty },
};

var animals = new List<Animal>
{
    new Animal {Color = "Blue"},
    new Animal {Color = "Black"}
};

appDbContext.Users.AddRange(users);
appDbContext.Animals.AddRange(animals);

try
{
    appDbContext.SaveChanges();
}
catch (DbEntityValidationException e) // User friendly error
{
    foreach (var entityError in e.EntityValidationErrors) // For each entity validation
    {
        foreach (var error in entityError.ValidationErrors) // For each error
        {
            var type = entityError.Entry.Entity.GetType();
            var propertyName = error.PropertyName;
            var errorMessage = error.ErrorMessage;
            var propertyValue = entityError.Entry.CurrentValues.GetValue<dynamic>(error.PropertyName); // Note: using dynamic value to get property type at runtime


            var text = new StringBuilder()
                .AppendLine($"Target: {type}.{propertyName}")
                .AppendLine($"Error: {errorMessage}")
                .AppendLine($"Inserted value: {propertyValue}")
                .ToString();
            
            Console.WriteLine(text);
        }
    }
}


foreach (var _ in appDbContext.Users)
{
    Console.WriteLine(_);
}

foreach (var _ in appDbContext.Animals)
{
    Console.WriteLine(_);
}




using Microsoft.AspNetCore.Identity;

public class User
{
    public string Id { get; set; } = "";
    public string UserName { get; set; } = "";
}

class Program
{
    static void Main(string[] args)
    {
        var passwordHasher = new PasswordHasher<User>();
        
        var usersWithPasswords = new[]
        {
            new { Username = "johndoe", Password = "Password123!" },
            new { Username = "janesmith", Password = "Password123!" },
            new { Username = "alexj", Password = "Password123!" }
        };
        
        Console.WriteLine("Generating password hashes for seed data:");
        Console.WriteLine("----------------------------------------");
        
        foreach (var userWithPassword in usersWithPasswords)
        {
            var user = new User { UserName = userWithPassword.Username };
            string passwordHash = passwordHasher.HashPassword(user, userWithPassword.Password);
            
            Console.WriteLine($"User: {userWithPassword.Username}");
            Console.WriteLine($"Password: {userWithPassword.Password}");
            Console.WriteLine($"Hash: {passwordHash}");
            Console.WriteLine("----------------------------------------");
        }
        
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
using Instagram_Backend.Requests;
using Xunit;

namespace UnitTest.TestData;

public class RegisterUserValid : TheoryData<RegisterRequest>
{
    public RegisterUserValid()
    {
        Add(new RegisterRequest { 
            Email = "test1@example.com", 
            UserName = "testuser1",
            FirstName = "Test", 
            LastName = "User", 
            Password = "P@ssword1", 
            ConfirmPassword = "P@ssword1" 
        });
        
        Add(new RegisterRequest { 
            Email = "john.doe@example.com", 
            UserName = "johndoe",
            FirstName = "John", 
            LastName = "Doe", 
            Password = "StrongP@ss2", 
            ConfirmPassword = "StrongP@ss2" 
        });
        
    }
}

public class RegisterUserInvalid : TheoryData<RegisterRequest >
{
    public RegisterUserInvalid()
    {
        Add(
            new RegisterRequest { 
                Email = "", 
                FirstName = "Test", 
                LastName = "User", 
                Password = "P@ssword1", 
                UserName = "testuser1",
                ConfirmPassword = "P@ssword1" 
            }
        );
        
        Add(
            new RegisterRequest { 
                Email = "invalid-email", 
                FirstName = "Test", 
                LastName = "User", 
                Password = "P@ssword1", 
                UserName = "testuser1",
                ConfirmPassword = "P@ssword1" 
            }
        );
        
        Add(
            new RegisterRequest { 
                Email = "test@example.com", 
                FirstName = "Test", 
                LastName = "User", 
                Password = "P@ssword1", 
                UserName = "testuser1",
                ConfirmPassword = "DifferentP@ssword" 
            }
        );
        
    }
}
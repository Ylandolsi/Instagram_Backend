using Xunit;
using Moq ;
using Instagram_Backend.Requests;
namespace UnitTest.TestData;

public class LoginValid : TheoryData<LoginRequest>
{
    public LoginValid (){
        Add(new LoginRequest{
            Email = "MeTesting@gmail.com",
            Password = "P@ssword1"
        });
    }
}
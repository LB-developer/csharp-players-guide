namespace Challenges.PartTwo;

public class PasswordValidator
{

    public IsValid(string password)
    {
        int passwordLength = password.Length;
        if (passwordLength < 6 || passwordLength > 13)
        {
            Console.WriteLine("Password must be between 6 and 13 characters long.");
            return false;
        }

    }

}

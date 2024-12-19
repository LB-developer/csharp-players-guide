namespace Challenges.PartTwo;

public class PasswordValidator
{

    public bool IsValid()
    {
        string password = "";

        do
        {
            Console.Write("Enter a password for validation: ");
            password = Console.ReadLine() ?? "";

        } while (!CheckLength(password) && !CheckCasing(password));

        Console.WriteLine("That password is valid!");
        return true;
    }

    private bool CheckLength(string password)
    {
        int passwordLength = password.Length;
        if (passwordLength < 6 || passwordLength > 13)
        {
            Console.WriteLine("Password must be between 6 and 13 characters long.");
            return false;
        }

        return true;
    }

    private bool CheckCasing(string password)
    {
        string response = "";
        int uppercaseLetters = 0;
        int lowercaseLetters = 0;
        int digits = 0;

        foreach (var character in password)
        {
            if (char.IsUpper(character))
            {
                uppercaseLetters++;
            }
            else if (char.IsLower(character))
            {
                lowercaseLetters++;
            }
            else if (char.IsDigit(character))
            {
                digits++;
            }

        }

        Console.WriteLine(uppercaseLetters);
        Console.WriteLine(lowercaseLetters);
        Console.WriteLine(digits);

        if (uppercaseLetters >= 1 && lowercaseLetters >= 1 && digits >= 1)
        {
            return true;
        }

        if (uppercaseLetters < 1)
        {
            response += "A valid password needs at least 1 uppercase letter (A-Z) \n";
        }
        if (lowercaseLetters < 1)
        {
            response += "A valid password needs at least 1 lowercase letter (a-z) \n";
        }
        if (digits < 1)
        {
            response += "A valid password needs at least 1 digit (0-9) \n";
        }

        Console.WriteLine(response);
        return false;
    }

}

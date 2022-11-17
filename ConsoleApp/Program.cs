using ConsoleApp;
using System.Reflection.Emit;
using System.Text;


string constant = string.Empty; ;
char[] digits;
StringBuilder notdigits;

Console.WriteLine("Kaprekar Constant");
Console.WriteLine("-----------------");
Console.WriteLine("Version 1.2.0.0");
Console.WriteLine(string.Empty);

Console.WriteLine("-----------------" +
    "\n Format:" +
    "\n Only digits are allowed." +
    "\n All digits should NOT be same." +
    "\n Only first four characters will be taken into consideration. ");

repeat:
do
{
    notdigits = new StringBuilder();

    Console.WriteLine("-----------------");
    Console.Write("Enter 4 digits: ");

    constant = Console.ReadLine();
    digits = constant.Take(4).ToArray();
    
    //first four characters must be digits
    foreach (char item in digits)
    {
        if (!char.IsDigit(item))
        {
            notdigits.AppendLine($"'{item}' is not a digit.");
        }
    }

    //all digits must not be same e.g. 1111 , 2222
    if (string.Join("", digits).Replace(string.Join("", digits)[0] + "", "") == "")
    {
        notdigits.AppendLine($"All digits cannot be same.");
    } 

    if (notdigits.Length == 0)
    {
        Console.WriteLine($"\n The {string.Join("", digits)} digits are received.");
    }
    else
    {
        Console.WriteLine(notdigits.ToString());
        Console.WriteLine("Please follow the instructions and try again.");
        Console.WriteLine(string.Empty);
    }

} while (notdigits.Length != 0);

bool isKaprekarConstant = false;
char[] checkDigits = digits;
int count = 1;
while (!isKaprekarConstant)
{
    Console.WriteLine($"\nAttempt #{count.ToString()}: ");
    Console.WriteLine("------------");

    var asc = Utilities.Ascending(checkDigits);
    var desc = Utilities.Descending(checkDigits);

    Int32 value = desc - asc;

    Console.WriteLine($"Descending: {desc.ToString()}");
    Console.WriteLine($"Ascending: {asc.ToString()}");
    Console.WriteLine($"Answer: {value.ToString()}");

    if (value == 6174)
    {
        isKaprekarConstant = true;
    }
    else
    {
        checkDigits = value.ToString().ToCharArray();
        count++;
    }

    if (count>=20)
    {
        break;
    }
}

Console.WriteLine("\n---------------------------------------------------------------");
Console.WriteLine($"The {string.Join("", constant.Take(4))} digits takes {count.ToString()} attempts to reach to Kaprekar Constant.");
Console.WriteLine("---------------------------------------------------------------\n\n");

goto repeat;
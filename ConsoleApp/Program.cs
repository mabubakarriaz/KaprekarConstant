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
    "\n Double digits should not be same. " +
    "\n non-digits values will generate error." +
    "\n Only first four characters will be taken into consideration");

repeat:
do
{
    notdigits = new StringBuilder();

    Console.WriteLine("-----------------");
    Console.Write("Enter 4 digits: ");

    constant = Console.ReadLine();
    digits = constant.Take(4).ToArray();

    foreach (char item in digits)
    {
        if (!char.IsDigit(item))
        {
            notdigits.AppendLine($"'{item}' is not a digit.");
        }
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

    Array.Sort(checkDigits);
    var asc = Convert.ToInt32(string.Join("", checkDigits));

    Array.Reverse(checkDigits);
    var desc = Convert.ToInt32(string.Join("", checkDigits));

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
}

Console.WriteLine("\n---------------------------------------------------------------");
Console.WriteLine($"The {string.Join("", constant.Take(4))} digits takes {count.ToString()} attempts to reach to Kaprekar Constant.");
Console.WriteLine("---------------------------------------------------------------\n\n");

goto repeat;
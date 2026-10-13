public class Program
{
    public static void Main(string[] args)
    {
        int lines = 0;
        while (true)
        {
            Console.Write("Enter number of persons: ");
            if (int.TryParse(Console.ReadLine(), out lines) && lines > 0)
            {
                break;
            }
            Console.WriteLine("Invalid input! Please enter a valid number.");
        }

        var persons = new List<Person>();

        for (int i = 0; i < lines; i++)
        {
            try
            {
                Console.Write($"Enter person {i + 1} (FirstName LastName Age Salary): ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input)) continue;

                var cmdArgs = input.Split();

               
                if (cmdArgs.Length < 4)
                {
                    throw new ArgumentException("Invalid input! Please provide FirstName, LastName, Age, and Salary.");
                }

                var person = new Person(
                    cmdArgs[0],
                    cmdArgs[1],
                    int.Parse(cmdArgs[2]),
                    decimal.Parse(cmdArgs[3])
                );
                persons.Add(person);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                i--;
            }
        }

        Console.Write("Enter bonus percentage: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal bonus))
        {
            Console.WriteLine("\n--- Results ---");
            persons.ForEach(p => p.IncreaseSalary(bonus));
            persons.ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}
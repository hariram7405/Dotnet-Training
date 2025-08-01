
namespace Assessment.Utilities
{
    public static class InputHelper
    {
        public static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int result))
                    return result;
                Console.WriteLine("Invalid input! Please enter a number.");
            }
        }

        public static string ReadNonEmptyString(string prompt)
        {
            while (true)
            {
                if (!string.IsNullOrWhiteSpace(prompt))
                    Console.Write(prompt);

                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                    return input.Trim();

                Console.WriteLine("Input cannot be empty.");
            }
        }
    }
}

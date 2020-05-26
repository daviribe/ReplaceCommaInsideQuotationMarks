using System;
using System.IO;
using System.Text;

namespace ConsoleApp
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var fileText = new StreamReader("file.csv", Encoding.UTF8).ReadToEnd();
            var stringBuilder = new StringBuilder();

            var line = 0;
            var isInsideQuotationMarks = false;

            foreach (var currentChar in fileText)
            {
                if (currentChar == '\n')
                {
                    line += 1;
                    Console.WriteLine($"Processing Line {line}");
                };

                if (isInsideQuotationMarks && currentChar == ',')
                    stringBuilder.Append(" |");
                else
                    stringBuilder.Append(currentChar);

                if (isInsideQuotationMarks && currentChar == '\"') isInsideQuotationMarks = false;
                else if (isInsideQuotationMarks == false && currentChar == '\"') isInsideQuotationMarks = true;
            }

            File.WriteAllText("file_transformed.csv", stringBuilder.ToString(), Encoding.UTF8);
        }
    }
}

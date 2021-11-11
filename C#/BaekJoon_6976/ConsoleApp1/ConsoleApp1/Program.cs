using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            String input_removeCount = Console.ReadLine();

            String input_number = Console.ReadLine();
            ulong result = Convert.ToUInt64(input_number);
            while (true)
            {
                if (result <= 11)
                {
                    if (result == 11)
                    {
                        Console.WriteLine("The number " + input_number + " is divisible by 11.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("The number " + input_number + " is not divisible by 11.");
                        break;
                    }
                }
                else
                {
                    String temp = result.ToString();
                    if (temp.Length >= 0)
                    {
                        temp = temp.Substring(0, temp.Length - 1);
                        String temp_lastnum =
                            temp.Substring(temp.Length - 1, int.Parse(input_removeCount));

                        result = Convert.ToUInt64(temp) - Convert.ToUInt64(temp_lastnum);
                        Console.WriteLine(result);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
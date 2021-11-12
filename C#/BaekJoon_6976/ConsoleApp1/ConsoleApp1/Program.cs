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
                        Console.WriteLine("The number {0} is divisible by 11.", input_number);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("The number {0} is not divisible by 11.", input_number);
                        break;
                    }
                }
                else
                {
                    String temp = result.ToString();
                    String temp_lastnum = "";
                    if (temp.Length >= 0)
                    {
                        try
                        {
                            temp = temp.Substring(0, temp.Length - 1);
                            temp_lastnum =
                                temp.Substring(temp.Length - 1, int.Parse(input_removeCount));
                        }
                        catch
                        {
                            Console.WriteLine("You are Error");
                            break;
                        }
                        finally
                        {
                            result = Convert.ToUInt64(temp) - Convert.ToUInt64(temp_lastnum);
                            Console.WriteLine(result);
                        }
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
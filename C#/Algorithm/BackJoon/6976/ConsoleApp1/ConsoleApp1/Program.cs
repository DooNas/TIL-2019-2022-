//using System;

//namespace ConsoleApp1
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            String input_removeCount = Console.ReadLine();
//            String input_number = Console.ReadLine();

//            ulong result = Convert.ToUInt64(input_number);  //String to ulong
//            while (true)
//            {
//                if (result <= 99)   //check 99 ~ 0
//                {
//                    if (result == 11) //if didvisable 11
//                    {
//                        Console.WriteLine("The number " + input_number + " is divisible by 11.");
//                        break;
//                    }
//                    else //if not didvisable 11
//                    {
//                        Console.WriteLine("The number " + input_number + " is not divisible by 11.");
//                        break;
//                    }
//                }
//                else //check 100 ~ N
//                {
//                    String temp = result.ToString();    //ulong to String
//                    int lastindex = Int32.Parse(input_removeCount);
//                    if (result.ToString().Length <= 0)  //Check ArgumentOutOfRange
//                    {
//                        break;
//                    }
//                    else
//                    {
//                        String temp_Delelastnum = temp.Substring(0, temp.Length - 1);
//                        String temp_Justlastnum = temp.Substring(temp.Length - 1, lastindex);

//                        result =
//                            Convert.ToUInt64(temp_Delelastnum) - Convert.ToUInt64(temp_Justlastnum); //Rewrite
//                        Console.WriteLine(result);
//                        //return to take result(ulong)
//                    }
//                }
//            }
//        }
//    }
//}
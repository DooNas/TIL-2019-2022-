using System;

namespace baekjoon
{
    class Program
    {
        static void Main(string[] args)
        {
            int num;
            int Tennum;
            int Onenum;
            int settemp;
            int resultnum;

            int count = 1;
            Console.Write("두자리 정수 입력 : ");
            num = Convert.ToInt32(Console.ReadLine());

            if (0 <= num && num < 100)
            {
                resultnum = num;
                while (true)
                {
                    Tennum = num / 10;
                    Onenum = num % 10;
                    settemp = Tennum + Onenum;
                    num = ((num % 10) * 10) + (settemp % 10);
                    if (resultnum == num)
                    {
                        break;
                    }
                    count++;
                }
            }
            Console.Write(count);
        }
    }
}
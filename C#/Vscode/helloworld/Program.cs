using System;

namespace baekjoon
{
    class no5597
    {
        static void Main(String[] args)
        {
            int[] list = new int[30];
            for(int i = 0; i < 28; i++)
            {
                int num = Convert.ToInt32(Console.ReadLine());
                list[num-1] = 1;
            }
            
            for(int i = 0; i < 30; i++)
            {
                if(list[i] != 1) Console.WriteLine(i+1);
            }
        }
    }
}
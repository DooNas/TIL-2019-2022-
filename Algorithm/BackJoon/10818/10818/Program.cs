using System;
/*
 * 첫째 줄에 정수의 개수 N (1 ≤ N ≤ 1,000,000)이 주어진다.
 * 둘째 줄에는 N개의 정수를 공백으로 구분해서 주어진다. 
 * 모든 정수는 -1,000,000보다 크거나 같고, 1,000,000보다 작거나 같은 정수이다.
 */
namespace baekjoon
{
    class Program
    {
        static void Main()
        {
            int index;
            String[] slist;
            int[] list;
            while (true)
            {
                index = Convert.ToInt32(Console.ReadLine());    // 정수의 갯수를 입력
                if (1 <= index && index <= 1000000) //범위 체크
                {
                    slist = new String[index];
                    list = new int[index];
                    break;
                }
                else Console.WriteLine("범위를 벗어났습니다.");
            }

            String inputlist = Console.ReadLine();
            slist = inputlist.Split(' ');

            for(int jndex = 0; jndex < slist.Length; jndex++)
            {
                list[jndex] = Convert.ToInt32(slist[jndex]);
            }
            Array.Sort(list);
            Console.WriteLine($"{list[0]} {list[list.Length-1]}");
        }
    }
}
using System;
using System.Collections.Generic;

class Program
{
    public static void Main()
    {
        int[] people = {50, 70, 50, 80};
        Console.WriteLine(solution(people, 100));
    }


    public static int solution(int[] people, int Limit)
    {
        int Count = 0;

        Array.Sort(people);
        int light = 0;
        int heavy = people.Length - 1;

        while(light <= heavy)
        {
            if(people[light] + people[heavy] <= Limit)
            {
                light++;
            }
            heavy--;
            Count++;
        }
        return Count;
    }


}
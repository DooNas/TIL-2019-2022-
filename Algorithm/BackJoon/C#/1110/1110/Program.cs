using System;

namespace baekjoon
{
    /* 0 <= N < 100 인 두자리 정수 N을 입력받는다면
     * if N = 26일 때,
     *      2 + 6 = 8   >> 68       Count = 1
     *      6 + 8 = 14  >> 84       Count = 2
     *      8 + 4 = 12  >> 42       Count = 3
     *      4 + 2 = 6   >> 26       Count = 4
     *      
     *      출력 : 4
     *      
     *      입력 예시 26, 55, 1, 0, 71
     *      
     *      일의 자리?
     *      0 + 1 = 1   >> 11
     *      1 + 1 = 2   >> 12
     *      ....
     *      
     *      0 + 0 = 0   >> 0
     */
    class Program
    {
        
        static void Main()
        {
            string inputNum = Console.ReadLine(); // 처음 입력값

            int count = 0; // 반복될 횟수가 저장될 변수
            int addNum; // 첫째자리와 둘째자리가 더해진 값이 저장될 변수

            if (10 > int.Parse(inputNum)) // 10보다 작을때 0을 붙여 두 자리 수로 만들기
            {
                inputNum = inputNum + 0; //"string 값" + "0" 은 문자열로 붙게됨
                                         // "9" + 0 = "90" 
            }
            string originalNum = inputNum; // 저장될 원본 입력값

            while (true)
            {
                count++;
                int a = int.Parse(inputNum) / 10; // 십의 자리
                int b = int.Parse(inputNum) % 10; // 일의 자리
                addNum = a + b; // 십의 자리 + 일의 자리
                inputNum = b.ToString() + (addNum % 10).ToString();

                if (int.Parse(inputNum) == int.Parse(originalNum)) break;

                Console.WriteLine($"{a} + {b} = {addNum}\t{inputNum} = {originalNum}\t\tCount = {count}"); //과정 확인용
            }
            Console.WriteLine(count); // 반복된 횟수 
        }
    }
}
// To-do
/*
 * 왜 내 코드만 안되나 싶었는데 2번 꼬았다. 10이하의 정수의 경우 다른 식으로 계산하고
 * 계산 한것을 비교할 때도 다른 식으로 비교해야한다.
 * 그럼 왜 처음에 끝나지 않았을까
 */
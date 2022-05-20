package backjoon;

import java.util.Scanner;

public class no2577 {
    public void ansower(){
        Scanner sc = new Scanner(System.in);
        int num_A,num_B,num_C,Sum;
        String sSum;

        num_A = sc.nextInt();
        num_B = sc.nextInt();
        num_C = sc.nextInt();
        Sum = num_A * num_B * num_C;

        sSum = Integer.toString(Sum);
        for (int Number=0; Number < 10; Number++) {
            int Count = 0;
            for (int index = 0; index < sSum.length(); index++) {
                String num = String.valueOf(sSum.charAt(index));
                int Check = Integer.parseInt(num);
                if(Check == Number) Count++;
            }
            System.out.println(Count);
        }
    }
}

package backjoon;

import java.util.Scanner;

public class no2562 {
    public void ansower(){
        Scanner sc = new Scanner(System.in);

        int[] arr = new int[9];
        int max = 0;
        int max_index = 0;

        for (int index = 0; index < 9; index++){
            int input = sc.nextInt();
            if(max < input) {
                max = input;
                max_index = index + 1;
            }
            arr[index] = input;
        }
        System.out.println(max);
        System.out.println(max_index);
    }
}

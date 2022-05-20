package backjoon;

import java.util.Scanner;


public class no4344 {
    public void ansower(){
        Scanner scan = new Scanner(System.in);

        int Trying = scan.nextInt();

        double[] Ansower = new double[Trying];
        int[] list;
        for(int Count = 0; Count < Trying; Count++){
            int Students = scan.nextInt();
            list = new int[Students];

            double sum = 0;

            for(int index= 0; index < Students; index++){
                int score = scan.nextInt();
                list[index] = score;
                sum += score;
            }

            double averg = sum / Students;
            double count = 0;
            for(int index = 0; index < Students; index++){
                if(list[index] > averg){
                    count++;
                }
            }

            Ansower[Count] = (count / Students) * 100;
        }
        for (double num : Ansower) {
            System.out.printf("%.3f%%\n",num);
        }
    }
}

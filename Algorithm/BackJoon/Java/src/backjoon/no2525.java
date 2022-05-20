package backjoon;

import java.util.Scanner;

public class no2525 {
    public void ansower(){
        Scanner sc = new Scanner(System.in);
        int hours = sc.nextInt();
        int minutes = sc.nextInt();
        int Counts = sc.nextInt();
        minutes += Counts;

        if(minutes != 0){
            if(minutes > 60){
                hours += minutes / 60;
                minutes = minutes % 60;
            }
        }
        if(hours > 23) hours = hours % 24;
        System.out.printf("%d %d", hours, minutes);
    }
}

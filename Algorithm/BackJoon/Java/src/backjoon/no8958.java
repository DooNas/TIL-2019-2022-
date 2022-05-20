package backjoon;

import java.util.Scanner;
import java.lang.String;

public class no8958 {
    public void ansower(){
        Scanner scan = new Scanner(System.in);

        int count = scan.nextInt();
        String[] oxlist= new String[count];
        for (int index = 0; index < count; index++){
            oxlist[index] = scan.next();
        }

        for(int index = 0; index < count; index++){
            String ox = oxlist[index];

            int score = 0;
            int Bounce = 0;
            for(int jndex = 0; jndex < ox.length(); jndex++){
                if(ox.charAt(jndex) == 'O'){
                    Bounce++;
                }else{
                    Bounce = 0;
                }
                score += Bounce;
            }
            oxlist[index] = Integer.toString(score);
        }

        for (String num: oxlist
             ) {
            System.out.println(num);
        }

    }
}

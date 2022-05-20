package backjoon;

import java.util.*;

public class no2480 {
    public void ansower(){
        Scanner input = new Scanner(System.in);

        int a = input.nextInt();
        int b = input.nextInt();
        int c = input.nextInt();

        int sum = 0;

        if ( a == b && b == c) sum = 10000 + a * 1000;
        else if ( a == b || b == c || a == c){
            if( a == b ) sum = 1000 + a * 100;
            else if( a == c) sum = 1000 + c * 100;
            else if( b == c) sum = 1000 + b * 100;
        }else{
            if(a < b){
                if(b < c) sum = c * 100;
                else sum = b * 100;
            }else{
                if(a < c) sum = c * 100;
                else sum = a * 100;
            }
        }
        System.out.print(sum);
        input.close();
    }
}

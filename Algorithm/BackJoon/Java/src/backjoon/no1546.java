package backjoon;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.StringTokenizer;

public class no1546 {
    public void ansower() throws IOException {
        try {
            BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
            StringTokenizer st = new StringTokenizer(br.readLine(), " ");
            int size = Integer.parseInt(br.readLine());
            double Average[] = new double[size];


            for (int index = 0;  index < Average.length; index++){
                Average[index] = Double.parseDouble(st.nextToken());
            }

            double sum = 0;
            for (double num : Average)sum += num;
            sum = sum / size;
            System.out.print(sum);

        }catch (NumberFormatException e){
            e.getMessage();
        }

    }
}


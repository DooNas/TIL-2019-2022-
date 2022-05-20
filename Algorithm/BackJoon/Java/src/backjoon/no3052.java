package backjoon;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.HashSet;

public class no3052 {
    public void ansower() throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));

        // 자바 콜랙션의 set - hashset
        HashSet<Integer> h = new HashSet<Integer>();

        for(int index = 0; index < 10; index++)
            h.add(Integer.parseInt(br.readLine()) % 42);

        System.out.print(h.size());
    }
}

import apl.linearlist;
import backjoon.*;

import java.io.IOException;
import java.util.Scanner;

public class Main {
    public static void main(String[] args){
//        no10926 no10926 = new no10926();
//        no10926.ansower();
//        no18108 no18108 = new no18108();
//        no18108.ansower();
//        no2525 no2525 = new no2525();
//        no2525.ansower();
//        no2480 no2480 = new no2480();
//        no2480.ansower();
//        no2562 no2562 = new no2562();
//        no2562.ansower();
//        no2577 no2577 = new no2577();
//        no2577.ansower();
//        no3052 no3052 = new no3052();
//        no3052.ansower();
//        no1546 no1546 = new no1546();
//        no1546.ansower();
//        no8958 no8958 = new no8958();
//        no8958.ansower();
//        no4344 no4344 = new no4344();
//        no4344.ansower();

        linearlist list = new linearlist(100);
        list.AddElements(1);
        list.AddElements(2);
        list.AddElements(3);
        list.AddElements(5);
        list.AddElements(5);
        //list = {1,2,3,5,5}
        list.printAll();
        list.RemoveElement(1); // 2를 삭제
        //list = {1,3,5,5}
        list.printAll();
        list.GetElement(3); //5를 출력

    }
}

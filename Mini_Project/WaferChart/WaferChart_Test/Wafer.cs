using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaferChart_Test
{
    public class Wafer
    {
        static int last_WafNum;  //가장 최근에 부여한 웨이퍼 일련번호
        readonly int wafNum;    //웨이퍼 일련번호

        int[] cells = new int[100]; //하나의 웨이퍼에는 총 100개의 셀이 존재
        int now;    //현재 코팅중인 셀번호

        public Wafer()//기본생성자
        {
            last_WafNum++;
            wafNum = last_WafNum;   //웨이퍼 번호 순차 부여
        }

        public int Now  //가져오기 - 속성(now)
        {
            get { return now; }
        }
       public bool Increment()  //메서드 - 셀 증가
        {
            if(now < 100)
            {
                now++;
                if(now == 100) return false;
                return true;
            }
            return false;
        }
        public void Coating(int quality)    //메서드 - 셀 코팅 퀄리티 설정
        {
            if(Now < 100) cells[Now] = quality;
        }
        public int this[int index]  //가져오기 - 속성(cells[index])
        {
            get
            {
                if ((index < 0) || (index >= 100)) return 0;
                return cells[index];
            }
        }
        public double Quality // 가져오기 - 속성(quality)
        {
            get
            {
                int sum = 0;
                foreach (int elem in cells) sum += elem;
                return sum / 100.0;
            }
        }

        public override string ToString()   //메소드(재정의) - 웨이퍼번호&평균품질을 문자열로 반환
        {
            return String.Format($"No : {wafNum},\t Quality : {Quality}");
        }
    }
}

package apl;

public class linearlist {
    int[] intArr;   //int형 배열
    int count;      //메모리 크기
    int Arrsize;

    public linearlist(int size){
        count = 0;      //0부터 시작
        Arrsize = size;
        intArr = new int[Arrsize]; //크기 선정
    }

    public void AddElements(int num){
        if(count >= Arrsize){   //만약 지정된 메모리를 초과할 경우
            System.out.println("메모리를 초과했습니다.");
            return;
        }
        intArr[count++] = num;  //순차적으로 값을 저장
        //현재 메모리크기 저장
    }

    public void InSertElements(int position, int num){
        int index;
        if(count >= Arrsize){   //만약 지정된 메모리를 초과할 경우
            System.out.println("넣을 공간이 없습니다.");
            return;
        }
        if(0 > position || position > count){ //위치 선정을 잘못할 경우
            System.out.println("잘못된 장소입니다.");
            return;
        }
        for(index = count - 1; index >= position; index--){
            intArr[index+1] = intArr[index];    //하나씩 뒤로 이동
        }
        intArr[position] = num;
        count++;    //현재 메모리크기 저장
    }

    public void RemoveElement(int position){
        if(isEmpty()){  // 만약 삭제할 메모리가 없다면
            System.out.println("삭제할 메모리가 없습니다.");
            return;
        }
        if(position < 0 || position >= count){  //만약 삭제할 자리에 아무것도 없다면
            System.out.println("삭제할 메모리가 없습니다.");
            return;
        }
        for(int index = position; index < count -1; index++){
            intArr[index] = intArr[index+1];    // 하나씩 앞으로 이동
        }
        count--; //현재 메모리크기 저장
        return;
    }

    public void GetElement(int position){
        if(position < 0 || position > count - 1){
            System.out.println("검색 범위에 없습니다. 현재 리스트의 크기는 "+count+"입니다.");
            return;
        }
        System.out.println("해당 "+position+"번째 인덱스에 저장된 메모리는 "+intArr[position]+"입니다.");
        return;
    }

    public boolean isEmpty()
    {
        if(count == 0){
            return true;
        }
        else return false;
    }

    public void printAll()
    {
        if(count == 0){
            System.out.println("출력할 내용이 없습니다.");
            return;
        }
        for(int i=0; i<count; i++){
            System.out.print(intArr[i]+ " ");
        }
        System.out.println();
    }

}

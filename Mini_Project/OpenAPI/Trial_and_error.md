## C#
> 수업중에 들은 공공 데이터 모델을 파이썬이 아닌 C#을 통해 실천 가능한지 확인하고자 실행해 보자.  
[.Net을 활용한 OpenApi](./Civ19_WithCsharp)  
# _시행착오 기록 구간_




## `2021-11-23` 
  * [공공데이터포털](https://www.data.go.kr/)에서 원하는 [코로나바이러스](https://www.data.go.kr/tcs/dss/selectApiDataDetailView.do?publicDataPk=15043376)를 찾아 활용신청을 하고 키를 받았다.
  * 사용하면서 키가 오픈되어 있어 삭제처리해두었다.
  * [테스트](./Civ19_WithCsharp_Test)를 통해 OpenApi가 _Xml_형태로 받아짐을 알 수 있었다.
      ## 결과물
      ![Xml출력 확인물](https://user-images.githubusercontent.com/40691856/143234613-6ebda773-4a10-4448-8daf-f4bfb680a133.PNG)
    > 문제 없음! 이제 이걸 가공하는 것만 남았다!

## `2021-11-24`
  * xml에서 파싱하는 법에 대해 구글링을 해보았다.
    * 자꾸 실패한다.
---
## `2021-11-25`
  * xml에서 파싱하기 보단 xml을 json으로 변환하여 `[키 : 값]`형태로  
    진행하는 것이 더 좋을 것이라고 판단해서 구글링을 해보았다.
    * 먼저 인터넷에서 찾은 [블로그](https://ggmouse.tistory.com/207)에서의 코드를 참고해봤다.  
    해당 부분에서 필요없는 부분을 걸러내고 다듬어서 만들었다.
      ```csharp
         public static String XmltoJson(string results)
          {
            XmlDocument XmFile = new XmlDocument();
            XmFile.LoadXml(results);
            JsonConvert.SerializeXmlNode(XmFile);
            string jsonStr = JsonConvert.SerializeXmlNode(XmFile, Newtonsoft.Json.Formatting.None, true);
            return jsonStr;
          }
      ```
      _실패했다._  
  
  * 앞의 아이디어를 참고해서 원인을 분석해보니 `newtonsoft.json.dll`이 없기 때문에 해당 클래스가 없다고 인식하는 것이라 [사이트](newtonsoft.json.dll)를 통해 파일을 받아 참조를 해보았다.


  * 원하는 대로 가공되어 출력이 되었다.
      ## 결과물
      ![XmltoJson_Test](https://user-images.githubusercontent.com/40691856/143390358-e0cc7da3-7214-44ec-ad04-17ffc4661753.PNG)
        

  * Json형태로 파싱된 출력자료를 정리해보았다.
    ![자료 정리](https://user-images.githubusercontent.com/40691856/143413517-69724cc0-67b7-45c9-b732-43f5b7bfc4ab.PNG)  
    원하는 값은 그날 확진자수 `decideCnt`의 값을 얻는 것이다.
      
    또 실패.. 자꾸 `Jsonreaderexception`라고 뜨면서 오류가 생긴다.
    > 왜 오류가 생기는 것일까?  
    > Xml에서 Json으로 바꾸면서 바뀐 데이터를 내가 추적할 수 없는 거 같다.  
    > 사실 좀더 자세한 원인이 있는거 같지만 현재 내 코드를 보고 생각할 수 있는 여건은 바꾼 데이터를 추적할 수 없다는 뜻인거 같다.
      

  * 다시 초심으로 돌아와 Xml에서 파싱하는 법을 찾아보았다.  
    [Xml 파싱 테스트](./xml_parsing_Test)을 따로 만들어서 Xml파일에서 파싱하는 것을 최우선의 목표로 잡았다. 

    * [XmlNodeList](https://docs.microsoft.com/ko-kr/dotnet/api/system.xml.xmlnodelist?view=net-6.0)  
    * [XmlDocument](https://docs.microsoft.com/ko-kr/dotnet/api/system.xml.xmldocument?view=net-6.0)
    차분하게 참고한 결과 성공적이였다.
    ![Xml 파싱 테스트_결과](https://user-images.githubusercontent.com/40691856/143458735-9a23de28-dca1-4f17-93f3-6804302f95ad.PNG)  
      
      

  * 성공한 양식을 토대로 [.Net을 활용한 OpenApi](./Civ19_WithCsharp)에 적용해 보았다.
    ## 결과물
    ![Xml 파싱](https://user-images.githubusercontent.com/40691856/143459390-8bb7c1b9-84e0-4e29-8f60-ec36d46772e9.PNG)
---
## `2021-11-26`
  *  OpenApi를 추출하는 과정에서 차트를 위한 7일치 데이터를 얻고자 손보았지만,  
     1일치 데이터만 넘어오면서 `NullReferenceException`오류가 발생했다.
     
     * 비동기식 처리를 해보았다.  
       ```
       public async Task<String> OpenApiGetFile(int day, String key)
       ```
       분할한 `OpenApiGetFile`클래스를 비동기화 해보았다.
       덤으로, `static`처리에서 메인 클래스에서 `new`연산자를 통해 선언하도록 바꿨다.
  
       실패했다.
     * 혹시나 하는 마인드로 `foreach`문에서 `for`문으로 `index`를 가져와 진행하고,  
       문제의 날짜 데이터의 경우 `if`문을 통해 없으면 반복문을 `return`하도록 조치했다.  

       ## 결과물
       ![데이터 추출 확인](https://user-images.githubusercontent.com/40691856/143587964-815ce99b-6392-4ec8-a331-ac379bf51244.PNG)

---
## `2021-11-27`
  * 버튼상호작용시 상호작용 금일날짜를 기준으로 7일치 데이터를 자동으로 가져오기 위해 `DateTime`을 활용하여 수정해보았다.  
    이제 데이터는  
    > `if. 2021-11-27에 실행시`   
    > ```
    > createDt[] = {'2021-11-27', '2021-11-26', '2021-11-25', '2021-11-24', '2021-11-23', '2021-11-20', '2021-11-19' };  
    >  
    > decidate[] = {436968, 432900, 429000, 425062, 420947, 418249, 415422, 412302, 409097}
    >```
    이런 식으로 저장되어 보관된다.
    이걸 `DataTable`로 저장한 다음 `Chart`에 적용하면 이번 프로젝트는 끝날거 같다.
  * XmlParsing클래스를 String과 int형으로 가져올 수 있도록 분할해 두었다.  
    만약, String으로 가져올 경우 가져올 범위도 선택할 수 있도록 해두었고,  
    DataTable에도 무사히 넣는데도 일사천리였다.

       ## 결과물
       ![DataTable로 저장한 형태](https://user-images.githubusercontent.com/40691856/143685503-b6e1c250-2bf0-40ce-8e80-99c986fc5746.PNG)
  
---  
## `2021-11-28`
  * dataTable로 저장된 값을 차트화 보았다.  
    한가지 문제점은 오픈아이피에서 값을 가져올때마다 7개가 아닌 1개만 가져올 경우 오류가 생기는데 이부분의 경우는  
    ```if (!string.IsNullOrEmpty(createDt[1]))```를 활용해서 다음 자리가 공백일 경우 진행되지 않도록 조치함으로써 해결했다.  
    다만, 차트활용에 대해 지식이 부족해서 `dataTable`을 활용하기보단 갖고 있는 배열을 활용해서 시도해보았다.

    임시방편으로 차트화 하는데 성공했다.  
    이제 남은건 UI를 꾸미는 일인 것 같다.

    차트에 관해서는 좀더 찾아봐야 겠다.  
       ## 결과물
       ![캡처](https://user-images.githubusercontent.com/40691856/143771713-57c4ff58-0b75-41ea-b16d-0c843435ee13.PNG)
---  
## `2021-11-29`
  * 색갈로 구별되기를 원해서 확진자라는 Sries[]안에 날짜 Series들로 구성해보았다.
       ## 결과물
       ![캡처](https://user-images.githubusercontent.com/40691856/143823718-482313e7-6bc0-452f-a21b-9c008a78c460.PNG)  
       그렇게 괜찮아 보이지 않는다.
       역시 같은 같아도 날짜별로 구별되는 것이 보기 좋을거 같다.

  *  좀더 깔끔한 UI를 위해 `fontawesome.sharp`을 참조했다.
  *  또한, [WinForm상단바 제거](https://github.com/DooNas/TIL/tree/main/Mini_Project/ChangeFormDesign/ChangeFormDesign)를 활용해서 꾸며 보았다.
       ## 결과물
       ![UI수정](https://user-images.githubusercontent.com/40691856/143848687-858cf241-5a9a-445f-bcbc-e810d1daa51f.PNG)  
       다만, 아시운 부분은 저기 내부의 배경색을 어떻게 고쳐가 괜찮게 될지 잘 모르겠다.  
       이부분은 새로 추가할 기능을 넣으면서 조사해볼 생각이다.
---  
## `2021-11-30`
  * 진짜로 차트부분은 이제 더이상 건드릴 부분이 없다고 생각한다.  
    전날 고민이였던 내부 배경색도 해결하고, 이미 찾는 대상은 `확진자`뿐이라  
    이부분도 `visiable`처리할 수 있어서 보는 사람 입장에서 깔끔한 모습이 나왔다.
       ## 결과물
       ![UI_차트 수정 마무리](https://user-images.githubusercontent.com/40691856/144030976-b99b34f7-8cfa-47c2-86dc-4713e4af4aec.PNG)

  * 하단에 추가한 `기간고르기`라는 기능을 어떻게 넣을까 고민이다.  
    아니면 해당 부분을 범위로 지정해서 불러오기를 하는 것도 괜찮을거 같다.  
---  
## `2021-12-01`
  * 차트 중심인 만큼 드래그를 통한 범위 조정으로 선택을 했다.  
    드래그의 경우 트랙바(trackBar)를 통해 해결할 수 있지반 보조눈금을 지울 방법을 몰라 `panel`을 활용해서 가림으로써  
    `UI`는 끝이 났다.  
    남은 것은 기존에 Array로 활용하던 `createDt[]`, `decidate[]`의 크기를 트랙바와 연동하여 크기가 되도록 하면서  
    드디어 [.Net을 활용한 OpenApi](./Civ19_WithCsharp)가 마무리 되었다.
       # 완성작
    ![End](https://user-images.githubusercontent.com/40691856/144242628-b9c510a4-918c-462d-85e5-34a8a6671e51.gif)  
    
     >## ETC.
     >  완성된 [.Net을 활용한 OpenApi](./Civ19_WithCsharp)을 보고  
     >   혹시 Form Controll부분을 분할클래스로 활용하여 유지보수에 용의하도록 할 수 없는지 궁금증이 생겼다.  
     >   왜냐면, 이것보다 많은 량의 UI를 다루게 된다면 분할은 필수적일 것이라고 생각해  
     >   구글링을 해보았다.
     >   `partial`을 활용하여 MainFrom을 연동하는 것 같지만 생각보다 나의 뜻대로 되지 않는다.  
     >   그래서 더 찾아보니 `.csproj`라는 설정 파일을 통해 visual Studio의 탐색목록에 보이는 요소를 바꾸는 것이 있어  
     >   그것이 필수인 줄 알았지만 그것은 그냥 미관상으로 보기 편하게 하는 것이였다...
     >     
     >   결국 방법을 몰라 다음기회로 기억해둬야겠다.
---

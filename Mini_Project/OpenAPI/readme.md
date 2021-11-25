# OpenApi를 활용해서 프로그램 제작

## C#
> 수업중에 들은 공공 데이터 모델을 파이썬이 아닌 C#을 통해 실천 가능한지 확인하고자 실행해 보자.  
[.Net을 활용한 OpenApi](./Civ19_WithCsharp)  
### _시행착오 기록 구간_
* 2021-11-23  
  * [공공데이터포털](https://www.data.go.kr/)에서 원하는 [코로나바이러스](https://www.data.go.kr/tcs/dss/selectApiDataDetailView.do?publicDataPk=15043376)를 찾아 활용신청을 하고 키를 받았다.
  * 사용하면서 키가 오픈되어 있어 삭제처리해두었다.
  * [테스트](./Civ19_WithCsharp_Test)를 통해 OpenApi가 _Xml_형태로 받아짐을 알 수 있었다.
  
  ## 결과물
  ![Xml출력 확인물](https://user-images.githubusercontent.com/40691856/143234613-6ebda773-4a10-4448-8daf-f4bfb680a133.PNG)
  > 문제 없음! 이제 이걸 가공하는 것만 남았다!

* 2021-11-24
  * xml에서 파싱하는 법에 대해 구글링을 해보았다.
    * 자꾸 실패한다.
  
* 2021-11-25
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
      실패했다.  


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
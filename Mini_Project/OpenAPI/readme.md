# OpenApi를 활용해서 프로그램 제작
> Why?  
> 수업중에 들은 공공 데이터 모델을 파이썬이 아닌 C#을 통해 실천 가능한지 확인하고자 실행해 보자.  
[.Net을 활용한 OpenApi](./Civ19_WithCsharp)  
# 프로젝트 기간  
* ## 전체 기간 : [`21.11.23 ~ 21.12.01 (9일)`](Trial_and_error.md)  
  * ### 개발 환경 세팅 : `1`일
  * ### 백엔드 : `3`일
  * ### DB : `2`일
  * ### UI 및 프론트엔드 : `3`일

# IDE
* ## [Visual Studio 2022](https://visualstudio.microsoft.com/ko/launch/)
  * ### [C# .Net](https://docs.microsoft.com/ko-kr/dotnet/)
    > #### _참조_
    > [newtonsoft.json.dll](newtonsoft.json.dll)  
    > [Newtonsoft.Json](https://www.newtonsoft.com/json) 
* ## [공공 데이터 포털](https://www.data.go.kr/)
  * ### [공공데이터활용지원센터_보건복지부 코로나19 감염 현황](https://www.data.go.kr/tcs/dss/selectApiDataDetailView.do?publicDataPk=15043376)

# 기획
딱히 장대한 계획은 없었다.  
튜터링 시간에 배운 OpenApi를 활용하는 법을 파이썬으로만 배워서 그것을 다른 언어로도 가능한지 궁금했던 점과  
동시에 마침 전공에 차트와 관련된 수업을 하던 것이 C#수업이었다.  
그래서 C#으로 평소 휴대폰으로 보던 금일 확진자 증가수 표를 참고해서 그래도 카피캣을 목표로 시작했다.
> ## 참고이미지
> ![카톡_코로나확진자차트](https://user-images.githubusercontent.com/40691856/144428972-8fcc9715-ec55-413b-9b73-80b3423a215b.jpg)

> ## 완성작
> ![End](https://user-images.githubusercontent.com/40691856/144242628-b9c510a4-918c-462d-85e5-34a8a6671e51.gif) 
  
# 플로우 차트
  




# 코드 리뷰
* Program.cs
  * `Main()`
* MainForm.cs
  * `InitializeComponent()`
  * `CheckData(bool Message = false)`
  * `Datatable(String[] createDt, int[] decideCnt, int length)`
  * `CoivChart(Datatable dt)`
  * Event
    * `Tb_Term_Scroll(object sender, EventArgs e)`
    * `Btn_Search_Click(object sender, EventArgs e)`
  * Top_Bar Custom
    * `panelTop_MouseUp(object sender, MouseEventArgs e)`
    * `panelTop_MouseDown(object sender, MouseEventArgs e)`
    * `panelTop_MouseMove(object sender, MouseEventArgs e)`
    * `panelTop_MouseMove(object sender, EventArgs e)`
    * `Btn_Minmon(object sender, EventArgs e)`
    * `Btn_Close(object sender, EventArgs e)`
* [OpenApi.cs](#openapi.cs)
  * `OpenApiGetData(String key, int length)`
  * `Todate()`
  * `datebefore(int length)`
  * `DataToXml(String results)`
  * `XmlParsing_StringArray(String[] array, int length, int Start, int End, String node)`
  * `XmlParsing_IntArray(int[] array, int length, String node)`
* ## Key.cs
  * ### `GetKey()`


# OpenApi.cs

## `OpenApiGetData(String key, int length)`
이번 프로젝트의 메인으로써 [공공 데이터 포털](https://www.data.go.kr/)에서 Xml을 파싱해오는 역할을 하는 메서드입니다.
```csharp
static HttpClient client = new HttpClient();

public async Task<String> OpenApiGetData(String key, int length)
        {
            //데이터 호출(Xml)
            string url = "http://openapi.data.go.kr/openapi/service/rest/Covid19/getCovid19InfStateJson"; // URL
            url += "?ServiceKey=" + key; // Service Key
            url += "&pageNo=1";
            url += "&numOfRows=" + (length + 1).ToString();
            url += "&startCreateDt=" + datebefore(length);
            url += "&endCreateDt=" + Todate();

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            //String results = string.Empty;
            HttpWebResponse response ;
            using(response =request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                results = reader.ReadToEnd();
            }
            return results;
        }
```  
기본적인 틀은 [공공 데이터 포털](https://www.data.go.kr/)에서 받아온 소스를 가급적 유지하는 방향으로 갔습니다.

```cs
static HttpClient client = new HttpClient();
```
> `HttpClient`객체타입의 client변수에 `HttpClient`객체를 `New`연산자를 통해 저장합니다.
  
```cs
public async Task<String> OpenApiGetData(String key, int length)
```
> 원래 기존의 코드의 경우,  
> ```cs
> public String OpenApiGetData(String key, int length)
> ```
> `String`형을 반환하는 메서드였지만,  
> 이후에 차트로 데이터를 가져오는 과정에서 자꾸 데이터가 누락되었기 때문에  
> 이에 대한 원인을  
> ` request.Method = "GET";`를 통해 가져오는 과정이 완료되지 않았음에도 넘어가면서 데이터가 온전히 넘어오지 못한다고 생각했습니다.  

_계속 코딩을 하면서 사실 데이터 호출부분에서 제가 실수한 부분때문에 값이 2페이지로 나뉘어 출력되었습니다._  
_그래도 비동기와 동기가 어떤 식이고,_  
_동기처리동안 빈자리의 변수는 어떤식으로 선언되는지 알 수 있어 보존해두었습니다._  
> `Key`의 경우, [공공 데이터 포털](https://www.data.go.kr/)에서 인증키를 받아오기 때문에  
> 혹시모를 불상사를 위해 따로 분류하여 깃허브에는 올라가지 않도록 무시처리해두었습니다.  
> `length`는 원하는 기간의 `Xml`을 추출할 수 있도록 선언해 둔 매개변수입니다.
```cs
            //데이터 호출(Xml)
            string url = "http://openapi.data.go.kr/openapi/service/rest/Covid19/getCovid19InfStateJson"; // URL
            url += "?ServiceKey=" + key; // Service Key
            url += "&pageNo=1";
            url += "&numOfRows=" + (length + 1).ToString();
            url += "&startCreateDt=" + datebefore(length);
            url += "&endCreateDt=" + Todate();
```
> `HttpWebResponse`로 받아올 주소를 만드는 파트이다.  
> [공공 데이터 포털](https://www.data.go.kr/)에서 XML을 파싱하는 방법이다.  
```cs
string url = "http://openapi.data.go.kr/openapi/service/rest/Covid19/getCovid19InfStateJson"; 
```
> [코로나바이러스](https://www.data.go.kr/tcs/dss/selectApiDataDetailView.do?publicDataPk=15043376)관련 데이터를 가져오는 링크이다.  
```cs
            // URL
            url += "?ServiceKey=" + key; // Service Key
```
> 깃허브에 올라가지 않도록 조치한 `인증키`를 받는 자리이다.
```cs
            url += "&pageNo=1";
            url += "&numOfRows=" + (length + 1).ToString();
            url += "&startCreateDt=" + datebefore(length);
            url += "&endCreateDt=" + Todate();
```
> 이부분은 데이터를 가져오는데 필수적으로 입력해야하는 조건들이다.  
> * `pageNo` : `출력되는 페이지 수`
>   * 이부분은 앞에서 `비동기&동기`를 찾는 계기였다. 2페이지로 구성하면 데이터가 넘어갈 수 있기 때문에  
>     1페이지로 고정해둔다.
>  
> * `numOfRows` : `해당 페이지에 출력되는 데이터 갯수`
>    * `numOfRows`에 허용된 량을 넘어서면 `pageNo`의 페이지수가 증가한다.  
>      따라서, 내가 원하는 기간에 따라 값이 변할 수 있도록 ` + (length + 1).ToString();` 을 적용했다.  
>      _원하는 기간 + 1_ 을 한 이유는 XMl에서 가져올 수 있는 정보는 금일 확진자가 아닌 총합 확진자 수이기 때문에  
>      전날과 비교해서 값을 구해야 하기 때문에 하루를 더 가져오는 방식을 골랐다.
>  
> * `startCreateDt` : `가져올 데이터의 시작 날짜  --ex)  20211113`
>   * 이부분은 다음에 나올 `datebefore`메서드를 통해 데이터 수를 조정했다.
>
> * `endCreateDt` : `가져올 데이터의 마지막 날짜  --ex)  20211120`
>   * `Todate()`메서드를 통해 프로그램을 실행한 금일 날짜를 기준으로 조정했다.
```cs
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            //String results = string.Empty;
            HttpWebResponse response ;
            using(response =request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                results = reader.ReadToEnd();
            }
            return results;
```
> 이부분은 나도 잘 모른다.  
> 다만, `HttpWebRequest`을 통해 [공공 데이터 포털](https://www.data.go.kr/)에서 파싱한 것을 `String`형으로 `results`에 저장하고 최종적으로 `results`값을 반환하는 것으로 알고 있다.

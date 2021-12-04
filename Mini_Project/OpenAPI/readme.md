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
<p align="center"><img src="https://user-images.githubusercontent.com/40691856/144711204-ee9e1447-2f9b-471f-ace0-e6552eb757ce.png"></p>


---
---
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
* OpenApi.cs
  * `OpenApiGetData(String key, int length)`
  * `Todate()`
  * `datebefore(int length)`
  * `DataToXml(String results)`
  * `XmlParsing_StringArray(String[] array, int length, int Start, int End, String node)`
  * `XmlParsing_IntArray(int[] array, int length, String node)`
* ## Key.cs
  * ### `GetKey()`

---
---
# Program.cs
* ## `Main()`
  실행을 위한 메인 클래스입니다.
```cs
static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
```
`Application` 클래스는 윈도우 응용 프로그램을 시작 / 종료 시키는 메서드를 제공하고 윈도우 메시지를 처리합니다.
```cs
Application.EnableVisualStyles();
```
> Form의 형태를 결정하는 요소이다.
```cs
Application.SetCompatibleTextRenderingDefault(false);
```
> `WinForm` 컨트롤들의 `UseCompatibleTextRendering`속성에 대한 기본값을 설정하는 역할이다.
> 현재로써는 사용할 이유가 없기 때문에 `False`값을 주었다.
``` cs
Application.Run(new MainForm());
```
> 앞으로 사용할 `Form`을 실행 시킨다.

</br></br></br>
# MainForm.cs
* ## `InitializeComponent()`
  `WinForm`의 외형을 구현하는 것과 동시에 관련 객체를 선언하는 메소드입니다.
```cs
    ... 양이 많은 관계로 스킵하겠습니다.
```

</br></br></br>
* ## `CheckData(bool Message = false)`
  필요한 부분을 파싱한 Xml데이터를 DataTable타입의 변수에 저장하기 위해 배열에 저장하는 메소드이다.  
```cs
private async void CheckData(bool Message = false)
        {
            Thread.Sleep(100);
            OpenApi openApi = new OpenApi();
            String results = await openApi.OpenApiGetData(ApiKey.Getkey(), length);
            openApi.DataToXml(results); //Make Civ19.xml

            try
            {
                String[] createDt = new string[length + 1];
                openApi.XmlParsing_StringArray(createDt, length, 5, 5, "createDt");

                int[] decideCnt = new int[length + 1];
                openApi.XmlParsing_IntArray(decideCnt, length, "decideCnt");
                if (Message)
                {
                    string message = lb_StartDate.Text + " ~ " + lb_EndDate.Text + "\n불러왔습니다.";
                    MessageBox.Show(message);
                }

                Datatable(createDt, decideCnt, length);

                if (!string.IsNullOrEmpty(createDt[1]))
                {
                    CoivChart(dt);
                }

            }
            catch (ArgumentException ex) { MessageBox.Show("XML 문제 발생\r\n" + ex); }
            catch (NullReferenceException ex) { MessageBox.Show("OpenApi호출문제 발생\r\n" + ex); }
        }
```
  `bool Message`를 통해 버튼을 통한 상호작용 이 아닌 경우와 상호작용을 통한 실행 여부를 결정한다.
  ```cs
  private async void CheckData(bool Message = false)
  ```
  > 가져올 데이터가 비동기 `async`임으로 이를 활용하는 메소드 역시 동일하게 부여했다.  
  > 또한, Xml을 배열에 저장하는 만큼 자주 사용하기 때문에 중복되는 기능을 최소하 하고자  
  > 메세지의 출력 여부를 선택할 수 있도록 했다.
  ```cs
            Thread.Sleep(100);
            OpenApi openApi = new OpenApi();
            String results = await openApi.OpenApiGetData(ApiKey.Getkey(), length);
            openApi.DataToXml(results); //Make Civ19.xml
  ```
  > `Thread.Sleep(100)`의 경우 초창기 데이터를 가져오는 부분에서 여유를 갖고자 임의로 지정한 것이다.  
  > 이후에도 크게 문제가 없어서 방치했는데 크게 의미는 없다.  
  > `OpenApi openApi = new OpenApi();`를 통해 `OpenApi`객체를 선언하고  
  > 전체 Xml데이터를 파싱해온다. 이때 전체 데이터의 범위는 `length` 값에 따라 달라진다.
  > 최종적으로는 `Civ19.xml`이라는 파일이 생성된다.
  ```cs
            try
            {
                String[] createDt = new string[length + 1];
                openApi.XmlParsing_StringArray(createDt, length, 5, 5, "createDt");

                int[] decideCnt = new int[length + 1];
                openApi.XmlParsing_IntArray(decideCnt, length, "decideCnt");
                if (Message)
                {
                    string message = lb_StartDate.Text + " ~ " + lb_EndDate.Text + "\n불러왔습니다.";
                    MessageBox.Show(message);
                }

                Datatable(createDt, decideCnt, length);

                if (!string.IsNullOrEmpty(createDt[1]))
                {
                    CoivChart(dt);
                }

            }
            catch (ArgumentException ex) { MessageBox.Show("XML 문제 발생\r\n" + ex); }
            catch (NullReferenceException ex) { MessageBox.Show("OpenApi호출문제 발생\r\n" + ex); }
  ```
  > String형 변수들은 `XmlParsing_StringArray()`메소드를 통해 저장하고. Int형 변수들은 `XmlParsing_IntArray()`메소드를 통해 저장한다.  
  > 이과정에서 만약 `Message`의 값이 `True`일 경우,  전체 데이터의 범위를 메세지로 출력한다.  
  > 아닐 경우에는 해당 과정을 스킵한다.   
  > 완성된 배열들은 `Datatable(createDt, decideCnt, length);`메소드를 통해 `Datatable`형 변수에 저장된다.  
  > `if (!string.IsNullOrEmpty(createDt[1]))`의 경우 금일 확진자수를 확인하기 위해서  데이터의 범위는 최소 2개 이상이다.  
  > 따라서 불러온 데이터가 1개일 경우에는 `CoivChart(dt);`은 실행되지 않도록 합니다.  
  > `catch (ArgumentException ex) { `은 값을 벗어나는 경우에 대한 예외처리입니다.  
  > `catch (NullReferenceException ex) {`은 값이 없을 경우에 대한 예외처리입니다.

</br></br></br>
* ## `Datatable(String[] createDt, int[] decideCnt, int length)`
  배열 값을 `Datatable`형의 전역변수 `dt`에 저장하는 메서드이다.
```cs
private void Datatable(String[] createDt, int[] decideCnt, int length)
        {
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("날짜", typeof(string)));
            dt.Columns.Add(new DataColumn("확진자", typeof(int)));
            for (int index = 0; index < length; index++)
            {
                String D_day = createDt[index+1];
                String TodaydecideCnt = (decideCnt[index + 1] - decideCnt[index]).ToString();
                if (D_day == null)  //if 더이상 출력할 요소가 없다면 종료.
                {
                    return;
                }
                dt.Rows.Add(D_day, TodaydecideCnt);
            }
        }
```
저장되는 `DataTable`의 형태는 이런 식이다.  
|createDt  |decideCnt|
|------|------|
|테스트1|테스트2|
|테스트1|테스트2|
|테스트1|테스트2|

</br></br></br>
* ## `CoivChart(Datatable dt)`
```cs
private void CoivChart(DataTable dt)//Art Chart
        {
            chart = this.Week_chart;
            chart.Series.Clear();
            var series = chart.Series.Add("확진자");
            series.XValueMember = "날짜";
            series.YValueMembers = "확진자";
            chart.DataSource = dt;
            series.Color = System.Drawing.Color.FromArgb(
                                                            ((int)(((byte)(240)))), 
                                                            ((int)(((byte)(084)))), 
                                                            ((int)(((byte)(084))))
                                                            );
            chart.DataBind();
            chart.Visible = true;
        }
```

</br></br></br>
* ## Event 
  * ## `Tb_Term_Scroll(object sender, EventArgs e)`
    ```cs
    private void Tb_Term_Scroll(object sender, EventArgs e)
            {
                OpenApi openApi = new OpenApi();
                length = tb_Term.Value;
                if(length < 10) lb_date.Text = " " + length.ToString() + "일";
                else lb_date.Text = length.ToString() + "일";
                lb_StartDate.Text = DateTime.Now.AddDays(-length).ToShortDateString();
            }
    ```
    
    </br></br></br>
  * ## `Btn_Search_Click(object sender, EventArgs e)`
    ```cs
    private void Btn_Search_Click(object sender, EventArgs e)
            {
                CheckData(true);
            }
    ```
    
    </br></br></br>
* ## Top_Bar Custom
  > From의 기본 틀을 제거하는 대신 사라진 상단바를 대신하기 뒤한 전역 변수들입니다.
   ```cs
   bool isMove;
   int MouseX, MouseY;
   ```
  * ## `panelTop_MouseUp(object sender, MouseEventArgs e)`
    ```cs
        private void panelTop_MouseUp(object sender, MouseEventArgs e)
                {
                  isMove = false;
                }
    ```
    
    </br></br></br>
  * ## `panelTop_MouseDown(object sender, MouseEventArgs e)`
    ```cs
        private void panelTop_MouseDown(object sender, MouseEventArgs e)
                {
                  isMove = true;
                  MouseX = e.X;
                  MouseY = e.Y;
                }
    ```
    
    </br></br></br>
  * ## `panelTop_MouseMove(object sender, MouseEventArgs e)`
    ```cs
        private void panelTop_MouseMove(object sender, MouseEventArgs e)
                {
                  if (isMove == true)
                    {
                        this.SetDesktopLocation(MousePosition.X - MouseX, MousePosition.Y - MouseY);
                    }
                }
    ```

    </br></br></br>
  * ## `Btn_Minmon(object sender, EventArgs e)`
    ```cs
        private void Btn_Minmon(object sender, EventArgs e)
                {
                  File.Delete("Civ19.xml");
                  this.Close();
                }
    ```

    </br></br></br>
  * ## `Btn_Close(object sender, EventArgs e)`
    ```cs
        private void Btn_Close(object sender, EventArgs e)
                {
                  this.WindowState = FormWindowState.Minimized;
                }
    ```


</br></br></br>
# OpenApi.cs
* ## `OpenApiGetData(String key, int length)`
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
> 다만, `HttpWebRequest`을 통해 [코로나바이러스](https://www.data.go.kr/tcs/dss/selectApiDataDetailView.do?publicDataPk=15043376)에서 파싱한 것을 `String`형으로 `results`에 저장하고 최종적으로 `results`값을 반환하는 것으로 알고 있다.  

</br></br></br>
  
* ## `Todate()`
 `OpenApiGetData(String key, int length)`에 보낼 `endCreateDt`날짜를 보내는 메소드이다.
```cs
public String Todate() //금일 기준 7일전 날짜
        {
            String date = DateTime.Now.AddDays(-1).ToShortDateString();
            date = String.Join("", date.Split('-'));
            return date;
        }
```
금일 기준으로 `DataTime`형의 `2021-12-03`을 보낼 수 있도록 `20211203`형태로 바꾸어 보내주는 메소드이다.
> [코로나바이러스](https://www.data.go.kr/tcs/dss/selectApiDataDetailView.do?publicDataPk=15043376)에서 파싱되는 값은 최신값이 금일 기준으로 전날 데이터뿐이라 금일에서 하루를 뺌으로써 유지한다.

</br></br></br>
  
* ## `datebefore(int length)`
 `OpenApiGetData(String key, int length)`에 보낼 `startCreateDt`날짜를 보내는 메소드이다.
```cs
public String datebefore(int length) //금일 기준 7일전 날짜
        {
            String date = DateTime.Now.AddDays(-(length+1)).ToShortDateString();
            date = String.Join("",date.Split('-'));
            return date;
        }
```
금일 기준으로 `DataTime`형의 `2021-11-27`을 보낼 수 있도록 `20211127`형태로 바꾸어 보내주는 메소드이다.
> [코로나바이러스](https://www.data.go.kr/tcs/dss/selectApiDataDetailView.do?publicDataPk=15043376)에서 나오는 값이 총 확진자 수인 만큼 금일 확진자 수를 계하기 위해 입력된 값보다 하루 더 파싱한다.

</br></br></br>
  
* ## `DataToXml(String results)`
`OpenApiGetData(String key, int length)`에서 받은 `results`값을 가져와 `xml`파일로 만든다.
```cs
public void DataToXml(String results)//Make Civ19.xml
        {
            StreamWriter writer;
            writer = File.CreateText("Civ19.xml");
            writer.Write(results);
            writer.Close();
        }
```
> 갖고 있는 Xml에서 데이터를 파싱하는 메소드는 `.xml`파일 한정으로 가능하기 때문에 만든다.  

</br></br></br>
  
* ## `XmlParsing_StringArray(String[] array, int length, int Start, int End, String node)`
`.xml`에서 `node`를 기준으로 원하는 `String`값을 가져온다.
```cs
public void XmlParsing_StringArray(String[] array, int length, int Start, int End, String node)
        {
            //xml에서 어떻게 해야 현제 확진자 수를 추출할 수 있을까?
            XmlDocument xml = new XmlDocument();
            xml.Load("Civ19.xml");

            XmlNodeList xnList = xml.SelectNodes("/response/body/items/item"); //접근할 노드
            int i = length;
            foreach (XmlNode xn in xnList)
            {
                array[i] = xn[node].InnerText.Substring(Start, End); //문자형 node 데이터 추출
                i--;
            }
        }
```
> `Start`와 `End`는 파싱할 데이터의 크기에서 원하는 부분만 가져올 수 있도록 조치한 것이다.

</br></br></br>
  
* ## `XmlParsing_IntArray(int[] array, int length, String node)`
`.xml`에서 `node`를 기준으로 원하는 `int`값을 가져온다.
```cs
public void XmlParsing_IntArray(int[] array, int length, String node)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load("Civ19.xml");

            XmlNodeList xnList = xml.SelectNodes("/response/body/items/item"); //접근할 노드
            int i = length;
            foreach (XmlNode xn in xnList)
            {
                array[i] = int.Parse(xn[node].InnerText); //정수형 node 데이터 추출
                i--;
            }
        }
```
> `XmlParsing_StringArray(String[] array, int length, int Start, int End, String node)`와 다르게  
> 정수형이기 때문에 값의 특정부분을 고를 이유가 없기 때문에 바로 파싱한다.
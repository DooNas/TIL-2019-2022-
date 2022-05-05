async Task<int> AccessTheWebAsync()
{
    HttpClient client = new HttpClient();
     // GetStringAsync는 Task<string>을 리턴. 
        // 기다리면 문자열을 얻는다는 뜻이다. (urlContents).
      Task<string> getStringTask = client.GetStringAsync("https://docs.microsoft.com"); 
        // GetStringAsync로부터 얻는 string 값과 관계 없는 작업을 여기서 진행한다.
      DoIndependentWork(); 
        // await 연산자는 AccessTheWebAsync를 지연시킵니다. 
        // - getStringTask가 완료되기 전에 AccessTheWebAsync를 진행할 수 없습니다.
        // - 그동안 제어권은 호출자인 AccessTheWebAsync로 넘어갑니다. 
        // - getStringTask가 완료되면 제어가 다시 시작됩니다.
        // - await 연산자는 getStringTask로부터 문자열 결과를 가져옵니다.
      string urlContents = await getStringTask; 
        // return 구문은 integer 결과를 명시합니다.
        // AccessTheWebAsync를 기다리는 모든 메서드는 length 값을 가져옵니다.
      return urlContents.Length; 
}
void DoIndependentWork()
{
    String text = "Work.....\r\n";
    Console.WriteLine(text);
}


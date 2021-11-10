# C# 문법 정리

## **C#은 객체지향 언어이다.**

닷넷 프레임 워크라는 실행환경과 조화되어 움직인다.  
즉, 닷넷프레임 워크가 준비되어 있으면 OS와 관계 없이 동작 시킬 수 있다.  
  
_이는 자바의 JVM이 동작하는 것과 비슷한 원리이다._
  
---
## C# 이용 영역
- 콘솔 어플리케이션
- Windows 어플리게이션
   - `.ne`을 통해 만든다.  
- 웹 어플리케이션
   - `asp.net`을 통해 만든다.

_확장자로 .cs로 사욯한다._  
_.cs의 의미는 CSharp(C#)의 줄임말이다._  
  
---
## C# 기본구조  
```csharp
using System;
namespace abc{
    class Hello{
      public static void Main(){
        Console.WriteLine("HelloWorld");
      }
    }
}
```  
1. ```csharp
    using System;
   ```    
   C#을 할때 제일 먼저 선언하는 요소로  
   `Using`은 `NameSpace`타입을 사용할 수 있도록 해줍니다.  
     
   즉, 위의 선언은  
   `System`에 있는 기능들을 사용하겠다는 뜻입니다.

2. ```csharp
    namespace abc{
   ```
   `NameSpace`란 `Using`을 통해  
   선언한 기능들과 관련이 있는 클래스나 메소드, 변수들이 모여있는 공간이라고 보면 됩니다.  
   ~~그래서 명징도 이름있는장소..~~  
   _협업이 필요한 프로젝트에서 중복되는 경우를 방지하고자 고안되었다고 합니다._  
     
   즉, 위의 선언은  

   `System`의 기능을 사용할  
   `NameSpace`의 실별자를 `abc`로 정한다는 뜻입니다.

3. ```csharp
   class Hello{
   ```
   `Class`는 객체지향 언어의 기본 문법이다.
   자세한 내용은 다음기회에..

4. ```csharp
   public static void Main(){
   ```
   프로그램 실행시 실제로 구동될 공간이다.  
   `Java`와 살짝 비슷하게 느껴진다?
5. ```csharp
   Console.WriteLine("HelloWorld");
   ```
   Console.WriteLine();은 C#의 함수로 콘솔출력을 한다.
6. 이후``` }}```을 통해 닫으면 끝
## 결과물
```
HelloWorld
```
---

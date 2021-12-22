# Partial에 대해 알아보자.
> 클래스, 구도체, 인터페이스 또는 메소드의 정의를 둘 이상의 소스파일에 분할 할 수 있다.
> 각 소스파일에는 형식or메소드 정의 섹션이 있으며 모든 부분은 애플리케이션이 컴파일될 때 결합된다.
  

사용되는 대표적인 예시
* 대규모 프로젝트시 클래스를 개별 파일로 분산시  
  여러 프로그래머가 동시에 클래스 작업이 가능해진다.
* 자동으로 생성된 소스로 작업할 경우  
  예를 들어 `Windows Forms`, `웹 서비스 래퍼 코드` 등 처럼  
  코드가 아닌 툴을 통해 자동으로 소스가 생기는 부분을 분할 할 수 있다.

코드로 보면
```csharp
namespace Partical_HowtoUse
{
    public class Car
    {
        private int Num;
        private String Name;
        private String Color;

        public Car()
        {
            Num = 0;
            Name = "Null";
            Color = "Null";
        }
        public Car(int Num, String Name, String Color)
        {
            this.Num = Num;
            this.Name = Name;
            this.Color = Color;
        }
        public void Show()
        {
            Console.WriteLine($"차번호 : {Num}");
            Console.WriteLine($"차종류 : {Name}");
            Console.WriteLine($"차색깔 : {Color}");
        }
        public void ChangeCar(int Num, String Name, String Color)
        {
            this.Num = Num;
            this.Name = Name;
            this.Color = Color;
        }
    }
}
```
로 구성될 클래스가 있다고 한다면 이를 작업하기 편하게 메소드를 분할하여 작업하고자 한다면  
따로 클래스를 하나 더 만들어서 진행할 필요 없이 `partial`을 통해 간략화할 수 있다.

분할하면 이런식으로 된다.

### Car1.cs
```csharp
namespace Partical_HowtoUse
{
    public partial class Car
    {
        public void Show()
        {
            Console.WriteLine($"차번호 : {Num}");
            Console.WriteLine($"차종류 : {Name}");
            Console.WriteLine($"차색깔 : {Color}");
        }
        public void ChangeCar(int Num, String Name, String Color)
        {
            this.Num = Num;
            this.Name = Name;
            this.Color = Color;
        }
    }
}
```
### Car2.cs
```csharp
namespace Partical_HowtoUse
{
    public partial class Car
    {
        private int Num;
        private String Name;
        private String Color;

        public Car()
        {
            Num = 0;
            Name = "Null";
            Color = "Null";
        }
        public Car(int Num, String Name, String Color)
        {
            this.Num = Num;
            this.Name = Name;
            this.Color = Color;
        }
    }
}
```

> 이를 활용해서 Window Form을 다룰때 클래스를 분할하여 코딩해보자!!
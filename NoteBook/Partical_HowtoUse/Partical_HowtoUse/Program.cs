using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partical_HowtoUse
{
    class Program
    {
        static void Main()
        {
            Person p = new Person(1, "Maisam"); //Person1.cs
            p.show();   //Person2.cs
            Console.WriteLine("===============");
            Car c = new Car(1123, "제네시스", "검정");  //Car1.cs
            c.Show();   //Car2.cs
            c.ChangeCar(2213, "카니발", "파랑");
            c.Show();   //Car2.cs
        }
    }
}

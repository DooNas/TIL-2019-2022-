using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

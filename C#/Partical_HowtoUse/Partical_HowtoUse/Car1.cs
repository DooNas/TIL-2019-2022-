using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

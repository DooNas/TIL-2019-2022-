using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Class1
    {
        delegate void MyDelegate(string Name, int age);
        delegate string Message(string message);

        static void Main(string[] args)
        {
            MyDelegate student = (name, age) =>
            {
                Console.WriteLine("이름 : {0}, 나이 : {1}", name, age);
            };

            student("범범조조", 27);

            Message message = (str) => { return str; };
            Console.WriteLine("이름 : {0}", message("범범조조"));

        }
    }
}

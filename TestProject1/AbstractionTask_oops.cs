using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public abstract class Epam
    {
        public abstract void EmpName();
    }
    public class Child : Epam
    {
        public override void EmpName()
        {
            Console.WriteLine("Implemented abstraction");
        }
    }
    class AbstractionTask_oops
    {
        [Test]
        public void abstraction()
        {

            Child obj = new Child();
            obj.EmpName();
        }
    }
}

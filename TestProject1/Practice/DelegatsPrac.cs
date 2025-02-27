using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Practice
{
 delegate T NumberChanger<T>(T n);
    [TestFixture]
    public partial class Genirics
    {
           private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
           static int num = 10;
            public static int AddNum(int p)
            {
                num += p;
                return num;
            }
            public static int MultNum(int q)
            {
                num *= q;
                return num;
            }
            public static int getNum()
            {
                return num;
            }
                [Test]
            public void Genericdelegate()
            {
                //create delegate instances
                NumberChanger<int> nc1 = new NumberChanger<int>(AddNum);
                NumberChanger<int> nc2 = new NumberChanger<int>(MultNum);
                //calling the methods using the delegate objects
                nc1(25);
                Console.WriteLine("Value of Num: {0}", getNum());
                Logger.Info($"Value of Num: {getNum()}");
                nc2(5);
                Logger.Info($"Value of Num: {getNum()}");
                Console.WriteLine($"Value of Num: {getNum()}");

            }
        
    }
}


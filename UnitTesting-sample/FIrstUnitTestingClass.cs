using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting_sample
{
    public class FIrstUnitTestingClass
    {
        public string ReturnMyCurrentScore(int num)
        {
            if (num == 0)
            {
                return "WELCOME LUCAS";
            }
            else
            {
                return "You are not welcome";
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Unit2.Unit2_ex
{
    class Helps
    {
        public static void ChangeState(Button btnStart,bool b1,Button btnStop,bool b2)
        {
            btnStart.IsEnabled = b1;
            btnStop.IsEnabled = b2;

        }
    }
}

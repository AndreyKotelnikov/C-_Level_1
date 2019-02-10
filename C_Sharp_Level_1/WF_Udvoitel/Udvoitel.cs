using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_Udvoitel
{
    class Udvoitel
    {
        
        public static Form1 Form { get; set; }

        public static int ComandCounter { get; set; } = 0;

        internal static int NumberForPlay { get; set; } = 0;
        
        internal static void SetNewNumberForPlay()
        {
            Random rand = new Random();
            NumberForPlay = rand.Next(10, 10000);
        }

        internal static void CheckNumber(string number)
        {
            if (NumberForPlay != 0 && NumberForPlay == int.Parse(number))
            {
                Form.PlayEnd();
            } 
        }
    }
}

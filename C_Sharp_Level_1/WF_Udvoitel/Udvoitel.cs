using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_Udvoitel
{
    static class Udvoitel
    {
        static Stack<int> historyMove = new Stack<int>();

        public static Form1 Form { get; set; }

        public static int LastMove
        {
            get
            {
                if (historyMove.Count > 1) { historyMove.Pop(); return historyMove.Peek(); }
                else return 0;
            }
            set
            {
                historyMove.Push(value);
            }
        } 

        public static int ComandCounter { get; set; } = 0;

        internal static int NumberForPlay { get; set; } = 0;
        
        internal static void SetNewNumberForPlay()
        {
            Random rand = new Random();
            NumberForPlay = rand.Next(3, 40);
        }

        internal static void CheckNumber(string number)
        {
            if (NumberForPlay != 0 && NumberForPlay == int.Parse(number))
            {
                ComandCounter = 0;
                ClearHistory();
                Form.PlayEnd();
            }     
        }

        public static void ClearHistory() => historyMove.Clear();



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    class Repository
    {
        int GuessNumber { get; set; }
        public int UserNumber { get; set; } = -1;
        public int TryCount { get; set; } = 0;
        Form1 Form { get; set; }

        public Repository(Form1 form)
        {
            Random rand = new Random();
            GuessNumber = rand.Next(0, 101);
            Form = form;
        }

        internal void CheckUserAnswer()
        {
            if (UserNumber < 0 || UserNumber > 100) { Form.FilltbMessage(0); }
            else if (UserNumber == GuessNumber) { TryCount++; Form.UserWin(TryCount); }
            else if (UserNumber > GuessNumber) { TryCount++; Form.FilltbMessage(1); }
            else { TryCount++; Form.FilltbMessage(-1); }
        }
    }
}

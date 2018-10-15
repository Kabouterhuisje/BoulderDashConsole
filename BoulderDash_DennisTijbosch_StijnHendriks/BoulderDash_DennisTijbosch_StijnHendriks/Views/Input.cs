using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash_DennisTijbosch_StijnHendriks.Views
{
    public class Input
    {
        private Queue<ConsoleKeyInfo> input;

        public Input()
        {
            input = new Queue<ConsoleKeyInfo>();
        }

        public void queueInput()
        {
            if (Console.KeyAvailable)
            {
                input.Enqueue(Console.ReadKey(true));
            }
        }

        public void waitForInput()
        {
            Console.ReadKey();
        }

        public ConsoleKeyInfo getInputFromQueue()
        {
            return input.Dequeue();
        }
    }
}

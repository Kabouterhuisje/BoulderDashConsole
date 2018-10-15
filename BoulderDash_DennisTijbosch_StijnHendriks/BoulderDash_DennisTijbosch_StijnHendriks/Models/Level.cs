using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace BoulderDash_DennisTijbosch_StijnHendriks.Models
{
    public class Level
    {
        public Block Block { get; set; }
        public Rockford rPosition { get; set; }
        private DateTime startTime;
        private DateTime stopTime;
        private Timer timer;
        private int levelTime;

        // Aangeven hoeveel tijd de speler heeft om level te voltooien
        public Level()
        {
            timer = new Timer();
            levelTime = 150;
        }

        public void startTimer()
        {
            timer.Start();

            if (startTime == null)
            {
                startTime = DateTime.Now;
            }     
            else
            {
                startTime += (DateTime.Now - stopTime);
            } 
        }

        public void stopTimer()
        {
            timer.Stop();
            stopTime = DateTime.Now;
        }

        public double getTimeleft()
        {
            double timeElapsed = (startTime - DateTime.Now).TotalSeconds;
            double timeLeft = levelTime + timeElapsed;

            if (timeLeft < 0)
            {
                rPosition.kill();
            }   
            return levelTime + timeElapsed;
        }

        public void updateAllBlocks(int UpdateGUI)
        {
            Block beginUpdateBlock = Block;
            Block firstBlockInRow = Block;
            Block.Element.trigger(UpdateGUI);

            while (firstBlockInRow.Down != null)
            {
                if (beginUpdateBlock.Right.Element != null)
                {
                    beginUpdateBlock.Right.Element.trigger(UpdateGUI);
                }
                beginUpdateBlock = beginUpdateBlock.Right;

                if (beginUpdateBlock.Right == null)
                {
                    if (firstBlockInRow.Down != null)
                    {
                        firstBlockInRow = firstBlockInRow.Down;
                        beginUpdateBlock = firstBlockInRow;
                        firstBlockInRow.Element.trigger(UpdateGUI);
                    }
                }
            }
        }
    }
}

using BoulderDash_DennisTijbosch_StijnHendriks.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash_DennisTijbosch_StijnHendriks.Models
{
    public class Game
    {
        Level[] levels;
        int currentLevel;
        public Rockford rockford { get; set; }
        public bool isFinished { get; set; }

        public Game()
        {
            isFinished = false;
            loadLevel();
        }

        public void start()
        {
            currentLevel = 0;
            rockford = levels[currentLevel].rPosition;
            getCurrentLevel().startTimer();
        }

        public void addLevel(Level newLevel)
        {
            for (int i = 0; i < levels.Length; i++)
            {
                if (levels[i] == null)
                {
                    levels[i] = newLevel;
                    return;
                }
            }
        }

        public void nextLevel()
        {
            Level oldLevel = levels[currentLevel];
            if (currentLevel >= levels.Length - 1)
            {
                isFinished = true;
                return;
            }
            currentLevel++;
            changeLevel(levels[currentLevel], oldLevel);
        }

        public void previousLevel()
        {
            Level oldLevel = levels[currentLevel];
            if (currentLevel < 1)
            {
                isFinished = true;
                return;
            }
            currentLevel--;
            changeLevel(levels[currentLevel], oldLevel);
        }

        public void changeLevel(Level newLevel, Level oldLevel)
        {
            oldLevel.stopTimer();
            Rockford currentRockfort = oldLevel.rPosition;
            Rockford oldRockfort = newLevel.rPosition;
            Block oldBlock = rockford.block;
            oldRockfort.block.Element = rockford;
            rockford.block = oldRockfort.block;
            oldRockfort.block = oldBlock;
            oldBlock.Element = oldRockfort;
            newLevel.rPosition = currentRockfort;
            oldLevel.rPosition = oldRockfort;
            newLevel.startTimer();
        }

        public Level getCurrentLevel()
        {
            return levels[currentLevel];
        }

        public Block getCurrentStartBlock()
        {
            return levels[currentLevel].Block;
        }

        public void update(int updateGUI)
        {
            getCurrentLevel().updateAllBlocks(updateGUI);
            if (rockford.status == ElementState.Death)
            {
                isFinished = true;
            }   
            if (rockford.status == ElementState.Winning)
            {
                rockford.status = ElementState.Alive;
                rockford.Score += (int)getCurrentLevel().getTimeleft();
                nextLevel();
            }
        }

        // Inladen van levelbestand
        private void loadLevel()
        {
            string[] levels;
            levels = System.IO.Directory.GetFiles("Resources", "*.txt").Select(System.IO.Path.GetFileName).ToArray();
            this.levels = new Level[levels.Length];
            LevelGenerator generator = new LevelGenerator();

            foreach (var level in levels)
            {
                addLevel(generator.createLevel(level));
            }
        }
    }
}

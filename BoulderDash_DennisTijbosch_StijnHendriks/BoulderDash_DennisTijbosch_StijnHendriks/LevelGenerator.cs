using BoulderDash_DennisTijbosch_StijnHendriks.Enums;
using BoulderDash_DennisTijbosch_StijnHendriks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash_DennisTijbosch_StijnHendriks
{
    public class LevelGenerator
    {
        private Block firstBlock;
        private Block lastCreatedBlock;
        private Block firstOfLastRowBlock;
        private bool newLine;
        private int columnIterator;
        private int rowIterator;
        private Rockford rockfordPos;

        public Level createLevel(string path)
        {
            newLine = false;
            columnIterator = 0;
            rowIterator = 0;
            firstBlock = null;
            lastCreatedBlock = null;
            firstOfLastRowBlock = null;
            rockfordPos = null;

            foreach (var line in System.IO.File.ReadAllLines("Resources\\" + path))
            {
                foreach (char c in line)
                {
                    switch (c)
                    {
                        case 'S':
                            connectBlock(blockElementFactory(ElementType.Steelwall));
                            break;
                        case 'B':
                            connectBlock(blockElementFactory(ElementType.Boulder));
                            break;
                        case 'D':
                            connectBlock(blockElementFactory(ElementType.Diamond));
                            break;
                        case 'F':
                            connectBlock(blockElementFactory(ElementType.Firefly));
                            break;
                        case 'M':
                            connectBlock(blockElementFactory(ElementType.Mud));
                            break;
                        case 'R':
                            connectBlock(blockElementFactory(ElementType.Rockfort));
                            break;
                        case 'W':
                            connectBlock(blockElementFactory(ElementType.Wall));
                            break;
                        case ' ':
                            connectBlock(blockElementFactory(ElementType.Block));
                            break;
                        case 'E':
                            connectBlock(blockElementFactory(ElementType.Exit));
                            break;
                        default:
                            break;
                    }
                }
                newLine = true;
            }
            Level returnLevel = new Level();
            returnLevel.Block = firstBlock;
            returnLevel.rPosition = rockfordPos;
            return returnLevel;
        }

        private Block blockElementFactory(ElementType type)
        {
            Block newBlockElement = null;
            switch (type)
            {
                case ElementType.Block:
                    newBlockElement = new Block();
                    break;
                case ElementType.Steelwall:
                    new Steelwall(out newBlockElement);
                    break;
                case ElementType.Exit:
                    new Exit(out newBlockElement);
                    break;
                case ElementType.Wall:
                    new Wall(out newBlockElement);
                    break;
                case ElementType.Mud:
                    new Mud(out newBlockElement);
                    break;
                case ElementType.Boulder:
                    new Boulder(out newBlockElement);
                    break;
                case ElementType.Diamond:
                    new Diamond(out newBlockElement);
                    break;
                case ElementType.Rockfort:
                    Rockford rf = new Rockford(out newBlockElement);
                    rockfordPos = rf;
                    break;
                case ElementType.Firefly:
                    new FireFly(out newBlockElement);
                    break;
            }

            if (newBlockElement == null)
            {
                throw new Exception();
            }
            else
            {
                return newBlockElement;
            }
        }

        private void connectBlock(Block newBlock)
        {
 
            if (firstBlock == null)
            {
                firstBlock = newBlock;
                lastCreatedBlock = newBlock;
                firstOfLastRowBlock = newBlock;
                columnIterator = 0;
            }
            else
            {
                if (newLine == false)
                {
                    lastCreatedBlock.Right = newBlock;
                    newBlock.Left = lastCreatedBlock;
                    lastCreatedBlock = newBlock;
                    columnIterator++;
                    connectUp(newBlock);
                }
                else if (newLine == true)
                {
                    lastCreatedBlock = newBlock;
                    firstOfLastRowBlock = newBlock;
                    newLine = false;
                    columnIterator = 0;
                    rowIterator++;
                    connectUp(newBlock);
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        private void connectUp(Block block)
        {
            if (rowIterator == 0)
            {
                return;
            }   

            Block upperBlock = firstBlock;

            for (int i = 0; i < rowIterator - 1; i++)
            {
                upperBlock = upperBlock.Down;
            }
            for (int j = 0; j < columnIterator; j++)
            {
                upperBlock = upperBlock.Right;
            }
            upperBlock.Down = block;
            block.Up = upperBlock;
        }
    }
}

using BoulderDash_DennisTijbosch_StijnHendriks.Enums;
using BoulderDash_DennisTijbosch_StijnHendriks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash_DennisTijbosch_StijnHendriks.Views
{
    public class Output
    {
        public Output()
        {

        }

        public void displayStartScreen()
        {
            clearScreen();
            Console.WriteLine(
                "┌──────────────────────────────┐\n" +
                "| Welkom bij Boulder Dash      |\n" +
                "|                              |\n" +
                "| betekenis van de symbolen    |\n" +
                "|                              |\n" +
                "|       spatie : outerspace    |\n" +
                "|            @ : Rockford      |\n" +
                "|            ■ : Mud           |\n" +
                "|            B : Boulder       |\n" +
                "|            D : Diamond       |\n" +
                "|            = : Wall          |\n" +
                "|  ║/╗/╝/═/╔/╚ : Steelwall     |\n" +
                "|            F : Firefly       |\n" +
                "|            E : Exit          |\n" +
                "└──────────────────────────────┘\n"
            );

            Console.WriteLine("Verloop van een level: Elk level moet in een bepaalde hoeveelheid tijd worden afgerond. Voor level 1 en 2 is \n" +
                           "dit binnen 150 seconden. Voor elke Diamond die de speler verzamelt, scoort hij 10 punten.Voor elke Firefly \n" +
                           "die wordt vernietigd 250 punten. Aan het einde van het level krijgt de speler 10 punten per overgebleven seconde. \n" +
                           "De Exit van een level wordt pas actief als alle Diamonds van dat level(18 in level in en 11 in level 2)\n" +
                           "verzameld zijn. Als het level is afgelopen toont het spel of het level behaald was of niet en met hoeveel punten.\n\n" +
                           "Druk op een toets om te beginnen..");
        }

        public void displayScoreAndTime(double time, int score)
        {
            Console.WriteLine("Tijd over: " + (int)time + " || score: " + score);
        }

        public void displayLevel(Block firstBlock)
        {
            Block lastPrintedLevel;
            Block firstOfLastLineLevel;
            bool newLine = false;
            bool lastLine = false;
            displayByElementType(firstBlock);
            lastPrintedLevel = firstBlock;
            firstOfLastLineLevel = firstBlock;

            while (lastLine == false)
            {
                if (newLine == true)
                {
                    Console.WriteLine();
                    displayByElementType(firstOfLastLineLevel.Down);
                    lastPrintedLevel = firstOfLastLineLevel.Down;
                    firstOfLastLineLevel = lastPrintedLevel;
                }
                while (lastPrintedLevel.Right != null)
                {
                    displayByElementType(lastPrintedLevel.Right);
                    lastPrintedLevel = lastPrintedLevel.Right;
                }
                if (firstOfLastLineLevel.Down != null)
                {
                    newLine = true;
                }  
                else
                {
                    lastLine = true;
                }
            }
        }

        public void clearScreen()
        {
            Console.Clear();
        }

        private void displayByElementType(Block block)
        {
            ElementType displayType = block.getElementType();

            switch (displayType)
            {
                case ElementType.Block:
                    Console.Write(" ");
                    break;
                case ElementType.Steelwall:
                    printSteelwall(block);
                    break;
                case ElementType.Exit:
                    Console.Write("E");
                    break;
                case ElementType.Wall:
                    Console.Write("=");
                    break;
                case ElementType.Mud:
                    Console.Write("■");
                    break;
                case ElementType.Boulder:
                    Console.Write("B");
                    break;
                case ElementType.Diamond:
                    Console.Write("D");
                    break;
                case ElementType.Rockfort:
                    Console.Write("@");
                    break;
                case ElementType.Firefly:
                    Console.Write("F");
                    break;
            }
        }

        internal void displayFinalScreen(int score)
        {
            Console.WriteLine("Je hebt verloren!");
            Console.WriteLine("Totaal score: " + score);
            Console.WriteLine("Druk op een toets om de game te verlaten..");
        }

        private void printSteelwall(Block block)
        {
            bool upIsSteelWall = false;
            bool downIsSteelWall = false;
            bool rightIsSteelWall = false;
            bool leftIsSteelWall = false;

            if (block.Up != null)
            {
                if (block.Up.getElementType() == ElementType.Steelwall)
                {
                    upIsSteelWall = true;
                }    
            }
            if (block.Down != null)
            {
                if (block.Down.getElementType() == ElementType.Steelwall)
                {
                    downIsSteelWall = true;
                } 
            }
            if (block.Right != null)
            {
                if (block.Right.getElementType() == ElementType.Steelwall)
                {
                    rightIsSteelWall = true;
                }         
            }
            if (block.Left != null)
            {
                if (block.Left.getElementType() == ElementType.Steelwall)
                {
                    leftIsSteelWall = true;
                }    
            }

            if (upIsSteelWall && downIsSteelWall && rightIsSteelWall && leftIsSteelWall)
            {
                Console.Write("╬");
            } 
            else if (upIsSteelWall && downIsSteelWall && rightIsSteelWall)
            {
                Console.Write("╠");
            }  
            else if (upIsSteelWall && downIsSteelWall && leftIsSteelWall)
            {
                Console.Write("╣");
            }   
            else if (downIsSteelWall && rightIsSteelWall && leftIsSteelWall)
            {
                Console.Write("╦");
            }   
            else if (upIsSteelWall && rightIsSteelWall && leftIsSteelWall)
            {
                Console.Write("╩");
            }  
            else if (downIsSteelWall && rightIsSteelWall)
            {
                Console.Write("╔");
            } 
            else if (upIsSteelWall && downIsSteelWall)
            {
                Console.Write("║");
            }  
            else if (rightIsSteelWall && upIsSteelWall)
            {
                Console.Write("╚");
            }  
            else if (rightIsSteelWall && leftIsSteelWall)
            {
                Console.Write("═");
            }  
            else if (leftIsSteelWall && upIsSteelWall)
            {
                Console.Write("╝");
            }               
            else if (leftIsSteelWall && downIsSteelWall)
            {
                Console.Write("╗");
            } 
            else if (downIsSteelWall)
            {
                Console.Write("╥");
            }    
            else
            {
                throw new Exception("Error, ongeldig steelwall design");
            }     
        }

        public void printSpecific(string x)
        {
            Console.WriteLine(x);
        }

    }
}

using BoulderDash_DennisTijbosch_StijnHendriks.Enums;
using BoulderDash_DennisTijbosch_StijnHendriks.Models;
using BoulderDash_DennisTijbosch_StijnHendriks.Views;
using System;

namespace BoulderDash_DennisTijbosch_StijnHendriks.Controllers
{
    public class GameController
    {
        // Aantal of frames per seconde / refresh rate GUI
        private Game game;
        private Input _input;
        private Output _output;
        int fps = 1000 / 5;

        public GameController(Input input, Output output)
        {
            _output = output;
            _input = input;
            int updatedGUI = 0;
            _output.displayStartScreen();
            _input.waitForInput();
            game = new Game();
            game.start();

            // Game loop, bewegen en beheren van de levels die je wilt spelen
            while (game.isFinished != true)
            {
                if (Console.KeyAvailable)
                {
                    _input.queueInput();
                    ConsoleKeyInfo key = _input.getInputFromQueue();
                    if (key != null)
                    {
                        switch (key.Key)
                        {
                            case ConsoleKey.N:
                                game.nextLevel();
                                break;
                            case ConsoleKey.P:
                                game.previousLevel();
                                break;
                            case ConsoleKey.LeftArrow:
                                game.rockford.move(Movement.Left);
                                break;
                            case ConsoleKey.RightArrow:
                                game.rockford.move(Movement.Right);
                                break;
                            case ConsoleKey.UpArrow:
                                game.rockford.move(Movement.Up);
                                break;
                            case ConsoleKey.DownArrow:
                                game.rockford.move(Movement.Down);
                                break;
                            default:
                                break;
                        }
                    }
                }
                game.update(updatedGUI);
                updatedGUI++;
                _output.clearScreen();
                _output.displayScoreAndTime(game.getCurrentLevel().getTimeleft(), game.rockford.Score);
                _output.displayLevel(game.getCurrentStartBlock());
                System.Threading.Thread.Sleep(fps);
            }
            _output.clearScreen();
            _output.displayFinalScreen(game.rockford.Score);
            _input.waitForInput();
        }

        public Output Output
        {
            get => default(Output);
            set
            {
            }
        }

        public Input Input
        {
            get => default(Input);
            set
            {
            }
        }

        public Game Game
        {
            get => default(Game);
            set
            {
            }
        }
    }
}

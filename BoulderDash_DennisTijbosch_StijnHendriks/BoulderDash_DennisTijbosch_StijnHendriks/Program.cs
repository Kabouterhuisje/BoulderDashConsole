using BoulderDash_DennisTijbosch_StijnHendriks.Controllers;
using BoulderDash_DennisTijbosch_StijnHendriks.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash_DennisTijbosch_StijnHendriks
{
    class Program
    {
        static void Main(string[] args)
        {
            Input inputView = new Input();
            Output outputView = new Output();

            GameController MainGame = new GameController(inputView, outputView);
        }
    }
}

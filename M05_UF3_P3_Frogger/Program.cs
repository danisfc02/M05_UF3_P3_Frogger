using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace M05_UF3_P3_Frogger
{

    public class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            List<Lane> lanes = InitializeLanes();
            Player player = new Player();
            Utils.GAME_STATE gameState = Utils.GAME_STATE.RUNNING;
            while (gameState == Utils.GAME_STATE.RUNNING)
            {
                Console.Clear();
                foreach (Lane lane in lanes)
                {
                    lane.Update();
                    lane.Draw();
                }
                player.Draw(lanes);
                Vector2Int input = Utils.Input();
                gameState = player.Update(input, lanes);
                Console.BackgroundColor = ConsoleColor.Black;
                TimeManager.NextFrame();
            }
            Console.Clear();
            if (gameState == Utils.GAME_STATE.WIN)
            {
                Console.WriteLine("You win !");
            }
            else
            {
                Console.WriteLine("You lost !");
            }
            Console.ReadKey();
        }
        static List<Lane> InitializeLanes()
        {
            List<Lane> lanes = new List<Lane>();

            lanes.Add(new Lane(posY: 0, speedPlayer: false, background: ConsoleColor.DarkGreen, damageElements: false, damageBackground: false, elementsPercent: 0f, elementsChar: Utils.charLogs, colorsElements: Utils.colorsCars.ToList()));
            lanes.Add(new Lane(posY: 1, speedPlayer: true, background: ConsoleColor.DarkBlue, damageElements: false, damageBackground: true, elementsPercent: 0.9f, elementsChar: Utils.charLogs, colorsElements: Utils.colorsCars.ToList()));
            lanes.Add(new Lane(posY: 2, speedPlayer: true, background: ConsoleColor.DarkBlue, damageElements: false, damageBackground: true, elementsPercent: 0.7f, elementsChar: Utils.charLogs, colorsElements: Utils.colorsCars.ToList()));
            lanes.Add(new Lane(posY: 3, speedPlayer: true, background: ConsoleColor.DarkBlue, damageElements: false, damageBackground: true, elementsPercent: 0.8f, elementsChar: Utils.charLogs, colorsElements: Utils.colorsCars.ToList()));
            lanes.Add(new Lane(posY: 4, speedPlayer: true, background: ConsoleColor.DarkBlue, damageElements: false, damageBackground: true, elementsPercent: 0.9f, elementsChar: Utils.charLogs, colorsElements: Utils.colorsCars.ToList()));          
            lanes.Add(new Lane(posY: 5, speedPlayer: false, background: ConsoleColor.DarkGreen, damageElements: false, damageBackground: false, elementsPercent: 0f, elementsChar: Utils.charLogs, colorsElements: Utils.colorsCars.ToList()));
            lanes.Add(new Lane(posY: 6, speedPlayer: false, background: ConsoleColor.Black, damageElements: true, damageBackground: false, elementsPercent: 0.1f, elementsChar: Utils.charCars, colorsElements: Utils.colorsCars.ToList()));
            lanes.Add(new Lane(posY: 7, speedPlayer: false, background: ConsoleColor.Black, damageElements: true, damageBackground: false, elementsPercent: 0.2f, elementsChar: Utils.charCars, colorsElements: Utils.colorsCars.ToList()));
            lanes.Add(new Lane(posY: 8, speedPlayer: false, background: ConsoleColor.Black, damageElements: true, damageBackground: false, elementsPercent: 0.2f, elementsChar: Utils.charCars, colorsElements: Utils.colorsCars.ToList()));
            lanes.Add(new Lane(posY: 9, speedPlayer: false, background: ConsoleColor.Black, damageElements: true, damageBackground: false, elementsPercent: 0.1f, elementsChar: Utils.charCars, colorsElements: Utils.colorsCars.ToList()));
            lanes.Add(new Lane(posY: 10, speedPlayer: false, background: ConsoleColor.DarkGreen, damageElements: true, damageBackground: false, elementsPercent: 0f, elementsChar: Utils.charCars, colorsElements: Utils.colorsCars.ToList()));

            return lanes;
        }
    }
}

namespace BattleShip
{
    using System;
    using System.Collections.Generic;
    using BattleShip.Common;

    class BattleShipMain
    {
        const int fieldRows = 10;
        const int fieldCols = 10;
 
        const int shipMaxLength = 5;

        static void Initialize(Engine engine)
        {
            Sea botSea = new BootSea(fieldRows, fieldCols);
            Sea playerSea = new PlayerSea(fieldRows, fieldCols);
            
            engine.ConfigureGameField(botSea as BootSea, shipMaxLength);
            engine.ConfigureGameField(playerSea as PlayerSea, shipMaxLength);
        }

        static void Main(string[] args)
        {
            ConsoleInput input = new ConsoleInput();
            ConsoleRenderer renderer = new ConsoleRenderer();
            Engine engine = new Engine(renderer, input);

            Initialize(engine);

            engine.RunGame();
        }
    }
}

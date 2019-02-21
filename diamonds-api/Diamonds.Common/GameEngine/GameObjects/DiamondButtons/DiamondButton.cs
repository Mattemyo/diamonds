using Diamonds.Common.Entities;
using System.Collections.Generic;

using Diamonds.Common.Enums;
using Diamonds.Common.GameEngine.DiamondGenerator;
using System.Linq;
using System;

namespace Diamonds.Common.GameEngine.GameObjects.DiamondButtons{
    public class DiamondButton : BaseGameObject
    {
        public DiamondButton(Position position,
            IDiamondGeneratorService generator){
            this.Position = position;
            this._generator = generator;
        }
        private readonly IDiamondGeneratorService _generator;
        public const string NameString = "DiamondButton";
        public override Position Position { get; set; }
        public override bool IsBlocking { get => false ; set {} }
        public override string Name =>  NameString;

        public override void PerformInteraction(Board board, BoardBot bot,Direction direction)
        {
            //reset diamonds here...
            board.Diamonds = new List<Position>(); //Trigger board rebuild
            this.Position = board.GetRandomEmptyPosition();
            this._generator.GenerateDiamondsIfNeeded(board);
        }
    }

}
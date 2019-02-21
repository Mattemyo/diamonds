using Diamonds.Common.GameEngine.DiamondGenerator;
using System;
using System.Collections.Generic;
using System.Text;
using Diamonds.Common.Entities;
using System.Linq;
using Diamonds.Common.GameEngine.GameObjects;

namespace Diamonds.GameEngine
{
    public class DiamondGeneratorService : IDiamondGeneratorService
    {
        const decimal MinRatioOfDiamonds = 0.01m;
        const decimal MaxRatioOfDiamonds = 0.2m;


        private readonly IGameObjectGeneratorService _gameobjectGeneratorService;
        public DiamondGeneratorService(IGameObjectGeneratorService gameobjectGeneratorService)
        {
            _gameobjectGeneratorService = gameobjectGeneratorService;
        }
        public bool NeedToGenerateDiamonds(Board board)
        {

            var numberOfBoardCells = board.Height * board.Width;

            var currentRatioOfDiamonds = (decimal)board.Diamonds.Count() / numberOfBoardCells;

            return currentRatioOfDiamonds < MinRatioOfDiamonds;

        }

        public List<Position> GenerateDiamondsIfNeeded(Board board)
        {
            var numberOfBoardCells = board.Height * board.Width;
            if (NeedToGenerateDiamonds(board) == false)
            {
                return board.Diamonds;
            }

            var maxNumberOfDiamonds = (int)(MaxRatioOfDiamonds * numberOfBoardCells);

            var diamondPositions = board.Diamonds.ToList();

            while (diamondPositions.Count < maxNumberOfDiamonds)
            {
                var diamondPositionToAdd = board.GetRandomEmptyPosition();
                diamondPositions.Add(diamondPositionToAdd);
            }

            return diamondPositions;
        }

        private bool IsInRange(decimal numberToCheck, decimal rangeMin, decimal rangeMax)
        {
            return rangeMin <= numberToCheck && numberToCheck <= rangeMax;
        }


    }
}

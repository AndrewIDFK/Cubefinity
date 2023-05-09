using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubefinity
{
    [Serializable]
    public class CubeGenerator
    {
        public string Name { get; set; }
        public double BaseCost { get; set; }
        public double CurrentCost { get; set; }
        public double CostIncrease { get; set; }
        public double CubesPerSecond { get; set; }
        public double Quantity { get; set; }
        public static int BuyAmount;
        public double CubeMultiplier { get; set; }

        public CubeGenerator() { }
        public CubeGenerator(string name, double baseCost, double costIncrease, double cubesPerSecond, double cubeMultiplier)
        {
            Name = name;
            BaseCost = baseCost;
            CurrentCost = baseCost;
            CostIncrease = costIncrease;
            CubesPerSecond = cubesPerSecond;
            CubeMultiplier = cubeMultiplier;
        }

        public bool CanAfford(double cubes)
        {
            double totalCost = 0;
            for (int i = 0; i < BuyAmount; i++)
            {
                totalCost += CurrentCost * Math.Pow((1 + CostIncrease), i);
            }
            return cubes >= totalCost;
        }
        public bool CanAffordAuto(double cubes)
        {
            double totalCost = 0;
            for (int i = 0; i < 1; i++)
            {
                totalCost += CurrentCost * Math.Pow((1 + CostIncrease), i);
            }
            return cubes >= totalCost;
        }
        
        public double FullCPS()
        {
            if(((Quantity * CubesPerSecond) * (CubeMultiplier * (1 + MainGame._prismUpgrade1Multi))) * (MainGame.primer.FullBoostPower() * MainGame.overcharger.FullBoostPower()) >= 1e300) return 1e300;
            return ((Quantity * CubesPerSecond) * (CubeMultiplier * (1 + MainGame._prismUpgrade1Multi))) * (MainGame.primer.FullBoostPower() * MainGame.overcharger.FullBoostPower());
        }

        public void Buy(int buyAmount)
        {
            for (int i = 0; i < buyAmount; i++)
            {
                Quantity++;
                CurrentCost *= 1 + CostIncrease;
            }
        }

        public double CalculateTotalCost(int buyAmount)
        {
            double totalCost = 0;
            for (int i = 0; i < buyAmount; i++)
            {
                totalCost += CurrentCost * Math.Pow((1 + CostIncrease), i);
            }
            return totalCost;
        }

        public double CalculateTotalProduction(double elapsedTimeInSeconds)
        {
            // Calculate the production based on the generator's properties and elapsed time
            return FullCPS() * elapsedTimeInSeconds;
        }

        public int CalculateMaxBuyable(double availableCubes, double costMultiplier)
        {
            double exponent = (Math.Log(1 - (availableCubes / CurrentCost) * (1 - Math.Pow((1 + CostIncrease), 1))) / Math.Log((1 + CostIncrease))) * costMultiplier;
            return (int)Math.Floor(exponent);
        }

        public void Reset()
        {
            Quantity = 0;
            CurrentCost = BaseCost;
            CubeMultiplier = 1;
        }

    }
}

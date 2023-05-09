using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubefinity
{
    [Serializable]
    public class FractalGenerator
    {
        public string Name { get; set; }
        public double BaseCost { get; set; }
        public double CurrentCost { get; set; }
        public double CostIncrease { get; set; }
        public double FractalsPerSecond { get; set; }
        public double Quantity { get; set; }
        public double FractalMultiplier { get; set; }

        public FractalGenerator() { }
        public FractalGenerator(string name, double baseCost, double costIncrease, double fractalsPerSecond, double fractalMultiplier)
        {
            Name = name;
            BaseCost = baseCost;
            CurrentCost = baseCost;
            CostIncrease = costIncrease;
            FractalsPerSecond = fractalsPerSecond;
            FractalMultiplier = fractalMultiplier;
        }

        public bool CanAfford(double cubes)
        {
            double totalCost = 0;
            for (int i = 0; i < CubeGenerator.BuyAmount; i++)
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
        
        public double FullFPS()
        {
            return (Quantity * FractalsPerSecond) * FractalMultiplier;
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
            return FullFPS() * elapsedTimeInSeconds;
        }

        public int CalculateMaxBuyable(double availablePrisms, double costMultiplier)
        {
            double exponent = Math.Log(1 - (availablePrisms / CurrentCost) * (1 - Math.Pow((1 + CostIncrease), 1))) / Math.Log((1 + CostIncrease));
            return (int)Math.Floor(exponent);
        }

        public void Reset()
        {
            Quantity = 0;
            CurrentCost = BaseCost;
            FractalMultiplier = 1;
        }

    }
}

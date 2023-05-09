using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubefinity
{
    [Serializable]
    public class FluxStuff
    {
         
        public string Name { get; set; }
        public double BaseCost { get; set; }
        public double CurrentCost { get; set; }
        public double CostIncrease { get; set; }
        public double Quantity { get; set; }
        public double BoostPower { get; set; }

        public FluxStuff() { } // Add this parameterless constructor for deserialization

        public FluxStuff(string name, double baseCost, double costIncrease, double boostPower)
        {
            Name = name;
            BaseCost = baseCost;
            CurrentCost = baseCost;
            CostIncrease = costIncrease;
            Quantity = 0;
            BoostPower = boostPower;
        }

        public bool CanAfford(double flux)
        {
            double totalCost = 0;
            for (int i = 0; i < CubeGenerator.BuyAmount; i++)
            {
                totalCost += CurrentCost * Math.Pow((1 + CostIncrease), i);
            }
            return flux >= totalCost;
        }
        public bool CanAffordAuto(double flux)
        {
            double totalCost = 0;
            for (int i = 0; i < 1; i++)
            {
                totalCost += CurrentCost * Math.Pow((1 + CostIncrease), i);
            }
            return flux >= totalCost;
        }

        public double FullBoostPower()
        {
            if(((Quantity * BoostPower) + 1) >= 1e300) return 1e300;
            else return (Quantity * BoostPower) + 1;
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

        public int CalculateMaxBuyable(double availableFlux , double costMulti)
        {
            double exponent = (Math.Log(1 - (availableFlux / CurrentCost) * (1 - Math.Pow((1 + CostIncrease), 1))) / Math.Log((1 + CostIncrease))) * costMulti;
            return (int)Math.Floor(exponent);
        }

        public void Reset()
        {
            Quantity = 0;
            CurrentCost = BaseCost;
            BoostPower = 0;
        }

    }
}

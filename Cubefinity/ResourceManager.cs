using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Cubefinity
{
    [Serializable]

    public class ResourceManager
    {
        // The number of Cubes the player has.
        private double _cubes;
        private double _sigilCubes;
        private double _flux;
        private int _fluxuateAmount;
        private double _prism;
        private int _ritualAmount;
        private double _fractals;
        private List<CubeGenerator> _cubeGenerators;
        private List<FractalGenerator> _fractalGenerators;
        private List<FluxStuff> _fluxStuff;
        private List<Upgrade> _upgrades;
        private List<Upgrade> _fluxUpgrades;
        private List<Upgrade> _prismUpgrades;
        private List<Upgrade> _fractalUpgrades;
        private List<Achievement> _achievements;
        public ResourceManager() { }

        public ResourceManager(List<CubeGenerator> cubeGenerators, List<Upgrade> upgrades, List<FluxStuff> fluxStuff, List<Upgrade> fluxUpgrades, List<Upgrade> prismUpgrades, List<FractalGenerator> fractalGenerators, List<Upgrade> fractalUpgrades, List<Achievement> achievements)
        {
            // Initialize the number of Cubes to 0.1. Maybe 0.6
            // Initialize number of Flux to 0
            _cubes = 0.1;
            _sigilCubes = 0;
            _flux = 0;
            _prism = 0;
            _fractals = 0;
            _cubeGenerators = cubeGenerators;
            _upgrades = upgrades;
            _fluxStuff = fluxStuff;
            _fluxUpgrades = fluxUpgrades;
            _prismUpgrades = prismUpgrades;
            _fractalGenerators = fractalGenerators;
            _fractalUpgrades = fractalUpgrades;
            _achievements = achievements;
        }

        // Get the number of Cubes.
        public double GetCubes()
        {
            return _cubes;
        }
        public double SetCubes(double cubes)
        {
            return _cubes = cubes;
        }

        // Add Cubes to the total.
        public void AddCubes(double amount)
        {
            _cubes += amount;
        }
        public bool RemoveCubes(double amount)
        {
            if (_cubes >= amount)
            {
                _cubes -= amount;
                return true; // Successfully removed Cubes.
            }
            return false; // Not enough Cubes to remove.
        }


        public double GetSigiltCubes()
        {
            return _sigilCubes;
        }
        public double SetSigilCubes(double sigilCubes)
        {
            return _sigilCubes = sigilCubes;
        }
        public void AddSigilCubes(double amount)
        {
            _sigilCubes += amount;
        }
        public bool RemoveSigilCubes(double amount)
        {
            if (_sigilCubes >= amount)
            {
                _sigilCubes -= amount;
                return true;
            }
            return false;
        }


        public double GetFlux()
        {
            return _flux;
        }
        public double SetFlux(double flux)
        {
            return _flux = flux;
        }
        public int GetFluxuateAmount()
        {
            return _fluxuateAmount;
        }
        public int SetFluxuateAmount(int fluxuateAmount)
        {
            return _fluxuateAmount = fluxuateAmount;
        }

        public void AddFlux(double amount)
        {
            _flux += amount;
        }
        public bool RemoveFlux(double amount)
        {
            if (_flux >= amount)
            {
                _flux -= amount;
                return true;
            }
            return false;
        }
        private bool checkerUp7;
        public void Fluxuate()
        {
            if (_cubes >= 1e7)
            {
                double fluxGain = CalculateFlux(_cubes, checkerUp7);
                AddFlux(fluxGain);
                ResetResources();
                _fluxuateAmount += 1;
            }
        }
        public void Fluxuate2()
        {
            double fluxGain = CalculateFlux(_cubes, checkerUp7);
            AddFlux(fluxGain);
            ResetResources();
            _fluxuateAmount += 1;
            
        }
        public double CalculateFlux(double cubes, bool isFluxUp7Active)
        {
            checkerUp7 = isFluxUp7Active;
            double flux = Math.Pow(cubes / 1e7, 0.7) * MainGame._fractalFluxuateMulti;
            if (isFluxUp7Active)
            {
                flux = Math.Pow(cubes / 1e7, 1.4) * MainGame._fractalFluxuateMulti;
            }
            else flux = Math.Pow(cubes / 1e7, 0.7) * MainGame._fractalFluxuateMulti;

            return flux;
        }


        public double GetCubesPerSecond()
        {
            double totalCubesPerSecond = 0;

            foreach (var generator in _cubeGenerators)
            {
                totalCubesPerSecond += generator.FullCPS();
            }

            return totalCubesPerSecond;
        }
        
        public double GetPrism()
        {
            return _prism;
        }
        public double SetPrism(double prism)
        {
            return _prism = prism;
        }
        public int GetRitualAmount()
        {
            return _ritualAmount;
        }
        public int SetRitualAmount(int ritualAmount)
        {
            return _ritualAmount = ritualAmount;
        }
        public void AddPrism(double amount)
        {
            _prism += amount;
        }
        public bool RemovePrism(double amount)
        {
            if (_prism >= amount)
            {
                _prism -= amount;
                return true;
            }
            return false;
        }
        public void Ritual()
        {
            if (_cubes >= 1e20)
            {
                double prismGain = CalculatePrism(_cubes);
                AddPrism(prismGain);
                ResetResources2();
                _ritualAmount += 1;
                if(MainGame.fluxuateFromRitual) Fluxuate2();

            }
        }
        public double CalculatePrism(double cubes)
        {
            double prism = (Math.Pow(cubes / 1e20, 0.25) * MainGame._fractalRitualMulti);
            return prism;
        }

        public double GetFractals()
        {
            return _fractals;
        }
        public double SetFractals(double fractals)
        {
            return _fractals = fractals;
        }

        public void AddFractals(double amount)
        {
            _fractals += amount;
        }
        public bool RemoveFractals(double amount)
        {
            if (_fractals >= amount)
            {
                _fractals -= amount;
                return true;
            }
            return false;
        }



        public void UpdateCubeGenerators(List<CubeGenerator> cubeGenerators)
        {
            _cubeGenerators = cubeGenerators;
        }

        public void UpdateFractalGenerators(List<FractalGenerator> fractalGenerators)
        {
            _fractalGenerators = fractalGenerators;
        }

        public void UpdateUpgrades(List<Upgrade> upgrades)
        {
            _upgrades = upgrades;
        }

        public void UpdateFluxStuff(List<FluxStuff> fluxStuff)
        {
            _fluxStuff = fluxStuff;
        }
        public void UpdateFluxUpgrade(List<Upgrade> fluxUpgrades)
        {
            _fluxUpgrades = fluxUpgrades;
        }
        public void UpdatePrismUpgrade(List<Upgrade> prismUpgrades)
        {
            _prismUpgrades = prismUpgrades;
        }
        public void UpdateFractalUpgrade(List<Upgrade> fractalUpgrades)
        {
            _fractalUpgrades = fractalUpgrades;
        }
        public void UpdateAchievement(List<Achievement> fractalUpgrades)
        {
            _achievements = fractalUpgrades;
        }


        public void ResetResources() // FLUXUATE
        {
            // Reset generators
            foreach (var generator in _cubeGenerators)
            {
                generator.Reset();
            }

            // Reset upgrades
            foreach (var upgrade in _upgrades)
            {
                upgrade.Reset();
            }
            // Reset Cubes
            _cubes = 0.1; //0.1 or 0.6
            MainGame._prevProdCount = 0;
            MainGame._prevProdCount2 = 0;
            MainGame._prevArchCount = 0;
            MainGame._prevArchCount2 = 0;
            MainGame._prevEngiCount = 0;
            MainGame._prevEngiCount2 = 0;
            MainGame._prevVisCount = 0;
            MainGame._prevPrimerLevel = 0;
            MainGame._prevPrimerLevel2 = 0;
            MainGame._prevPrimerLevel3 = 0;
            MainGame._prevOverchargerLevel = 0;
            MainGame._prevOverchargerLevel2 = 0;
            MainGame._crossFunctionalOmni = 0;
            MainGame._crossFunctionalContribution = 1.0;
            MainGame._crossFunctionalContribution2 = 1.0;
            MainGame._crossFunctionalContribution3 = 1.0;
            MainGame._crossFunctionalContribution4 = 1.0;
            MainGame._architectMultiplierContribution = 1.0;
            MainGame._engineerMultiplierContribution = 1.0;
            MainGame._visionaryMultiplierContribution = 1.0;
            MainGame._architectContribution = 1.0;
            MainGame._previousArchitectMultiplier = 0;
            MainGame._previousVisionaryMultiplier = 0;
            MainGame._previousEngineerMultiplier = 0;

            MainGame._baseProducerMultiplier = 1;
            MainGame._baseProducerCostMulti = 1;
            MainGame._baseArchitectMultiplier = 1;
            MainGame._baseArchitectCostMulti = 1;
            MainGame._baseEngineerMultiplier = 1;
            MainGame._baseEngineerCostMulti = 1;
            MainGame._baseVisionaryMultiplier = 1;
            MainGame._baseVisionaryCostMulti = 1;
            MainGame._baseOmniMultiplier = 1;
            MainGame._baseOmniCostMulti = 1;

            MainGame._prevOverchargerLevel3 = 0;
            MainGame._prevPrimerLevel4 = 0;


        }
        public void ResetResources2() // RITUAL
        {
            Debug.WriteLine("FluxStuff list before reset:");
            foreach (FluxStuff fs in _fluxStuff)
            {
                Debug.WriteLine($"{fs.Name}: Quantity = {fs.Quantity}, CurrentCost = {fs.CurrentCost}");
            }

            // Reset generators
            foreach (var generator in _cubeGenerators)
            {
                generator.Reset();
            }

            // Reset upgrades
            foreach (var upgrade in _upgrades)
            {
                upgrade.Reset();
            }

            foreach (var fluxStuff in _fluxStuff)
            {
                fluxStuff.Reset();
            }

            // Reset flux upgrades like Auto and Flux sections
            foreach (var fluxUpgrade in _fluxUpgrades)
            {
                fluxUpgrade.Reset();
            }

            // Debug: Print the FluxStuff list after reset
            Debug.WriteLine("FluxStuff list after reset:");
            foreach (FluxStuff fs in _fluxStuff)
            {
                Debug.WriteLine($"{fs.Name}: Quantity = {fs.Quantity}, CurrentCost = {fs.CurrentCost}");
            }

            // Reset Shit
            _cubes = 0.1; //0.1 or 0.6
            _flux = 0;

            MainGame._baseProducerMultiplier = 1;
            MainGame._baseProducerCostMulti = 1;
            MainGame._baseArchitectMultiplier = 1;
            MainGame._baseArchitectCostMulti = 1;
            MainGame._baseEngineerMultiplier = 1;
            MainGame._baseEngineerCostMulti = 1;

            MainGame._baseVisionaryMultiplier = 1;
            MainGame._baseVisionaryCostMulti = 1;
            MainGame._baseOmniMultiplier = 1;
            MainGame._baseOmniCostMulti = 1;

            MainGame._basePrimerCostMulti = 1;
            MainGame._baseOverchargerCostMulti = 1;

            MainGame._prevProdCount = 0;
            MainGame._prevProdCount2 = 0;
            MainGame._prevArchCount = 0;
            MainGame._prevArchCount2 = 0;
            MainGame._prevEngiCount = 0;
            MainGame._prevEngiCount2 = 0;
            MainGame._prevVisCount = 0;
            MainGame._prevPrimerLevel = 0;
            MainGame._prevPrimerLevel2 = 0;
            MainGame._prevPrimerLevel3 = 0;
            MainGame._prevOverchargerLevel = 0;
            MainGame._prevOverchargerLevel2 = 0;
            MainGame._crossFunctionalOmni = 1.0;
            MainGame._crossFunctionalContribution = 1.0;
            MainGame._crossFunctionalContribution2 = 1.0;
            MainGame._crossFunctionalContribution3 = 1.0;
            MainGame._crossFunctionalContribution4 = 1.0;
            MainGame._architectMultiplierContribution = 1.0;
            MainGame._architectContribution = 1.0;
            MainGame._engineerMultiplierContribution = 1.0;
            MainGame._visionaryMultiplierContribution = 1.0;

            MainGame._previousArchitectMultiplier = 0;
            MainGame._previousVisionaryMultiplier = 0;
            MainGame._previousEngineerMultiplier = 0;

            MainGame._prevOverchargerLevel3 = 0;
            MainGame._prevPrimerLevel4 = 0;
        }
    }

}

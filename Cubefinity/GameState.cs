using System;
using System.IO;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Text.Json;
using System.Diagnostics;

namespace Cubefinity
{
    [Serializable]
    public class GameState
    {
        
        public int Version { get; set; }
        public double Cubes { get; set; }
        public double Fractals { get; set; }
        public double Flux { get; set; }
        public double Prism { get; set; }
        public int FluxuateAmount { get; set; }
        public int RitualAmount { get; set; }
        public List<FluxStuff> FluxStuff { get; set; }
        public List<CubeGenerator> CubeGenerators { get; set; }     
        public List<FractalGenerator> FractalGenerators { get; set; }     
        public List<Upgrade> Upgrades { get; set; }
        public List<Upgrade> FluxUpgrades { get; set; }
        public List<Upgrade> PrismUpgrades { get; set; }
        public List<Upgrade> FractalUpgrades { get; set; }
        public List<Achievement> Achievements { get; set; }
        public ResourceManager ResourceManager { get; set; }
        public DateTime LastSavedTime { get; set; }
        public int PrevProdCount { get; set; }
        public int PrevProdCount2 { get; set; }
        public int PrevArchCount { get; set; }
        public int PrevArchCount2 { get; set; }
        public int PrevEngiCount { get; set; }
        public int PrevEngiCount2 { get; set; }
        public int PrevVisCount { get; set; }
        public int PrevPrimerLevel { get; set; }
        public int PrevPrimerLevel2 { get; set; }
        public int PrevPrimerLevel3 { get; set; }
        public int PrevOverchargerLevel { get; set; }
        public int PrevOverchargerLevel2 { get; set; }
        public double CrossFunctionalOmni { get; set; }
        public double CrossFunctionalContribution { get; set; }
        public double CrossFunctionalContribution2 { get; set; }
        public double CrossFunctionalContribution3 { get; set; }
        public double CrossFunctionalContribution4 { get; set; }
        public double ArchitectMultiplierContribution { get; set; }
        public double ArchitectContribution { get; set; }
        public double EngineerMultiplierContribution { get; set; }
        public double VisionaryMultiplierContribution { get; set; }
        public double PreviousArchitectMultiplier { get; set; }
        public double PreviousVisionaryMultiplier { get; set; }
        public double PreviousEngineerMultiplier { get; set; }
        public int PrevOverchargerLevel3 { get; set; }
        public int PrevPrimerLevel4 { get; set; }

        public double PrismUpgrade1Multi { get; set; }
        public int PrevRitualAmount1 { get; set; }
        public int PrevRitualAmount2 { get; set; }
        public int PrevRitualAmount3 { get; set; }
        public int HowManyTimes { get; set; }
        public int HowManyTimes2 { get; set; }

        public double BaseProducerMultiplier { get; set; }
        public double BaseProducerCostMulti { get; set; }
        public double BaseArchitectMultiplier { get; set; }
        public double BaseArchitectCostMulti { get; set; }
        public double BaseEngineerMultiplier { get; set; }
        public double BaseEngineerCostMulti { get; set; }

        public double BaseVisionaryMultiplier { get; set; }
        public double BaseVisionaryCostMulti { get; set; }
        public double BaseOmniMultiplier { get; set; }
        public double BaseOmniCostMulti { get; set; }

        public double BasePrimerCostMulti { get; set; }
        public double BaseOverchargerCostMulti { get; set; }

        public double BaseWeaverMultiplier { get; set; }
        public double BaseWeaverCostMulti { get; set; }
        public double BaseForgerMultiplier { get; set; }
        public double BaseForgerCostMulti { get; set; }  
        public double BaseNexusMultiplier { get; set; }
        public double BaseNexusCostMulti { get; set; }
        public double FractalFluxuateMulti { get; set; }
        public double FractalRitualMulti { get; set; }
        public int PrevFractCount { get; set; }
        public int PrevFractCount2 { get; set; }
        public int PrevWeaverCount { get; set; }
        public int PrevForgerCount { get; set; }
        public int PrevNexusCount { get; set; }
        public int PrevFluxuateCount { get; set; }
        public int PrevFluxuateCount2 { get; set; }
        public bool FluxuateFromRitual { get; set; }
        public double PreviousWeaverMultiplier { get; set; }
        public double PrismUpgrade11Contri { get; set; }
        public double PreviousForgerMultiplier { get; set; }
        public GameState()
        {
            Cubes = 0.1;
            FluxStuff = MainGame._fluxStuff;
            CubeGenerators = MainGame._cubeGenerators;
            FractalGenerators = MainGame._fractalGenerators;          
            Upgrades = MainGame._upgrades;
            FluxUpgrades = MainGame._fluxUpgrades;
            PrismUpgrades = MainGame._prismUpgrades;
            FractalUpgrades = MainGame._fractalUpgrades;
            Achievements = MainGame._achievements;
            PrevProdCount = MainGame._prevProdCount;
            PrevProdCount2 = MainGame._prevProdCount2;
            PrevArchCount = MainGame._prevArchCount;
            PrevArchCount2 = MainGame._prevArchCount2;
            PrevEngiCount = MainGame._prevEngiCount;
            PrevEngiCount2 = MainGame._prevEngiCount2;
            PrevVisCount = MainGame._prevVisCount;
            PrevPrimerLevel = MainGame._prevPrimerLevel;
            PrevPrimerLevel2 = MainGame._prevPrimerLevel2;
            PrevPrimerLevel3 = MainGame._prevPrimerLevel3;
            PrevOverchargerLevel = MainGame._prevOverchargerLevel;
            PrevOverchargerLevel2 = MainGame._prevOverchargerLevel2;
            CrossFunctionalOmni = MainGame._crossFunctionalOmni;
            CrossFunctionalContribution = MainGame._crossFunctionalContribution;
            CrossFunctionalContribution2 = MainGame._crossFunctionalContribution2;
            CrossFunctionalContribution3 = MainGame._crossFunctionalContribution3;
            CrossFunctionalContribution4 = MainGame._crossFunctionalContribution4;
            ArchitectMultiplierContribution = MainGame._architectMultiplierContribution;
            ArchitectContribution = MainGame._architectContribution;
            EngineerMultiplierContribution = MainGame._engineerMultiplierContribution;
            VisionaryMultiplierContribution = MainGame._visionaryMultiplierContribution;
            PreviousArchitectMultiplier = MainGame._previousArchitectMultiplier;
            PreviousVisionaryMultiplier = MainGame._previousVisionaryMultiplier;
            PreviousEngineerMultiplier = MainGame._previousEngineerMultiplier;
            PrevOverchargerLevel3 = MainGame._prevOverchargerLevel3;
            PrevPrimerLevel4 = MainGame._prevPrimerLevel4;

            PrismUpgrade1Multi = MainGame._prismUpgrade1Multi;
            PrevRitualAmount1 = MainGame._prevRitualAmount1;
            PrevRitualAmount2 = MainGame._prevRitualAmount2;
            PrevRitualAmount3 = MainGame._prevRitualAmount3;
            HowManyTimes = MainGame.howManyTimes;
            HowManyTimes2 = MainGame.howManyTimes2;

            BaseProducerMultiplier = MainGame._baseProducerMultiplier;
            BaseProducerCostMulti = MainGame._baseProducerCostMulti;
            BaseArchitectMultiplier = MainGame._baseArchitectMultiplier;
            BaseArchitectCostMulti = MainGame._baseArchitectCostMulti;
            BaseEngineerMultiplier = MainGame._baseEngineerMultiplier;
            BaseEngineerCostMulti = MainGame._baseEngineerCostMulti;

            BaseVisionaryMultiplier = MainGame._baseVisionaryMultiplier;
            BaseVisionaryCostMulti = MainGame._baseVisionaryCostMulti;
            BaseOmniMultiplier = MainGame._baseOmniMultiplier;
            BaseOmniCostMulti = MainGame._baseOmniCostMulti;

            BasePrimerCostMulti = MainGame._basePrimerCostMulti;
            BaseOverchargerCostMulti = MainGame._baseOverchargerCostMulti;

            BaseWeaverMultiplier = MainGame._baseWeaverMultiplier;
            BaseWeaverCostMulti = MainGame._baseWeaverCostMulti;
            BaseForgerMultiplier = MainGame._baseForgerMultiplier;
            BaseForgerCostMulti = MainGame._baseForgerCostMulti;
            BaseNexusMultiplier = MainGame._baseNexusMultiplier;
            BaseNexusCostMulti = MainGame._baseNexusCostMulti;

            FractalFluxuateMulti = MainGame._fractalFluxuateMulti;
            FractalRitualMulti = MainGame._fractalRitualMulti;

            PrevFractCount = MainGame._prevFractCount;
            PrevFractCount2 = MainGame._prevFractCount2;
            PrevWeaverCount = MainGame._prevWeaverCount;
            PrevForgerCount = MainGame._prevForgerCount;
            PrevNexusCount = MainGame._prevNexusCount;
            PrevFluxuateCount = MainGame._prevFluxuateCount;
            PrevFluxuateCount2 = MainGame._prevFluxuateCount2;
            FluxuateFromRitual = MainGame.fluxuateFromRitual;

            PreviousWeaverMultiplier = MainGame._previousWeaverMultiplier;
            PrismUpgrade11Contri = MainGame._prismUpgrade11Contri;
            PreviousForgerMultiplier = MainGame._previousForgerMultiplier;

            Version = 2; 
        }

        public void Migrate()
        {
            if (Version < 3) 
            {
                if (Upgrades.Count < MainGame._upgrades.Count)
                {
                    for (int i = Upgrades.Count; i < MainGame._upgrades.Count; i++)
                    {
                        Upgrades.Add(MainGame._upgrades[i]);
                    }
                }
                if (FluxUpgrades.Count < MainGame._upgrades.Count)
                {
                    for (int i = FluxUpgrades.Count; i < MainGame._fluxUpgrades.Count; i++)
                    {
                        FluxUpgrades.Add(MainGame._fluxUpgrades[i]);
                    }
                }
                if (FractalUpgrades.Count < MainGame._fractalUpgrades.Count)
                {
                    for (int i = FractalUpgrades.Count; i < MainGame._fractalUpgrades.Count; i++)
                    {
                        FractalUpgrades.Add(MainGame._fractalUpgrades[i]);
                    }
                }
                if (PrismUpgrades.Count < MainGame._prismUpgrades.Count)
                {
                    for (int i = PrismUpgrades.Count; i < MainGame._prismUpgrades.Count; i++)
                    {
                        PrismUpgrades.Add(MainGame._prismUpgrades[i]);
                    }
                }
                if (Achievements.Count < MainGame._achievements.Count)
                {
                    for (int i = Achievements.Count; i < MainGame._achievements.Count; i++)
                    {
                        Achievements.Add(MainGame._achievements[i]);
                    }
                }
                if (FractalGenerators.Count < MainGame._fractalGenerators.Count)
                {
                    for (int i = FractalGenerators.Count; i < MainGame._fractalGenerators.Count; i++)
                    {
                        FractalGenerators.Add(MainGame._fractalGenerators[i]);
                    }
                }
                UpdateOldValues(); // Call the UpdateOldValues method
                Version = 3; 
            }
        }

        public void UpdateOldValues()
        {
            
            for (int i = 0; i < Achievements.Count; i++)
            {
                Achievements[i] = MergeAchievementData(Achievements[i], MainGame._achievements[i]);
            }
            for (int i = 0; i < Upgrades.Count; i++)
            {
                Upgrades[i] = MergeUpgradeData(Upgrades[i], MainGame._upgrades[i]);
            }
            for (int i = 0; i < PrismUpgrades.Count; i++)
            {
                PrismUpgrades[i] = MergePrismUpgradeData(PrismUpgrades[i], MainGame._prismUpgrades[i]);
            }
            for (int i = 0; i < FractalUpgrades.Count; i++)
            {
                FractalUpgrades[i] = MergeFractalUpgradeData(FractalUpgrades[i], MainGame._fractalUpgrades[i]);
            }
            for (int i = 0; i < FluxUpgrades.Count; i++)
            {
                FluxUpgrades[i] = MergeFluxUpgradeData(FluxUpgrades[i], MainGame._fluxUpgrades[i]);
            }
        }

        private Achievement MergeAchievementData(Achievement oldData, Achievement newData)
        {
            oldData.Name = newData.Name;
            return oldData;
        }
        private Upgrade MergeUpgradeData(Upgrade oldData, Upgrade newData)
        {
            oldData.Name = newData.Name;
            return oldData;
        }
        private Upgrade MergePrismUpgradeData(Upgrade oldData, Upgrade newData)
        {
            oldData.Name = newData.Name;
            return oldData;
        }
        private Upgrade MergeFractalUpgradeData(Upgrade oldData, Upgrade newData)
        {
            oldData.Name = newData.Name;
            return oldData;
        }
        private Upgrade MergeFluxUpgradeData(Upgrade oldData, Upgrade newData)
        {
            oldData.Name = newData.Name;
            return oldData;
        }


        public void CalculateOfflineGains()
        {

            TimeSpan elapsedTime = DateTime.UtcNow - LastSavedTime;

            double offlineGainedCubes = 0;
            foreach (var generator in CubeGenerators)
            {
                double generatorProduction = generator.CalculateTotalProduction(elapsedTime.TotalSeconds);
                offlineGainedCubes += generatorProduction;
                Debug.WriteLine($"{generator.Name} produced {generatorProduction} cubes during offline time.");
            }
            Cubes += offlineGainedCubes;
            Debug.WriteLine($"Total offline gained cubes: {offlineGainedCubes}");
            
            double offlineGainedFractals = 0;
            foreach (var generator in FractalGenerators)
            {
                double generatorProduction = generator.CalculateTotalProduction(elapsedTime.TotalSeconds);
                offlineGainedFractals += generatorProduction;
                Debug.WriteLine($"{generator.Name} produced {generatorProduction} fractals during offline time.");
            }
            Fractals += offlineGainedFractals;
            Debug.WriteLine($"Total offline gained fractals: {offlineGainedFractals}");
        }


    }

    public static class SaveSystem
    {
        private static readonly string saveFileName = "save.dat";
        private static readonly string saveFolderName = "Cubefinity";
        private static readonly string saveFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), saveFolderName);
        private static readonly string saveFilePath = Path.Combine(saveFolderPath, saveFileName);

        private static readonly byte[] encryptionKey = new byte[] { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF, 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

        public static void Save(GameState gameData)
        {
            gameData.LastSavedTime = DateTime.UtcNow;
            Directory.CreateDirectory(saveFolderPath);
            using (FileStream fileStream = new FileStream(saveFilePath, FileMode.Create))
            using (Aes aes = Aes.Create())
            {
                aes.Key = encryptionKey;
                fileStream.Write(aes.IV, 0, aes.IV.Length);

                using (CryptoStream cryptoStream = new CryptoStream(fileStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                using (StreamWriter sw = new StreamWriter(cryptoStream))
                {
                    string json = JsonSerializer.Serialize(gameData);
                    sw.Write(json);

                }
            }
        }
        public static GameState Load()
        {
            try
            {
                using (FileStream fileStream = new FileStream(saveFilePath, FileMode.Open))
                using (Aes aes = Aes.Create())
                {
                    aes.Key = encryptionKey;

                    byte[] iv = new byte[16];
                    fileStream.Read(iv, 0, iv.Length);
                    aes.IV = iv;

                    using (CryptoStream cryptoStream = new CryptoStream(fileStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    using (StreamReader sr = new StreamReader(cryptoStream))
                    {
                        string json = sr.ReadToEnd();
                        Console.WriteLine($"JSON: {json}"); // Print JSON string for debugging
                        GameState gameData = JsonSerializer.Deserialize<GameState>(json);
                        gameData.Migrate(); // Call the Migrate method
                        return gameData;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading game state: {ex.Message}");
                return new GameState(); // Return a default game state if loading fails
            }
        }

    }
}

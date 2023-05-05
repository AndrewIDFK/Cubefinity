using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Cubefinity
{
    [Serializable]
    public class Achievement
    {
        public string Name { get; set; }
        public string Requirement { get; set; }
        public string RewardDescription { get; set; }
        public bool IsUnlocked { get; set; }
        public string HexCode { get; set; }

        private MainGame _mainGame;

        public Achievement() { }

        public Achievement(string name, string requirement, string rewardDescription, string hexCode, MainGame mainGame)
        {
            Name = name;
            Requirement = requirement;
            RewardDescription = rewardDescription;
            IsUnlocked = false;
            HexCode = hexCode;
            _mainGame = mainGame;
        }

        public bool CheckIfUnlocked(Func<bool> unlockCriteria)
        {
            if (!IsUnlocked && unlockCriteria())
            {
                Unlock();
                return true;
            }
            return false;
        }

        public void Unlock()
        {
            if (!IsUnlocked)
            {
                IsUnlocked = true;
                _mainGame.ShowAchievementPopup(Name, Requirement);
            }
        }

        public void SetMainGame(MainGame mainGame)
        {
            _mainGame = mainGame;
        }

    }

    public class AchievementManager
    {
        private List<Achievement> _achievements;
        private MainGame _mainGame;

        public AchievementManager(MainGame mainGame, List<Achievement> achievements)
        {
            _mainGame = mainGame;
            _achievements = achievements;
        }

        public void UnlockAchievement(string name, Func<bool> unlockCriteria)
        {
            Achievement achievement = _achievements.FirstOrDefault(a => a.Name == name);
            if (achievement != null)
            {
                achievement.CheckIfUnlocked(unlockCriteria);
            }
        }
    }
}

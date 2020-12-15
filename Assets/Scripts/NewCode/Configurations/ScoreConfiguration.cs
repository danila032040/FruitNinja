using UnityEngine;

namespace Scripts.Configurations
{
    [CreateAssetMenu(fileName = "ScoreConfiguration", menuName = "Configurations/Score", order = 1)]
    public class ScoreConfiguration : ScriptableObject
    {
        public int MinScore;
        public int ScoreForFruit;
        public int MaxDestroyIntervalToIncreaseMultiplier;
    }
}

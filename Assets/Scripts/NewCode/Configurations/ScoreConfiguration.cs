using UnityEngine;

namespace Scripts.Configurations
{
    [CreateAssetMenu(fileName = "ScoreConfiguration", menuName = "Configurations/Score", order = 1)]
    public class ScoreConfiguration : ScriptableObject
    {
        public int StartScore;
        public int AddScoreForFruit;
        public int RemoveScoreForFruit;
        public int MaxDestroyIntervalToIncreaseMultiplier;
    }
}

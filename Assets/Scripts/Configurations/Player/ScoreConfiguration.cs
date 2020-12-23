using UnityEngine;

namespace Scripts.Configurations.Player
{
    [CreateAssetMenu(fileName = "ScoreConfiguration", menuName = "Configurations/Score", order = 1)]
    public class ScoreConfiguration : ScriptableObject
    {
        [SerializeField] private int _startScore = 0;
        [SerializeField] private int _addScoreForFruit = 10;
        [SerializeField] private int _removeScoreForFruit = 0;
        [SerializeField] private int _maxDestroyIntervalToIncreaseMultiplier = 1;

        public int StartScore => _startScore;
        public int AddScoreForFruit => _addScoreForFruit;
        public int RemoveScoreForFruit => _removeScoreForFruit;
        public int MaxDestroyIntervalToIncreaseMultiplier => _maxDestroyIntervalToIncreaseMultiplier;
    }
}

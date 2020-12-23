using UnityEngine;

namespace Scripts.Configurations.Player
{
    [CreateAssetMenu(fileName = "HealthConfiguration", menuName = "Configurations/Health", order = 1)]
    public class HealthConfiguration : ScriptableObject
    {
        [SerializeField] private int _maxHealth = 3;
        [SerializeField] private int _minHealth = 0;
        [SerializeField] private int _addHealthWithLossOfFruit = -1;
        [SerializeField] private int _addHealthForSlicingBomb = -1;
        [SerializeField] private int _addHealthForSlicingHeart = 1;

        public int MaxHealth => _maxHealth;
        public int MinHealth => _minHealth;
        public int AddHealthWithLossOfFruit => _addHealthWithLossOfFruit;
        public int AddHealthForSlicingBomb => _addHealthForSlicingBomb;
        public int AddHealthForSlicingHeart => _addHealthForSlicingHeart;

    }
}

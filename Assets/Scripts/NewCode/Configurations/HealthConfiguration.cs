using UnityEngine;

namespace Scripts.Configurations
{
    [CreateAssetMenu(fileName = "HealthConfiguration", menuName = "Configurations/Health", order = 1)]
    public class HealthConfiguration : ScriptableObject
    {
        public int MaxHealth;
        public int MinHealth;

        public int AddHealthForSlicingFruit;
        public int AddHealthForSlicingBomb;
        public int AddHealthForSlicingHeart;

    }
}

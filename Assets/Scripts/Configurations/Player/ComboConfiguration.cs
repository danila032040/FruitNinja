using UnityEngine;

namespace Scripts.Configurations.Player
{
    [CreateAssetMenu(fileName = "ComboConfiguration", menuName = "Configurations/Combo", order = 1)]
    public class ComboConfiguration : ScriptableObject
    {
        [SerializeField] private int _minCombo = 1;
        [SerializeField] private int _maxCombo = 10;
        [SerializeField] private float _timeToIncCombo = .1f;
        [SerializeField] private float _timeToDecCombo = 3f;

        public int MinCombo => _minCombo;
        public int MaxCombo => _maxCombo;
        public float TimeToIncCombo => _timeToIncCombo;
        public float TimeToDecCombo => _timeToDecCombo;
    }
}

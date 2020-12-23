using UnityEngine;

namespace Scripts.Configurations
{
    [CreateAssetMenu(fileName = "ComboConfiguration", menuName = "Configurations/Combo", order = 1)]
    public class ComboConfiguration : ScriptableObject
    {
        public int MinCombo;
        public int MaxCombo;
        public float TimeToIncCombo;
        public float TimeToDecCombo;
    }
}

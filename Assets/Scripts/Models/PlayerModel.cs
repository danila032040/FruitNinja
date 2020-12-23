using System;

namespace Scripts.Models
{
    [Serializable]
    public class PlayerModel
    {
        public int Health { get; set; }
        public int CurrScore { get; set; }
        public int MaxScore { get; set; }
        public int Combo { get; set; }

    }
}

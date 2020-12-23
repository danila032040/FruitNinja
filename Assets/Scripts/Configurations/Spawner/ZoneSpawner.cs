using Scripts.Models.Blocks.Parent;
using UnityEngine;

namespace Scripts.Configurations.Spawner
{
    public abstract class ZoneSpawner : ScriptableObject
    {
        #region Constants

        public const int MinPriorityValue = 0;
        public const int MaxPriorityValue = 10;
        public const float MinVelocityValue = 0f;
        public const float MaxVelocityValue = 5f;
        public const float MinVelocityRotationValue = -1f;
        public const float MaxVelocityRotationValue = 1f;

        #endregion

        #region Fields

        [SerializeField]
        [Range(MinPriorityValue, MaxPriorityValue)]
        protected int priority = MinPriorityValue;

        [SerializeField]
        [Range(MinVelocityValue, MaxVelocityValue)]
        protected float minVelocity = MinVelocityValue;

        [SerializeField]
        [Range(MinVelocityValue, MaxVelocityValue)]
        protected float maxVelocity = MaxVelocityValue;

        [SerializeField]
        [Range(MinVelocityRotationValue, MaxVelocityRotationValue)]
        protected float minVelocityRotation = MinVelocityRotationValue;

        [SerializeField]
        [Range(MinVelocityRotationValue, MaxVelocityRotationValue)]
        protected float maxVelocityRotation = MaxVelocityRotationValue;

        #endregion

        public int Priority => priority;

        public abstract Block SpawnBlock(Block prefab);
    }
}
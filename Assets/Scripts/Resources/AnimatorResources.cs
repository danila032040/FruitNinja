using UnityEngine;

namespace Assets.Scripts.Resources
{
    public static class AnimatorResources
    {
        public static int CreateHeartAnimationHash => Animator.StringToHash("CreateHeart");
        public static int DeleteHeartAnimationHash => Animator.StringToHash("DeleteHeart");

        public static int CreateHeartTriggerId => Animator.StringToHash("Create");
        public static int DeleteHeartTriggerId => Animator.StringToHash("Delete");
    }
}

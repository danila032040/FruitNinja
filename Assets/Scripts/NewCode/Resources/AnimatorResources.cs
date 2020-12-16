using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.NewCode.Resources
{
    public static class AnimatorResources
    {
        public static int CreateHeartAnimationHash => Animator.StringToHash("CreateHeart");
        public static int DeleteHeartAnimationHash => Animator.StringToHash("DeleteHeart");

        public static int CreateHeartTriggerId => Animator.StringToHash("Create");
        public static int DeleteHeartTriggerId => Animator.StringToHash("Delete");
    }
}

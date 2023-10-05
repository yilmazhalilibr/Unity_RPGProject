using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity_RPGProject.Abstracts.Animations
{
    public interface IPlayerAnimation : IAnimations
    {
        public Animator PlayerAnimator { get; }
        void PlayerMoveAnim();
        void PlayerMoveAnimStop();
        void PlayerAttackAnimAsync();
        void PlayerAttackAnimStop();

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity_RPGProject.Abstracts.Animations
{
    public interface IPlayerAnimation : IAnimations
    {
        void PlayerMoveAnim();
        void PlayerAttackAnimAsync();
        void PlayerAttackAnimStop();

    }

}

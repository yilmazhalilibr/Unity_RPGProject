

using UnityEngine;

namespace Unity_RPGProject.Abstracts.Inputs
{
    public interface IInputReader
    {
        bool OnMouseLeftClick { get; }
        void MouseRayLastHit();
        RaycastHit LastHitMouse { get; }

    }
}


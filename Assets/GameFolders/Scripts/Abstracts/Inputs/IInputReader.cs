

using UnityEngine;

namespace Unity_RPGProject.Abstracts.Inputs
{
    public interface IInputReader
    {
        bool OnMouseLeftClick { get; }
        bool OnMouseLeftMultiClick { get; set; }
        void MouseRayLastHit();
        RaycastHit LastHitMouse { get; }

    }
}


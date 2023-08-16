using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity_RPGProject.Utilities.Raycast
{
    public static class RaycastExtensions
    {
        public static Ray GetMouseByRaycast()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}


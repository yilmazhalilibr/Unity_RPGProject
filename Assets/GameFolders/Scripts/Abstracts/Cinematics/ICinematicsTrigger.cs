using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity_RPGProject.Abstracts.Cinematics
{
    public interface ICinematicsTrigger
    {
        event System.Action OnCinematicsTrigger;
    }
}


using System;
using Unity_RPGProject.Abstracts.Cinematics;
using UnityEngine;
using UnityEngine.Playables;

namespace Unity_RPGProject.Cinematics
{
    public class CinematicsTrigger : MonoBehaviour, ICinematicsTrigger
    {
        public event Action OnCinematics;

        bool _cinematicWorked = false;

        public bool CinematicWorked { get { return _cinematicWorked; } private set { _cinematicWorked = value; } }

        private void OnTriggerEnter(Collider other)
        {
            if (CinematicWorked) return;
            GetComponent<PlayableDirector>().Play();
            OnCinematics?.Invoke();
            CinematicWorked = true;
        }

    }
}


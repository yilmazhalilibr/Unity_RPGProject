using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace Unity_RPGProject.Cinematics
{
    public class CinematicsTrigger : MonoBehaviour
    {

        private void OnTriggerEnter(Collider other)
        {
            GetComponent<PlayableDirector>().Play();
        }

    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity_RPGProject.PatrolPaths
{
    public class PatrolPath : MonoBehaviour
    {
        [SerializeField] float _waypointGizmosRadius = .3f;


        private void OnDrawGizmos()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                int j = GetNextIndex(i);
                Gizmos.DrawSphere(transform.GetChild(i).position, _waypointGizmosRadius);
                Gizmos.DrawLine(GetWayPoint(i), GetWayPoint(j));

            }
        }

        private Vector3 GetWayPoint(int i)
        {

            return transform.GetChild(i).position;
        }

        private int GetNextIndex(int i)
        {
            if (i + 1 >= transform.childCount)
            {
                return 0;
            }
            return i + 1;
        }

    }
}


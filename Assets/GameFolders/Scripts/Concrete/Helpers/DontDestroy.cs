using UnityEngine;


namespace Unity_RPGProject.Helpers
{
    public class DontDestroy : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}


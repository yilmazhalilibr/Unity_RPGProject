using Cysharp.Threading.Tasks;
using Unity_RPGProject.Abstracts.Cinematics;
using Unity_RPGProject.Concrete;
using Unity_RPGProject.Controllers;
using UnityEngine;
using UnityEngine.Playables;

namespace Unity_RPGProject.Cinematics
{
    public class CinematicsTrigger : MonoBehaviour, ICinematicsTrigger, ISaveable
    {

        PlayerController _playerController;
        PlayableDirector _playableDirector;


        public event System.Action OnCinematicsTrigger;

        private void Awake()
        {
            _playerController = FindObjectOfType<PlayerController>();
            _playableDirector = GetComponent<PlayableDirector>();
        }

        [System.Obsolete]
        private void OnEnable()
        {
            _playableDirector.stopped += CinematicsOnStopEvent;
        }

        [System.Obsolete]
        private void OnDisable()
        {
            _playableDirector.stopped -= CinematicsOnStopEvent;
        }

        [System.Obsolete]
        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.TryGetComponent(out _playerController)) return;
            GetComponent<PlayableDirector>().Play();
            OnCinematicsTrigger?.Invoke();// Invoke , will be need to future
            _playerController.PlayerControllerHandle(false);
        }
        private void OnTriggerExit(Collider other)
        {
            gameObject.SetActive(false);
            SavingWrapper.Instance.Save();
        }

        [System.Obsolete]
        private void CinematicsOnStopEvent(PlayableDirector playableDirector)
        {
            _playerController.PlayerControllerHandle(true);
        }

        public object CaptureState()
        {
            return false;
        }

        public void RestoreState(object state)
        {
            gameObject.SetActive(false);
        }
    }
}


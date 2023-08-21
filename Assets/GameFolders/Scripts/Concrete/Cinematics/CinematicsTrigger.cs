using System;
using Unity_RPGProject.Abstracts.Cinematics;
using Unity_RPGProject.Controllers;
using UnityEngine;
using UnityEngine.Playables;

namespace Unity_RPGProject.Cinematics
{
    public class CinematicsTrigger : MonoBehaviour, ICinematicsTrigger
    {

        PlayerController _playerController;
        PlayableDirector _playableDirector;


        public event Action OnCinematicsTrigger;

        private void Awake()
        {
            _playerController = FindAnyObjectByType<PlayerController>();
            _playableDirector = GetComponent<PlayableDirector>();
        }
        private void OnEnable()
        {
            _playableDirector.stopped += CinematicsOnStopEvent;
        }
        private void OnDisable()
        {
            _playableDirector.stopped -= CinematicsOnStopEvent;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.TryGetComponent(out _playerController)) return;
            GetComponent<PlayableDirector>().Play();
            OnCinematicsTrigger?.Invoke();// Invoke , will be need to future
            _playerController.CinematicHandleOfController(false);
        }
        private void OnTriggerExit(Collider other)
        {
            gameObject.SetActive(false);
        }
        private void CinematicsOnStopEvent(PlayableDirector playableDirector)
        {
            _playerController.CinematicHandleOfController(true);
        }

    }
}


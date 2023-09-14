using Unity.Collections;
using Unity_RPGProject.Abstracts.Combats;
using Unity_RPGProject.Concrete;
using Unity_RPGProject.ScriptableObjects;
using UnityEngine;

namespace Unity_RPGProject.Combats
{
    public class Health : MonoBehaviour, IHealth, ISaveable
    {
        [SerializeField] HealthSO _healthInfo;

        [SerializeField] float _currentHealth;


        public bool isDead => _currentHealth <= 0;

        public event System.Action OnDead;
        public event System.Action<float, float> OnTakeHit;

        private void Awake()
        {
            _currentHealth = _healthInfo.MaxHealth;
        }

        public void TakeDamage(float damage)
        {
            if (isDead) return;

            _currentHealth -= damage;

            OnTakeHit?.Invoke(_currentHealth, _healthInfo.MaxHealth);

            if (isDead)
            {
                OnDead?.Invoke();
            }


        }
        public object CaptureState()
        {
            return _currentHealth;
        }

        public void RestoreState(object state)
        {
            _currentHealth = (float)state;
        }
    }
}


using Unity_RPGProject.Abstracts.Animations;
using Unity_RPGProject.Abstracts.Combats;
using Unity_RPGProject.Abstracts.Movements;
using Unity_RPGProject.Animations;
using Unity_RPGProject.Combats;
using Unity_RPGProject.Movements;
using Unity_RPGProject.ScriptableObjects;
using UnityEngine;
using UnityEngine.AI;

namespace Unity_RPGProject.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] float _speed;
        [Header("Combat")]
        [SerializeField] WeaponSO _weaponSO;


        NavMeshAgent _navMeshAgent;
        IPlayerAnimation _playerAnimator;
        IMover _mover;
        IAttack _attack;

        public NavMeshAgent NavMeshAgent => _navMeshAgent;
        public WeaponSO Weapon => _weaponSO;
        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();

            _playerAnimator = new PlayerAnimationWithNavMesh(this);
            _attack = new PlayerAttack(this);
            _mover = new Mover(this);

        }
        private void OnEnable()
        {
            _attack.OnAttack += AttackMovement;
        }
        private void OnDisable()
        {
            _attack.OnAttack -= AttackMovement;
        }

        private void Start()
        {
            _navMeshAgent.speed = _speed;
        }

        private void FixedUpdate()
        {
            if (_attack.Attack()) return;
            if (_mover.Move()) return;

        }

        private void LateUpdate()
        {
            _playerAnimator.AnimationUpdate();
        }

        private void AttackMovement()
        {
            _mover.Move();
        }


    }
}


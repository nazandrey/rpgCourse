using UnityEngine;

namespace RpgCourse
{
    [RequireComponent(typeof(Mover))]
    public class Fighter : MonoBehaviour
    {
        [SerializeField] private float actionableStoppingDistance = 3f;
        [SerializeField] private float attackCooldown = 1f;
        
        private Mover _mover;
        private IAttackable _currTarget;
        private float _timeBeforeAttackAvailable;
        
        private void Awake()
        {
            _mover = GetComponent<Mover>();
        }

        private void Update()
        {
            if (_timeBeforeAttackAvailable > 0)
                _timeBeforeAttackAvailable -= Time.deltaTime;
            
            if (_currTarget == null) return;
            if (_mover.IsMoving) return;

            if (_mover.HasReachedDestination)
            {
                if (_timeBeforeAttackAvailable <= 0)
                {
                    _currTarget.TakeAttack();
                    _timeBeforeAttackAvailable = attackCooldown;
                }
            }
            else 
            {
                _currTarget = null;
                Debug.LogWarning("Cannot reach target");
            }
        }

        public void SetTarget(IAttackable attackable)
        {
            _currTarget = attackable;
            _mover.SetDestinationAndStopDistance(attackable.AttackPoint, actionableStoppingDistance);
        }
    }
}
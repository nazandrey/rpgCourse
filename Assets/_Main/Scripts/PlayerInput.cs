using UnityEngine;

namespace RpgCourse
{
    [RequireComponent(typeof(Mover))]
    [RequireComponent(typeof(Fighter))]
    public class PlayerInput : MonoBehaviour
    {
        private Camera _mainCamera;
        private Mover _mover;
        private Fighter _fighter;

        private void Awake()
        {
            _mover = GetComponent<Mover>();
            _fighter = GetComponent<Fighter>();
            _mainCamera = Camera.main;
        }
    
        private void Update()
        {
            if (TryAttack()) return;
            Move();
        }

        private void Move()
        {
            if (!(Input.GetMouseButtonDown(0) || (Input.GetMouseButton(0) && !_fighter.HasTarget))) return;
            if (Physics.Raycast(GetMouseRay(), out var hit, LayerMask.GetMask("Ground")))
            {
                _fighter.ResetTarget();
                _mover.SetDestination(hit.point);
            }
        }

        private Ray GetMouseRay()
        {
            return _mainCamera.ScreenPointToRay(Input.mousePosition);
        }

        private bool TryAttack()
        {
            if (!Input.GetMouseButtonDown(0)) 
                return false;
            if (!Physics.Raycast(GetMouseRay(), out var hit, LayerMask.GetMask("Attackable"))) 
                return false;
            
            var attackable = hit.collider.GetComponent<IAttackable>();
            if (attackable != null)
            {
                _fighter.SetTarget(attackable);
                return true;
            }

            return false;
        }
    }
}
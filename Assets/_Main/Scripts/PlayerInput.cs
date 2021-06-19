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
            var isMouseButtonDown = Input.GetMouseButtonDown(0);
            if (isMouseButtonDown || Input.GetMouseButton(0))
            {
                var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hit))
                {
                    var attackable = hit.collider.GetComponent<IAttackable>();
                    if (isMouseButtonDown && attackable != null)
                        _fighter.SetTarget(attackable);
                    else
                        _mover.SetDestination(hit.point);
                }
            }
        }
    }
}
using UnityEngine;

namespace RpgCourse
{
    [RequireComponent(typeof(Mover))]
    public class PlayerDestinationChanger : MonoBehaviour
    {
        [SerializeField] private float actionableStoppingDistance = 3f;
        
        private Camera _mainCamera;
        private Mover _mover;

        private void Awake()
        {
            _mover = GetComponent<Mover>();
            _mainCamera = Camera.main;
        }
    
        private void Update()
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
            {
                var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hit))
                {
                    var actionable = hit.collider.GetComponent<IActionable>();
                    if (actionable == null)
                        _mover.SetDestination(hit.point);
                    else
                        _mover.SetDestinationAndStopDistance(hit.point, actionableStoppingDistance);
                }
            }
        }
    }
}
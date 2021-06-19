using UnityEngine;

namespace RpgCourse
{
    [RequireComponent(typeof(Mover))]
    public class PlayerDestinationChanger : MonoBehaviour
    {
        [SerializeField] private Transform target;
 
        private Camera _mainCamera;
        private Mover _mover;

        private void Awake()
        {
            _mover = GetComponent<Mover>();
            _mainCamera = Camera.main;
        }

        private void Start()
        {
            _mover.SetDestination(target.position);
        }
    
        private void Update()
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
            {
                var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hit))
                {
                    _mover.SetDestination(hit.point);
                }
            }
        }
    }
}
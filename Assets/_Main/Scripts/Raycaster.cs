using UnityEngine;

namespace RpgCourse
{
    public class Raycaster : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Debug.DrawRay(ray.origin, ray.direction * 100, Color.white, 2);
            }
        }
    }
}
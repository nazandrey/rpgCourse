using UnityEngine;

namespace RpgCourse
{
    public class Enemy : MonoBehaviour, IAttackable
    {
        public Vector3 AttackPoint => transform.position;

        public void TakeAttack()
        {
            Debug.Log("Took Attack");
        }
    }
}
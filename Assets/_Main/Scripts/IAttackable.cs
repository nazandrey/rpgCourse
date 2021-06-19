using UnityEngine;

namespace RpgCourse
{
    public interface IAttackable
    {
        Vector3 AttackPoint { get; }
        void TakeAttack();
    }
}
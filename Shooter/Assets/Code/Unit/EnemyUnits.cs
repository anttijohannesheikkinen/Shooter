using System;
using System.Collections.Generic;
using UnityEngine;
using Shooter.Systems;


namespace Shooter
{

    public class EnemyUnits : MonoBehaviour
    {
        public event Action<EnemyUnit> EnemyDestroyed;

        private List<EnemyUnit> _enemyUnits = new List<EnemyUnit>();

        public void Init()
        {
            // Findit raskaita, tässä tapauksessa kyllä ihan sama.
            EnemyUnit[] enemies = GameObject.FindObjectsOfType<EnemyUnit>();
        }

        public void EnemyDied(EnemyUnit enemyUnit)
        {
            if (EnemyDestroyed != null)
            {
                EnemyDestroyed(enemyUnit);
            }

            // If we had more enemies, there probably should be some sort of a cool system for returning objects to correct pools according to their type.
            // So, this here is totally placeholder, but don't want to waste time right now to write a proper system that is probably going to be implemented
            // differently someday, or totally left undone anyway.
            if (enemyUnit.Type == EnemyUnit.EnemyType.Asteroid)
            {
                Global.Instance.Pools.AsteroidPool.ReturnObjectToPool(enemyUnit);
            }
        }
    }
}

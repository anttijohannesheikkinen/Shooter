using System;
using System.Collections.Generic;
using UnityEngine;


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

            foreach (EnemyUnit enemy in enemies)
            {
                _enemyUnits.Add(enemy);
                enemy.Init(this, null);
            }
        }

        public void EnemyDied(EnemyUnit enemyUnit)
        {
            if (EnemyDestroyed != null)
            {
                EnemyDestroyed(enemyUnit);
            }
        }
    }
}

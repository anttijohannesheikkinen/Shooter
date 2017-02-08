using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


namespace Shooter
{
    public class EnemyUnits : MonoBehaviour
    {
        public event Action<EnemyUnit> EnemyDestroyed;

        public void EnemyDied(EnemyUnit enemyUnit)
        {
            if (EnemyDestroyed != null)
            {
                EnemyDestroyed(enemyUnit);
            }
        }
    }
}

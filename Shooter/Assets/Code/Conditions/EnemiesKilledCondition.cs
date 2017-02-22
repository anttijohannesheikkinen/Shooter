using System;
using UnityEngine;


namespace Shooter.Level
{
    public class EnemiesKilledCondition : ConditionBase
    {
        //How many kills before condition met.
        [SerializeField] private int _enemyCount;

        private int _enemiesKilled = 0;

        protected override void Initialize()
        {
            LevelManager.EnemyUnits.EnemyDestroyed += HandleEnemyDestroyed;
        }

        protected void OnDestroy ()
        {
            LevelManager.EnemyUnits.EnemyDestroyed -= HandleEnemyDestroyed;
        }

        private void HandleEnemyDestroyed (EnemyUnit enemy)
        {
            _enemiesKilled++;

            if (_enemiesKilled >= _enemyCount)
            {
                IsConditionMet = true;
            }

            LevelManager.ConditionMet(this);
        }

    }
}
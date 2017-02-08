﻿using UnityEngine;

namespace Shooter
{
    public class EnemyUnit : UnitBase
    {
        public EnemyUnits EnemyUnits { get; private set; }

        public override int ProjectileLayer
        {
            get
            {
                return LayerMask.NameToLayer("EnemyProjectile");
            }
        }

        protected override void Die()
        {
            // TODO: Handle dying properly.
            gameObject.SetActive(false);
            EnemyUnits.EnemyDied(this);
            base.Die();
        }

        public void Init (EnemyUnits enemyUnits)
        {
            EnemyUnits = enemyUnits;
        }

    }
}
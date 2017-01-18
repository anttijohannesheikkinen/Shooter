using System;
using UnityEngine;

namespace Shooter
{
    public class PlayerUnit : UnitBase
    {
        public enum UnitType
        {
            None = 0,
            Fast = 1,
            Heavy = 2,
            Balanced = 3
        }

        public override int ProjectileLayer
        {
            get { return LayerMask.NameToLayer("PlayerProjectile"); }
        }

        protected override void Die()
        {
            //TODO: Handle dying properly!
            gameObject.SetActive(false);
        }
    }
}
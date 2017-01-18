using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shooter.Utility;


namespace Shooter
{
    public abstract class UnitBase : MonoBehaviour
    {
        #region Properties
        public IHealth Health { get; protected set; }
        public IMover Mover { get; protected set; }
        #endregion

        #region Unity messages
        protected virtual void Awake()
        {
            Health = gameObject.GetOrAddComponent<Health>();
            Mover = gameObject.GetOrAddComponent<Mover>();
        }
        #endregion

        #region Public interface
        public void TakeDamage(int amount)
        {
            if (Health.TakeDamage(amount))
            {
                Die();
            }
        }
        #endregion

        #region Abstracts
        protected abstract void Die();
        public abstract int ProjectileLayer { get; }
        #endregion
    }
}
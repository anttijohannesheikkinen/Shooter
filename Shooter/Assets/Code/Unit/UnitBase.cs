﻿using System.Collections;
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
        public WeaponController Weapons { get; protected set; }

        protected int _originalHealth;

        #endregion

        public delegate void HealthChangedDelegate(object sender, HealthChangedEventArgs args);

        #region Unity messages

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

        public abstract int ProjectileLayer { get; }
        #endregion

        protected void InitRequiredComponents()
        {
            Health = gameObject.GetOrAddComponent<Health>();
            Mover = gameObject.GetOrAddComponent<Mover>();
            Weapons = GetComponentInChildren<WeaponController>();
            Health.HealthChanged += HealthChanged;
            _originalHealth = Health.CurrentHealth;
        }

        protected void RespawnWithMaxHealth ()
        {
            Health.CurrentHealth = _originalHealth;
            Health.HealthChanged += HealthChanged;
        }

        private void HealthChanged (object sender, HealthChangedEventArgs args)
        {

            if (args.CurrentHealth <= 0)
            {
                Die();
            }

        }

        protected virtual void Die ()
        {
            Health.HealthChanged -= HealthChanged;
        }
    }
}
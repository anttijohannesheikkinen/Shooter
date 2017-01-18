using System;
using UnityEngine;

namespace Shooter
{
    public class Health : MonoBehaviour, IHealth
    {
        [SerializeField]
        private int _health;

        public int CurrentHealth
        {
            get { return _health; }

            set
            {
                _health = Mathf.Clamp(value, 0, value);

                if (HealthChanged != null)
                {
                    HealthChanged(this, new HealthChangedEventArgs(_health));
                }
            }
        }

        public event HealthChangedDelegate HealthChanged;

        /// <summary>
        /// Reduces health when this method is called.
        /// </summary>
        /// <param name="damage">Amount of health reduced.</param>
        /// <returns>True if health reaches zero. Otherwise returns false.</returns>
        public bool TakeDamage(int damage)
        {
            CurrentHealth -= damage;
            return CurrentHealth == 0;
        }
    }
}

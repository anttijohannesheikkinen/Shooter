using System;

namespace Shooter
{
    public class HealthChangedEventArgs : EventArgs
    {
        //Property which contains the amount of health the unit has.
        public int CurrentHealth { get; private set; }

        /// <summary>
        /// Constructor which takes the amount of unit's health as a parameter.
        /// </summary>
        public HealthChangedEventArgs (int currentHealth)
        {
            CurrentHealth = currentHealth;
        }

    }

    public delegate void HealthChangedDelegate(object sender, HealthChangedEventArgs args);

    public interface IHealth
    {
        int CurrentHealth { get; set; }

        /// <summary>
        /// Reduces health when this method is called.
        /// </summary>
        /// <param name="damage">Amount of health reduced.</param>
        /// <returns>True if health reaches zero. Otherwise returns false.</returns>
        bool TakeDamage(int damage);

        // Event is fired every time health changes.
        event HealthChangedDelegate HealthChanged;
    }
}

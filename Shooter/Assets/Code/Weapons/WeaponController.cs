﻿using UnityEngine;

namespace Shooter
{
    public class WeaponController: MonoBehaviour
    {
        [SerializeField]
        private float _shootingSpeed; // Projectiles per second.

        private float _shootingRate;
        private float _previouslyShot; // Time elapsed since we shot previously.
        private Weapon[] _weapons;

        //TODO: Add support for booster (increase shooting speed etc.)

        #region Unity Messages

        protected void Awake()
        {
            _weapons = GetComponentsInChildren<Weapon>();
            _shootingRate = 1 / _shootingSpeed;
            _previouslyShot = _shootingRate;
        }

        protected void Update ()
        {
            _previouslyShot += Time.deltaTime;
        }

        #endregion

        public void Shoot(int projectileLayer)
        {
            // Has enough time passed since we shot previously?
            if (_previouslyShot >= _shootingRate)
            {
                _previouslyShot = 0;

                foreach (Weapon weapon in _weapons)
                {
                    weapon.Shoot(projectileLayer);
                }
            }
        }
    }

}

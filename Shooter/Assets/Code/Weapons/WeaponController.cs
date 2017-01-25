using UnityEngine;

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
    }

}

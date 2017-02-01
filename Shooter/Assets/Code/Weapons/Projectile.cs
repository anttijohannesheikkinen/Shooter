using UnityEngine;
using Shooter.Interfaces;


namespace Shooter
{
    public class Projectile : MonoBehaviour
    {

        public enum ProjectileType
        {
            None = 0,
            Laser = 1,
            Explosive = 2,
            Missile = 3
        }

        #region Unity Fields

        private IShooter _shooter;

        public Rigidbody Rigidbody { get; private set; }

        [SerializeField]
        private float _shootingForce;
        [SerializeField]
        private int _damage;
        [SerializeField]
        private ProjectileType _projectileType;

        private int _destroyerLayer;

        #endregion

        public ProjectileType Type { get { return _projectileType; } }



        #region Unity Messages

        protected virtual void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
            _destroyerLayer = LayerMask.NameToLayer("Destroyer");
        }

        protected void OnCollisionEnter (Collision collision)
        {
            // Collision, projectile hit something.

            IHealth damageReceiver = collision.gameObject.GetComponentInChildren<IHealth>();

            if (damageReceiver != null)
            {
                //Colliding object can take damage and is told to take damage.

                damageReceiver.TakeDamage(_damage);
            }

            // TODO: Instantiate effect.
            // TODO: Add sound effect.

            _shooter.ProjectileHit(this);
        }


        // This is used to clean projectiles up after hitting the proper triggers.
        protected void OnTriggerEnter (Collider other)
        {
            if (other.gameObject.layer == _destroyerLayer)
            {

                _shooter.ProjectileHit(this);
            }
        }

        #endregion

        public void Shoot (IShooter shooter, Vector3 direction)
        {
            _shooter = shooter;
            Rigidbody.AddForce(direction * _shootingForce, ForceMode.Impulse);
        }
    }

}
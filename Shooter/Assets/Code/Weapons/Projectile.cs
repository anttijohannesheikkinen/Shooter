using UnityEngine;


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
            // TODO: Move object to pool.

            Destroy(gameObject);
        }


        // This is used to clean projectiles up after hitting the proper triggers.
        protected void OnTriggerEnter (Collider other)
        {
            if (other.gameObject.layer == _destroyerLayer)
            {

                // TODO: Move to pool.
                Destroy(gameObject);
            }
        }

        #endregion

        public void Shoot (Vector3 direction)
        {
            Rigidbody.AddForce(direction * _shootingForce, ForceMode.Impulse);
        }
    }

}
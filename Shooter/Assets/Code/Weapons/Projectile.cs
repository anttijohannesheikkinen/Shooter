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

        [SerializeField]
        private float _shootingForce;
        [SerializeField]
        private int _damage;

        private int _destroyerLayer;

        #endregion

        private Rigidbody _rigidbody;

        #region Unity Messages

        protected virtual void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
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

        protected void OnTriggerEnter (Collider other)
        {
            if (other.gameObject.layer == _destroyerLayer)
            {

                // Move to pool.
                Destroy(gameObject);
            }
        }

        #endregion

        public void Shoot (Vector3 direction)
        {
            _rigidbody.AddForce(direction * _shootingForce, ForceMode.Impulse);
        }
    }

}
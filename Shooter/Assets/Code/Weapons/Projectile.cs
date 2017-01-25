using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Shooter
{
    public class Projectile : MonoBehaviour
    {
        #region Unity fields

        [SerializeField]
        private float _shootingForce;
        [SerializeField]
        private float _damage;

        #endregion

        private Rigidbody _rigidbody;

        protected virtual void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Shoot (Vector3 direction)
        {
            _rigidbody.AddForce(direction * _shootingForce, ForceMode.Impulse);
        }
    }

}
using UnityEngine;
using ProjectileType = Shooter.Projectile.ProjectileType;
using Shooter.Utility;


namespace Shooter
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField]
        private ProjectileType _projectileType;
        [SerializeField]
        private Projectile _projectilePrefab;

        public void Shoot (int projectileLayer)
        {
            Projectile projectile = GetProjectile();

            if (projectile != null)
            {
                projectile.gameObject.SetLayer(projectileLayer);
                projectile.Shoot(transform.forward);
            }
        }

        private Projectile GetProjectile ()
        {
            Projectile projectile = Instantiate(_projectilePrefab, transform.position, transform.rotation);

            return projectile;
        }
    }
}
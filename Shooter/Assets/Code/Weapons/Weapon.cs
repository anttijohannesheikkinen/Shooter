using UnityEngine;
using ProjectileType = Shooter.Projectile.ProjectileType;
using Shooter.Utility;
using Shooter.Systems;


namespace Shooter
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField]
        private ProjectileType _projectileType;

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
            Projectile projectilePrefab = Global.Instance.Prefabs.GetProjectilePrefabByType(_projectileType);

            if (projectilePrefab != null)
            {
                Projectile projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
                return projectile;
            }

            return null;
        }
    }
}
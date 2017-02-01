using UnityEngine;
using ProjectileType = Shooter.Projectile.ProjectileType;
using Shooter.Utility;
using Shooter.Systems;
using Shooter.Interfaces;


namespace Shooter
{
    public class Weapon : MonoBehaviour, IShooter
    {
        [SerializeField]
        private ProjectileType _projectileType;

        /// <summary>
        /// Projectile hit something and should be possibly returned to pool.
        /// </summary>
        /// <param name="projectile"></param>
        public void ProjectileHit (Projectile projectile)
        {
            ProjectilePool pool = Global.Instance.Pools.GetPool(_projectileType);

            if (pool != null)
            {
                pool.ReturnObjectToPool(projectile);
            }

            else
            {
                Destroy(projectile.gameObject);
            }
        }

        public void Shoot (int projectileLayer)
        {
            Projectile projectile = GetProjectile();

            if (projectile != null)
            {
                projectile.gameObject.SetActive(true);
                projectile.transform.position = transform.position;
                projectile.transform.forward = transform.forward;

                projectile.gameObject.SetLayer(projectileLayer);
                projectile.Shoot(this , transform.forward);
            }

            else
            {
                Debug.LogError("Could not get projectile from projectile pool.");
            }
        }

        private Projectile GetProjectile ()
        {
            Projectile result = null;

            ProjectilePool pool = Global.Instance.Pools.GetPool(_projectileType);

            if (pool != null)
            {
                result = pool.GetPooledObject();
            }

            return result;
        }
    }
}
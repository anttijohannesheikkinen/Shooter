using UnityEngine;
using System.Collections.Generic;
using ProjectileType = Shooter.Projectile.ProjectileType;

namespace Shooter.Systems
{

    public class Prefabs : MonoBehaviour
    {

        [SerializeField]
        private List<Projectile> _projectilePrefabs = new List<Projectile>();

        public Projectile GetProjectilePrefabByType (ProjectileType projectileType)
        {
            foreach (Projectile projectile in _projectilePrefabs)
            {
                if (projectile.Type == projectileType)
                {
                    return projectile;
                }
            }

            return null;
        }

    }
}

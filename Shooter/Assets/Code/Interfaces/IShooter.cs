using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter.Interfaces
{

    public interface IShooter
    {

        void Shoot(int projectileLayer);
        void ProjectileHit(Projectile projectile);
    }
}
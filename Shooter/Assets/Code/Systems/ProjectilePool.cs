using UnityEngine;

namespace Shooter.Systems
{
    public class ProjectilePool : GenericPool<Projectile>
    {
        protected override void Deactivate(Projectile item)
        {
            item.transform.position = Vector3.zero;
            item.transform.rotation = Quaternion.identity;
            item.Rigidbody.velocity = Vector3.zero;

            base.Deactivate(item);
        }
    }
}
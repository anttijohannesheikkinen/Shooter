using UnityEngine;
using Shooter.Configs;
using Shooter.WaypointSystem;
using Shooter.Utility;

namespace Shooter
{
    public class EnemyUnit : UnitBase
    {
        [SerializeField] private Path _path;
        private IPathUser _pathUser;
        public EnemyUnits EnemyUnits { get; private set; }

        public override int ProjectileLayer
        {
            get
            {
                return LayerMask.NameToLayer(Config.EnemyProjectileLayername);
            }
        }

        protected override void Die()
        {
            // TODO: Handle dying properly.
            gameObject.SetActive(false);
            EnemyUnits.EnemyDied(this);
            base.Die();
        }

        public void Init (EnemyUnits enemyUnits)
        {
            EnemyUnits = enemyUnits;
            _pathUser = gameObject.GetOrAddComponent<PathUser>();
            _pathUser.Init(Mover, _path);
        }
    }
}
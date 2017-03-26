using UnityEngine;
using Shooter.Configs;
using Shooter.WaypointSystem;
using Shooter.Utility;

namespace Shooter
{
    public class EnemyUnit : UnitBase
    {

        public enum EnemyType
        {
            None = 0,
            Asteroid = 1
        }

        [SerializeField]
        private EnemyType _enemyType;
        public EnemyType Type { get {return _enemyType; } private set { _enemyType = value; } }
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
            EnemyUnits.EnemyDied(this);
            base.Die();
        }

        public void Init (EnemyUnits enemyUnits, Path path)
        {
            InitRequiredComponents();
            EnemyUnits = enemyUnits;
            _pathUser = gameObject.GetOrAddComponent<PathUser>();
            _pathUser.Init(Mover, path);
        }

        private void OnCollisionEnter (Collision collision)
        {
            Health.TakeDamage(Health.CurrentHealth);
            // Play effects!!!
        }
    }
}
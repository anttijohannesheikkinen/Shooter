using System;
using UnityEngine;
using Shooter.Data;
using Shooter.Configs;

namespace Shooter
{
    public class PlayerUnit : UnitBase
    {
        public enum UnitType
        {
            None = 0,
            Fast = 1,
            Heavy = 2,
            Balanced = 3
        }

        [SerializeField]
        private UnitType _unitType;
        public PlayerData Data { get; private set; }

        public UnitType Type { get { return _unitType; } }

        public override int ProjectileLayer
        {
            get { return LayerMask.NameToLayer(Config.PlayerProjectileLayername); }
        }

        public void Init  (PlayerData playerData)
        {
            Data = playerData;
        }

        protected override void Die()
        {
            //TODO: Handle dying properly!
            gameObject.SetActive(false);
            base.Die();
        }

        protected void Update ()
        {
            float inputHorizontal = Input.GetAxis("Horizontal");
            float inputVertical = Input.GetAxis("Vertical");

            Vector3 input = new Vector3(inputHorizontal, 0, inputVertical);

            Mover.MoveToDirection(input);

            bool shoot = Input.GetButton("Shoot");

            if (shoot)
            {
                Weapons.Shoot(ProjectileLayer);
            }
        }
    }
}
using System;
using UnityEngine;

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

        public UnitType unitType;

        public override int ProjectileLayer
        {
            get { return LayerMask.NameToLayer("PlayerProjectile"); }
        }

        protected override void Die()
        {
            //TODO: Handle dying properly!
            gameObject.SetActive(false);
        }

        protected void Update ()
        {
            float inputHorizontal = Input.GetAxis("Horizontal");
            float inputVertical = Input.GetAxis("Vertical");

            Vector3 input = new Vector3(inputHorizontal, 0, inputVertical);

            Mover.MoveToDirection(input);
        }
    }
}
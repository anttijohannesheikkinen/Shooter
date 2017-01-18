using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shooter.Utility;


namespace Shooter
{
    public abstract class UnitBase : MonoBehaviour
    {

        public IHealth Health { get; protected set; }

        protected virtual void Awake()
        {
            Health = gameObject.GetOrAddComponent<Health>();
        }
    }
}
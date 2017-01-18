using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Shooter
{
    public abstract class UnitBase : MonoBehaviour
    {

        public static int UnitCounter { get; set; }

        public virtual void Move()
        {

        }

        public abstract void Shoot();
    }
}
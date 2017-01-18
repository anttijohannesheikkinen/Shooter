using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Shooter
{
    public class UnitBase : MonoBehaviour
    {

        public static int UnitCounter { get; set; }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public virtual void Move()
        {

        }

        public abstract void Shoot()
        {

        }
    }
}
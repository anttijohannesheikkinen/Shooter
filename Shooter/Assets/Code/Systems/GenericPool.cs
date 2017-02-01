using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter.Systems
{
    public abstract class GenericPool<T> : MonoBehaviour
        where T : Component
    {

        [SerializeField]
        private int _objectAmount;

        [SerializeField]
        private T _objectPrefab;

        [SerializeField]
        private bool _shouldGrow;

        private List<T> _pool;
        private List<bool> _isActive;


        protected void Awake()
        {
            _pool = new List<T>(_objectAmount);
            _isActive = new List<bool>(_objectAmount);

            for(int i = 0; i < _objectAmount; i++)
            {
                AddItemToPool();
            }
        }

        private T AddItemToPool(bool activate = false)
        {
            T obj = Instantiate(_objectPrefab);
            _pool.Add(obj);
            _isActive.Add(activate);

            return obj;
        }
    }
}

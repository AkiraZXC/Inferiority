﻿using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
    public class PrefabPool : MonoBehaviour
    {

        private const int InitialSize = 10;

        private readonly Dictionary<int, Stack<MonoBehaviour>> _pools = new Dictionary<int, Stack<MonoBehaviour>>();

        public TPrefab Get<TPrefab>(TPrefab prefab, Transform parent = null)
            where TPrefab : MonoBehaviour, IInitializableMonoBehaviour

        {
            var (obj, pool) = GetOrCreate(prefab);
            obj.OnDispose = () => OnObjectDispose(obj, pool);
            obj.gameObject.SetActive(true);
            obj.transform.SetParent(parent, false);
            return obj;
        }

        private (TPrefab prefab, Stack<MonoBehaviour> pool) GetOrCreate<TPrefab>(TPrefab prefab)
            where TPrefab : MonoBehaviour

        {
            var pool = GetOrCreatePool(prefab);
            var obj = (TPrefab)(pool.Count > 0 ? pool.Pop() : InstantiatePrefab(prefab));
            return (obj, pool);
        }

        private TPrefab InstantiatePrefab<TPrefab>(TPrefab prefab) where TPrefab : MonoBehaviour
        {
            var instance = Instantiate(prefab, transform);
            instance.gameObject.SetActive(false);
            return instance;
        }

        private Stack<MonoBehaviour> GetOrCreatePool<TPrefab>(TPrefab prefab) where TPrefab : MonoBehaviour
        {
            var id = prefab.GetInstanceID();

            if (_pools.TryGetValue(id, out var pool)) return pool;
            pool = new Stack<MonoBehaviour>();
            _pools.Add(id, pool);

            return pool;
        }

        private void OnObjectDispose(MonoBehaviour obj, Stack<MonoBehaviour> pool)
        {
            pool.Push(obj);
            obj.gameObject.SetActive(false);
            obj.transform.SetParent(transform, false);
        }
    }
}
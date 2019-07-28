using System.Collections.Generic;
using UnityEngine;

namespace Common.Help
{
    public class Pool : MonoBehaviour
    {
        [SerializeField] private GameObject PoolableObjectPrefab;
        [SerializeField] private int _maxObjectCount;

        private readonly List<GameObject> _objectList = new List<GameObject>();

        private void Start()
        {
            for (var i = 0; i < _maxObjectCount; i++)
            {
                AddObjectInPool();
            }
        }

        public void Push(GameObject obj)
        {
            obj.transform.localPosition = transform.localPosition;
            obj.SetActive(false);
            obj.transform.parent = transform;
            _objectList.Add(obj);
        }

        public GameObject Pull(Transform parent)
        {
            if (_objectList.Count == 0)
            {
                AddObjectInPool();
            }

            var obj = _objectList[0];
            _objectList.Remove(obj);
            obj.transform.parent = parent;
            obj.SetActive(true);
            return obj;
        }

        private void AddObjectInPool()
        {
            var newObject = Instantiate(PoolableObjectPrefab, transform);
            newObject.SetActive(false);
            _objectList.Add(newObject);
        }
    }
}

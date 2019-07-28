using System.Collections.Generic;
using UnityEngine;

namespace Game.Wall
{
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _wallPrefabList;
        [SerializeField] private GameObject _finishPrefab;

        private void Start()
        {
            var wallCount = Random.Range(3, 5);
            var objectPosition = new Vector3(0, 2, 0);
            for (int i = 0; i < wallCount; i++)
            {
                objectPosition.z += 15;
                Instantiate
                (
                    _wallPrefabList[Random.Range(0, _wallPrefabList.Count)],
                    objectPosition,
                    Quaternion.identity,
                    transform
                );
            }

            objectPosition.z += 15;
            Instantiate
            (
                _finishPrefab,
                objectPosition,
                Quaternion.identity,
                transform
            );
        }
    }
}
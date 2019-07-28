using System.Collections.Generic;
using Common.Help;
using UnityEngine;

namespace Game.Wall
{
    public class WallPart : MonoBehaviour
    {
        [SerializeField] private WallElementType _type;
        [SerializeField] private WallElementSize _size;
        [SerializeField] private bool _isEnemy;
        [SerializeField] private List<Transform> _elementRootList = new List<Transform>();
        [SerializeField] private List<GameObject> _wallElementList = new List<GameObject>();

        private void Start()
        {
            var playerMaterial = MaterialController.Instance.GetPlayerMaterial();
            var enemyMaterial = MaterialController.Instance.GetRandomMaterial();
            
            for (int i = 0, count = _elementRootList.Count; i < count; i++)
            {
                var newElement =
                    WallElementHelper.Instance.PullWallElement(_type, _size, _elementRootList[i].transform); 
                _wallElementList.Add(newElement);
                
                var meshRenderer = newElement.gameObject.GetComponent<MeshRenderer>();
                if (_isEnemy)
                {
                    newElement.gameObject.tag = "Enemy";
                    meshRenderer.material = enemyMaterial;
                }
                else
                {
                    meshRenderer.material = playerMaterial;
                }
                
                newElement.transform.localPosition = Vector3.zero;
            }
        }

    }
}

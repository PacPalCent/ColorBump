using System.Collections.Generic;
using Common.Help;
using UnityEngine;

namespace Game.Wall
{
    public class WallElementHelper : Singleton<WallElementHelper>
    {
        [SerializeField] private List<WallElementPool> _poolList;

        public GameObject PullWallElement(WallElementType type, WallElementSize size, Transform parent)
        {
            for (int i = 0, count = _poolList.Count; i < count; i++)
            {
                if (type.Equals(_poolList[i].Type) && size.Equals(_poolList[i].Size))
                {
                    return _poolList[i].Pull(parent);
                }
            }

            return null;
        }

        public void PushWallElement(WallElementType type, WallElementSize size, GameObject oldElement)
        {
            for (int i = 0, count = _poolList.Count; i < count; i++)
            {
                if (type.Equals(_poolList[i].Type) && size.Equals(_poolList[i].Size))
                {
                    _poolList[i].Push(oldElement);
                }
            }
        }
    }
}
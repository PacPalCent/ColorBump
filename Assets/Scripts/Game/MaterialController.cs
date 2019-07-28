using System.Collections.Generic;
using Common.Help;
using UnityEngine;

namespace Game
{
    public class MaterialController : Singleton<MaterialController>
    {
        [SerializeField] private List<Material> _materialList;
        private Material _playerMaterial;

        protected override void Awake()
        {
            base.Awake();
            _playerMaterial = GetRandomMaterial();
            _materialList.Remove(_playerMaterial);
        }

        public Material GetRandomMaterial()
        {
            return _materialList[Random.Range(0, _materialList.Count - 1)];
        }
        
        public Material GetPlayerMaterial()
        {
            return _playerMaterial;
        }
    }
}
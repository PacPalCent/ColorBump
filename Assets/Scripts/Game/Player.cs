using System;
using Common;
using Common.Help;
using Extensions;
using UnityEngine;

namespace Game
{
    public class Player : Singleton<Player>
    {
        public Action MoveStarted;
        private Rigidbody _rigidBody;
        private MeshRenderer _meshRenderer;
        private bool _moveIsStart;

        protected override void Start()
        {
            base.Start();
            this.LoadComponent(ref _meshRenderer).material = MaterialController.Instance.GetPlayerMaterial();
        }
        
        void Update()
        {
#if UNITY_EDITOR
            CheckMove(KeyCode.UpArrow, Vector3.forward);
            CheckMove(KeyCode.DownArrow, Vector3.back);
            CheckMove(KeyCode.RightArrow, Vector3.right);
            CheckMove(KeyCode.LeftArrow, Vector3.left);
#else
#endif
        }

        private void CheckMove(KeyCode keyCode, Vector3 force)
        {
            if (Input.GetKey(keyCode))
            {
                this.LoadComponent(ref _rigidBody).AddForce(force * 100);
                if (!_moveIsStart)
                {
                    _moveIsStart = true;
                    MoveStarted.Call();
                }
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                LoadLevelSystem.LoadScene(LoadLevelSystem.MenuSceneName);
            }
            else if (collision.gameObject.CompareTag("Finish"))
            {
                LoadLevelSystem.LoadScene(LoadLevelSystem.GameSceneName);
            }
        }
    }
}
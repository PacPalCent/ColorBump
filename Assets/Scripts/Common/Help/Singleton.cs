using UnityEngine;

namespace Common.Help
{
    public class Singleton<T> : MonoBehaviour where T: MonoBehaviour
    {
        public static T Instance { get; set; }

        public bool IsIndestructible;

        protected virtual void Awake()
        {
            if (Instance == null)
            {
                Instance = GetComponent<T>();
                if (IsIndestructible)
                {
                    DontDestroyOnLoad(gameObject);
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }

        protected virtual void Start()
        {
            AddEvents();
        }

        protected virtual void OnDestroy()
        {
            RemoveEvents();
        }

        protected virtual void AddEvents()
        {

        }

        protected virtual void RemoveEvents()
        {

        }
    }
}
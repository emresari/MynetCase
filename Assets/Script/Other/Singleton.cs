using UnityEngine;

namespace Script.Other
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] private bool dontDestroy;

        private static T _mInstance;

        public static T Instance
        {
            get
            {
                if (_mInstance == null)
                {
                    _mInstance = GameObject.FindObjectOfType<T>();

                    if (_mInstance == null)
                    {
                        GameObject singleton = new GameObject(typeof(T).Name);
                        _mInstance = singleton.AddComponent<T>();
                    }
                }

                return _mInstance;
            }
        }

        public virtual void Awake()
        {
            if (_mInstance == null)
            {
                _mInstance = this as T;
                if (dontDestroy)
                {
                    transform.parent = null;
                    DontDestroyOnLoad(this.gameObject);
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
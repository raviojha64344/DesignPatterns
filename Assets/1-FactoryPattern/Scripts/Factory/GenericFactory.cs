using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern.FactoryPattern
{
    /*
     * Generic Factory Class
     */
    public class GenericFactory<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField]
        private T prefab;

        public T GetInstance()
        {
            return Instantiate(prefab) as T;
        }

        public T GetInstance(Transform parent)
        {
            return Instantiate(prefab, parent) as T;
        }

        public T GetInstance(Vector3 position, Quaternion rotation)
        {
            return Instantiate(prefab, position, rotation) as T;
        }
    }
}

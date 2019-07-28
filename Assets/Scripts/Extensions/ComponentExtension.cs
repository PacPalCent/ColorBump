using UnityEngine;

namespace Extensions
{
    public static class ComponentExtension 
    {
        public static T LoadComponent<T>(this Component gameObject, ref T field) where T : Component
        {
            if (field != null)
            {
                return field;
            }

            field = gameObject.GetComponent<T>();

            if (field == null)
            {
                Debug.LogError("Component " + typeof(T) + " not founded on object " + gameObject.name);
            }

            return field;
        }
    }
}

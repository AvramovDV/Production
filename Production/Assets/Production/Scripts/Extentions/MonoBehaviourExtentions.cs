using UnityEngine;

namespace Avramov.Production
{
    public static class MonoBehaviourExtentions
    {
        public static void SetActive(this MonoBehaviour monoBehaviour, bool value)
        {
            monoBehaviour.gameObject.SetActive(value);
        }
    }
}

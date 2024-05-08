using UnityEngine;

namespace Management
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private SceneryManager sceneryManager;

        [SerializeField] private int[] firstScenesToLoad;
        private void Start()
        {
            sceneryManager.LoadScenery(firstScenesToLoad);
        }

        public T GetComp<T>() where T : MonoBehaviour
        {
            T newValue = null;
            var components = gameObject.GetComponents<MonoBehaviour>();
            foreach (var component in components)
            {
                if (component.GetType() == typeof(T))
                {
                    newValue = (T)component;
                }
            }

            return newValue;
        }

        public void DisableComponent<T>(T component) where T : MonoBehaviour
        {
            component.enabled = false;
        }
    }
}

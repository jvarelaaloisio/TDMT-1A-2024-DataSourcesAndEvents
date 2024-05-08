using UnityEngine;

namespace Events
{
    public class SubscribeToEvent : MonoBehaviour
    {
        [SerializeField] private IdContainer idContainer;

        private void OnEnable()
        {
            if (EventManager<IId>.Instance)
                EventManager<IId>.Instance.SubscribeToEvent(idContainer, HandleEvent);
        }
        private void OnDisable()
        {
            if (EventManager<IId>.Instance)
                EventManager<IId>.Instance.UnsubscribeFromEvent(idContainer, HandleEvent);
        }

        private void HandleEvent(IId id)
        {
            Debug.Log($"{name}: Handling ({idContainer.name})");
        }
    }
}

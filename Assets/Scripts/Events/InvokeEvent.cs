using UnityEngine;

namespace Events
{
    public class InvokeEvent : MonoBehaviour
    {
        [SerializeField] private IdContainer idContainer;

        [ContextMenu("Invoke event by ID")]
        private void InvokeEventById()
        {
            if (EventManager<IId>.Instance)
                EventManager<IId>.Instance.InvokeEvent(idContainer);
        }
    }
}

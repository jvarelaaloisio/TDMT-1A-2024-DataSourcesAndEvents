using System;
using System.Collections.Generic;
using UnityEngine;

namespace Events
{
    [DisallowMultipleComponent]
    public abstract class EventManager<IdT> : MonoBehaviourSingleton<EventManager<IdT>>
    {
        private Dictionary<IdT, Action<IdT>> _events = new();

        public void InvokeEvent(IdT eventIdentifier)
        {
            if (_events.TryGetValue(eventIdentifier, out var eventDelegate))
            {
                eventDelegate?.Invoke(eventIdentifier);
                Debug.Log($"{name}: Event ({eventIdentifier}) invoked");
            }
            else
                Debug.LogWarning($"{name}: Event id ({eventIdentifier}) had no subscribers!");
        }

        public void SubscribeToEvent(IdT eventIdentifier, Action<IdT> handler)
        {
            if (!_events.TryAdd(eventIdentifier, handler))
                _events[eventIdentifier] += handler;
            else
                Debug.Log($"{name}: Event id ({eventIdentifier}) was added");
        }

        public void UnsubscribeFromEvent(IdT eventIdentifier, Action<IdT> handler)
        {
            if (_events.ContainsKey(eventIdentifier))
            {
                _events[eventIdentifier] -= handler;
                if (_events[eventIdentifier] == null)
                {
                    _events.Remove(eventIdentifier);
                    Debug.Log($"{name}: Event id ({eventIdentifier}) was removed");
                }
            }
        }
    }
}
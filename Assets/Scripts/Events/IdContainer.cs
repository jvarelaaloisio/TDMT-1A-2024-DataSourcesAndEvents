using UnityEngine;

namespace Events
{
    [CreateAssetMenu(menuName = "Models/ID", fileName = "IdContainer", order = 0)]
    public class IdContainer : ScriptableObject, IId
    {
        [SerializeField] private string logName;

        public override string ToString()
        {
            return $"<color=green>{logName}</color> ({base.ToString()})";
        }
    }
}
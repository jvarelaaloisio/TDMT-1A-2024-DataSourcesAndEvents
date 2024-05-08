using UnityEngine;

namespace Events
{
    [CreateAssetMenu(menuName = "Models/Scenery load ID", fileName = "SceneryLoadId", order = 0)]
    public class SceneryLoadId : ScriptableObject, IId
    {
        [SerializeField] private string logName;
        [field: SerializeField] public int[] SceneIndexes { get; private set; }

        public override string ToString()
        {
            return $"<color=green>{logName}</color> ({base.ToString()})";
        }
    }
}
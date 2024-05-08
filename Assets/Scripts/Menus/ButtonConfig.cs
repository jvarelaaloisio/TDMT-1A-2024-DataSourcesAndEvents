using Events;
using UnityEngine;

namespace Menus
{
    [CreateAssetMenu(menuName = "Config/Button", fileName = "ButtonConfig", order = 0)]
    [Icon("Assets/Icons/Button.bmp")]
    public class ButtonConfig : ScriptableObject
    {
        [SerializeField] private SceneryLoadId id;
        [field: SerializeField] public string Label { get; private set; }

        
        public IId Id => id;
    }
}

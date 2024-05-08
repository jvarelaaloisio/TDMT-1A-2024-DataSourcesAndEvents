using System;
using UnityEngine;
using UnityEngine.UI;

namespace Menus
{
    [RequireComponent(typeof(Button))]
    public class MenuButton : MonoBehaviour
    {
        public event Action<MenuButton> OnClick = delegate { };
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(HandleClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(HandleClick);
        }

        private void HandleClick()
        {
            OnClick(this);
        }
    }
}

using System;
using System.Collections.Generic;
using Events;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Menus
{
    public class Menu : MonoBehaviour
    {
        private const string GoNameSuffix = "_Btn";
        [SerializeField] private ButtonConfig[] buttonConfigs;
        [SerializeField] private MenuButton buttonPrefab;
        [SerializeField] private Transform buttonsParent;
        private Dictionary<MenuButton, ButtonConfig> configsByButtonInstance = new();


        private void Start()
        {
            if (!buttonPrefab)
            {
                Debug.LogError($"{name}: {nameof(buttonPrefab)} is null!");
                return;
            }
            foreach (var config in buttonConfigs)
            {
                if (config == null)
                    continue;
                var newButton = Instantiate(buttonPrefab, buttonsParent);
                newButton.name = config.Label + GoNameSuffix;
                var textComp = newButton.GetComponentInChildren<TMP_Text>();
                if (textComp != null)
                    textComp.text = config.Label;
                if (configsByButtonInstance.TryAdd(newButton, config))
                {
                    newButton.OnClick += HandleClick;
                }
                else
                    Debug.LogWarning($"{name}: config{config.name} was already added to menu!");
            }
        }

        private void HandleClick(MenuButton pressedButton)
        {
            if (configsByButtonInstance.TryGetValue(pressedButton, out var config))
            {
                if (config.Id != null)
                    EventManager<IId>.Instance.InvokeEvent(config.Id);
                else
                    Debug.LogWarning($"{name}: button's {nameof(config.Id)} is null!");
            }
            else
                Debug.LogWarning($"{name}: {nameof(MenuButton)} not found in dictionary!");
        }
    }
}

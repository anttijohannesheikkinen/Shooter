using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Shooter.Data;
using Shooter.InputManagement;
using System;

namespace Shooter.GUI
{
    public class ControllerSelector : MonoBehaviour
    {
        private Dropdown _dropDown;

        public PlayerData.PlayerId Id { get; private set; }
        public PlayerData.ControllerType Controller { get; private set; }

        public void Init (PlayerData.PlayerId id, PlayerData.ControllerType defaultControllerType)
        {
            _dropDown = GetComponentInChildren<Dropdown>(true);
            _dropDown.ClearOptions();
            List<Dropdown.OptionData> optionDataList = new List<Dropdown.OptionData>();

            foreach (var value in Enum.GetValues( typeof(PlayerData.ControllerType)))
            {
                if ((PlayerData.ControllerType)value != PlayerData.ControllerType.None)
                {
                    string controllerName = InputManager.GetControllerName((PlayerData.ControllerType)value);
                    optionDataList.Add(new Dropdown.OptionData(controllerName));
                }
            }

            _dropDown.AddOptions(optionDataList);
            _dropDown.onValueChanged.AddListener(OnValueChanged);

            Id = id;
            Controller = defaultControllerType;

            int defaultIndex = GetItemIndex(InputManager.GetControllerName(defaultControllerType));

            if (defaultIndex > 0)
            {
                _dropDown.value = defaultIndex;
            }
        }

        private void OnValueChanged(int index)
        {
            Controller = InputManager.GetControllerTypeByName(_dropDown.options[index].text);
        }

        private int GetItemIndex (string controllerName)
        {
            int result = -1;

            for (int i = 0; i < _dropDown.options.Count; i++)
            {
                Dropdown.OptionData item = _dropDown.options[i];

                if (item.text == controllerName)
                {
                    result = i;
                    break;
                }
            }

            return result;
        }
    }
}
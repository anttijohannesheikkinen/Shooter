using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Shooter.GUI
{
    public class PlayerUnitSelector : MonoBehaviour
    {
        private Dropdown _dropDown;

        public PlayerUnit.UnitType SelectedUnitType { get; private set; }

        public void Init ()
        {
            _dropDown = GetComponentInChildren<Dropdown>(true);
            _dropDown.ClearOptions();
            var optionDataList = new List<Dropdown.OptionData>();

            foreach (var value in Enum.GetValues(typeof(PlayerUnit.UnitType)))
            {

                if ((PlayerUnit.UnitType) value != PlayerUnit.UnitType.None)
                {
                    optionDataList.Add(new Dropdown.OptionData(value.ToString()));
                }
            }

            _dropDown.AddOptions(optionDataList);
            _dropDown.onValueChanged.AddListener(OnValueChanged);
        }

        private void OnValueChanged (int index)
        {
            string selectionText = _dropDown.options[index].text;
            SelectedUnitType = (PlayerUnit.UnitType) Enum.Parse(typeof(PlayerUnit.UnitType), selectionText);
        }

    }
}
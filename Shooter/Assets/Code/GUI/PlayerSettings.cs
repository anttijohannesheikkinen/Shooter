using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Shooter.Systems;

namespace Shooter.GUI
{

    public class PlayerSettings : WindowGUI
    {
        [SerializeField] private Dropdown _playerCountDropDown;
        [SerializeField] private PlayerSettingsItem[] _items;

        private MenuManager _menuManager;

        public void Init (MenuManager menuManager)
        {
            _menuManager = menuManager;

            foreach (var item in _items)
            {
                item.Init();
            }
        }
    }
}
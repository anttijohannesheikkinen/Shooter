using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Shooter.Data;

namespace Shooter.GUI
{
    public class PlayerSettingsItem : MonoBehaviour
    {
        [SerializeField]
        private PlayerData.PlayerId _id;
        [SerializeField]
        private Text _playerIdText;

        private ControllerSelector _controllerSelector;
        private PlayerUnitSelector _playerUnitSelector;

        public void Init ()
        {

            _controllerSelector = GetComponentInChildren<ControllerSelector>(true);
            _controllerSelector.Init(_id, PlayerData.ControllerType.KeyWASD);
            _playerUnitSelector = GetComponentInChildren<PlayerUnitSelector>(true);
            _playerUnitSelector.Init();

            _playerIdText.text = string.Format("Player {0}", (int) _id);
        }
    }
}

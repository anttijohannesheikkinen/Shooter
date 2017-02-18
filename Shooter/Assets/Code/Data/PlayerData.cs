﻿using System;
using Shooter.Configs;

namespace Shooter.Data
{
    [Serializable]
    public class PlayerData
    {
        public enum PlayerId
        {
            None = 0,
            Player1 = 1,
            Player2 = 2,
            Player3 = 3,
            Player4 = 4
        }

        public PlayerId Id;
        public PlayerUnit.UnitType UnitType;
        public int Lives;

        public ControllerAxis HorizontalAxis;
        public ControllerAxis VerticalAxis;
        public ShootButton ShootBtn;

        //TODO: ControllerType
    }
}

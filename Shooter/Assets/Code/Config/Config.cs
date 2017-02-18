using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter.Configs
{
    public enum ControllerAxis
    {
        HorizontalJoy1 = 0,
        HorizontalJoy2,
        HorizontalKey1,
        HorizontalKey2,
        VerticalJoy1,
        VerticalJoy2,
        VerticalKey1,
        VerticalKey2
    }

    public enum ShootButton
    {
        ShootJoy1 = 0,
        ShootJoy2,
        ShootKey1,
        ShootKey2
    }

    public static class Config
    {
        public const string MenuSceneName = "Menu";

        public static readonly Dictionary<int, string> LevelNames = new Dictionary<int, string>() { { 1, "Level1" }, { 2, "Level2" } };

        public static readonly Dictionary<ControllerAxis, string> ControllerAxisNames 
                                            = new Dictionary<ControllerAxis, string>()
                                            {
                                                { ControllerAxis.HorizontalJoy1, "HorizontalJoy1" },
                                                { ControllerAxis.HorizontalJoy2, "HorizontalJoy2" },
                                                { ControllerAxis.HorizontalKey1, "HorizontalKey1" },
                                                { ControllerAxis.HorizontalKey2, "HorizontalKey2" },
                                                { ControllerAxis.VerticalJoy1, "VerticalJoy1" },
                                                { ControllerAxis.VerticalJoy2, "VerticalJoy2" },
                                                { ControllerAxis.VerticalKey1, "VerticalKey1" },
                                                { ControllerAxis.VerticalKey2, "VerticalKey2" }
                                            };

        public static readonly Dictionary<ShootButton, string> ShootButtonNames
                                            = new Dictionary<ShootButton, string>()
                                            {
                                                { ShootButton.ShootJoy1, "ShootJoy1" },
                                                { ShootButton.ShootJoy2, "ShootJoy2" },
                                                { ShootButton.ShootKey1, "ShootKey1" },
                                                { ShootButton.ShootKey2, "ShootKey2" }
                                            };

        public const string PlayerProjectileLayername = "PlayerProjectile";
        public const string EnemyProjectileLayername = "EnemyProjectile";
    }
}
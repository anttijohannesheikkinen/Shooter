using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter.Configs
{
    public enum ControllerAxis
    {
        HorizontalJoy1 = 0,
        HorizontalJoy2 = 1,
        HorizontalKey1 = 2,
        HorizontalKey2 = 3,
        VerticalJoy1 = 4,
        VerticalJoy2 = 5,
        VerticalKey1 = 6,
        VerticalKey2 = 7
    }

    public enum ShootButton
    {
        ShootJoy1 = 0,
        ShootJoy2 = 1,
        ShootKey1 = 2,
        ShootKey2 = 3
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

        public const float DeadZone = 0.3f;
        public const int CollisionDamageToPlayer = 50;
    }
}
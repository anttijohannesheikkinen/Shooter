using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter.Configs
{
    public static class Config
    {
        public const string MenuSceneName = "Menu";

        public static readonly Dictionary<int, string> LevelNames = new Dictionary<int, string>() { { 1, "Level1" }, { 2, "Level2" } };

        public const string PlayerProjectileLayername = "PlayerProjectile";
        public const string EnemyProjectileLayername = "EnemyProjectile";
    }
}
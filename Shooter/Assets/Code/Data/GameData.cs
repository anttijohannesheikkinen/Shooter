using System;
using System.Collections.Generic;

namespace Shooter.Data
{
    [Serializable]
    public class GameData
    {
        public List<PlayerData> PlayerDatas = new List<PlayerData>();
        public int Level;
    }
}
using System.Collections;
using UnityEngine;
using System;

namespace PixelCrew.Model.Data
{
    [Serializable]
    public class PlayerData
    {
        [SerializeField] private InventoryData inventory;

        public int Coins;
        public int Hp;
        public bool IsArmed;

        public PlayerData Clone()
        {
            var json = JsonUtility.ToJson(this);
            return JsonUtility.FromJson<PlayerData>(json);
        }
    }
}
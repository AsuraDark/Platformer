using UnityEngine;
using PixelCrew.Model.Data;
using UnityEngine.SceneManagement;
using System;

namespace PixelCrew.Model
{
    public class GameSession : MonoBehaviour
    {
        [SerializeField] private PlayerData _data;
        [SerializeField] private PlayerData _firstData;
        public PlayerData Data => _data;
        public PlayerData FirstData => _firstData;

        private PlayerData _save;
        public QuickInventoryModel QuickInventory { get; private set; }

        private void Awake()
        {
            LoadHud();

            if(IsSessionExit())
            {
                DestroyImmediate(gameObject);
            }
            else
            {
                Save();
                InitModels();
                DontDestroyOnLoad(this);
            }
        }

        private void InitModels()
        {
            QuickInventory = new QuickInventoryModel(_data);
        }

        private void LoadHud()
        {
            SceneManager.LoadScene("Hud", LoadSceneMode.Additive);
        }

        private bool IsSessionExit()
        {
            var sessions = FindObjectsOfType<GameSession>();
            foreach(var gameSession in sessions)
            {
                if (gameSession != this)
                    return true;
            }
            return false;
        }
        public void Save()
        {
            _save = _data.Clone();
        }

        public void LoadLastSave()
        {
            _data = _save.Clone();
        }
    }
}
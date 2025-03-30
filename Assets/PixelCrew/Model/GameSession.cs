using UnityEngine;

namespace PixelCrew.Model
{
    public class GameSession : MonoBehaviour
    {
        [SerializeField] private PlayerData _data;
        [SerializeField] private PlayerData _firstData;
        public PlayerData Data => _data;
        public PlayerData FirstData => _firstData;

        private void Awake()
        {
            if(IsSessionExit())
            {
                DestroyImmediate(gameObject);
            }
            else
            {
                DontDestroyOnLoad(this);
            }

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
    }
}
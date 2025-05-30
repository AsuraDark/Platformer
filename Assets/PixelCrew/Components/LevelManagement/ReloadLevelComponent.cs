﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PixelCrew.Model;

namespace PixelCrew.Components.LevelManagement
{
    public class ReloadLevelComponent : MonoBehaviour
    {
        public void Reload()
        {
            var session = FindObjectOfType<GameSession>();
            DestroyImmediate(session.gameObject);

            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}

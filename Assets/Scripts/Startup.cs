﻿using System;
using Models;
using UnityEngine;

namespace DefaultNamespace
{
    public class Startup : MonoBehaviour
    {
        private GameController _gameController;
        private Map _map;
        
        private void Start()
        {
            _map = new Map(null, null);
            _gameController = new GameController(_map);
        }
    }
}
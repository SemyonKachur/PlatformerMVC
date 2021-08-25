using System;
using UnityEngine;

namespace PlatformerMVC
{
    public class WinGameController
    {
        private WinGame _winGameView;
        private bool _gameWin = false;
        public event Action<bool> IsGameWin = delegate (bool isGameWin) { };

       public WinGameController()
        {
            _winGameView = GameObject.FindObjectOfType<WinGame>();
            _winGameView.IsGameWin += GameWin;
        }
        
        private void GameWin(bool gameWin)
        {
            _gameWin = true;
            IsGameWin.Invoke(_gameWin);
        }

    }
}

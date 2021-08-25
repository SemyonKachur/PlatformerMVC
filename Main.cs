using UnityEngine;

namespace PlatformerMVC
{
    public class Main : MonoBehaviour
    {
        private Controllers _controllers;
        private MainAndPauseMenu _menu;
        private bool _isGameOn = false;
        private bool _gameOver = false;
        private bool _winGame = false;

        public bool IsGameOn => _isGameOn;

        void Awake()
        {
            _isGameOn = false;
            _menu = new MainAndPauseMenu();
            _menu.IsGameStart += GameStart;
            _controllers = new Controllers();
            _controllers.LevelGeneratorController.Init();

            _controllers.PlayerController.PlayerView.GameOver += GameOver;
            _controllers.WinGameController.IsGameWin += WinGame;
        }
                
        void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                _isGameOn = false;
                _menu.MenuPanel.gameObject.SetActive(true);
            }

            if (_gameOver)
            {
                _isGameOn = false;
                _menu.MenuPanel.gameObject.SetActive(true);
                _menu.ResumeButton.SetActive(false);
                _menu.StatrGame.SetActive(false);
                _menu.GameOverText.SetActive(true);
            }

            if (_winGame)
            {
                _isGameOn = false;
                _menu.MenuPanel.gameObject.SetActive(true);
                _menu.ResumeButton.SetActive(false);
                _menu.StatrGame.SetActive(false);
                _menu.WinGameText.SetActive(true);
            }

            if (_isGameOn)
            {
                _controllers.Update();
            }
        }

        private void FixedUpdate()
        {
            if (_isGameOn)
            {
                _controllers.FixedUpdate();
            }
        }

        private void GameStart(bool isGameOn)
        {
            _isGameOn = isGameOn;
        }

        private void GameOver(bool gameOver)
        {
            _gameOver = gameOver;
        }

        private void WinGame(bool winGame)
        {
            _winGame = winGame;
        }
    }
}

using UnityEngine;

namespace PlatformerMVC
{
    public class Main : MonoBehaviour
    {
        private Controllers _controllers;
        private MainAndPauseMenu _menu;
        private bool _isGameOn = false;

        public bool IsGameOn => _isGameOn;

        void Awake()
        {
            _isGameOn = false;
            _menu = new MainAndPauseMenu();
            _menu.IsGameStart += GameStart;
            _controllers = new Controllers();
            _controllers.LevelGeneratorController.Init();
        }
                
        void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                _isGameOn = false;
                _menu.MenuPanel.gameObject.SetActive(true);
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

        private void GameStart(bool isGameStart)
        {
            _isGameOn = isGameStart;
        }
    }
}

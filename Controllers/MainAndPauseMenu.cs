using System;
using UnityEngine;
using UnityEngine.UI;

namespace PlatformerMVC
{
    public class MainAndPauseMenu
    {
        private Canvas _canvas;
        private GraphicRaycaster _graphicRaycaster;
        private RectTransform _canvasComponent;
        private RectTransform _menuPanel;
        private UIData _uiData;
        private Button _startGame;
        private Button _exit;
        private Button _resume;
        private Text _buttonText;
        private Text _gameOverText;

        private Sprite _sprite;
        private Image _image;

        public bool isGameStart = false;
        public RectTransform MenuPanel => _menuPanel;
        public GameObject ResumeButton => _resume.gameObject;
        public GameObject StatrGame => _startGame.gameObject;
        public GameObject GameOverText => _gameOverText.gameObject;

        public event Action<bool> IsGameStart = delegate (bool isGameStart) { };

        public MainAndPauseMenu()
        {
            var myCanvas = new GameObject("Canvas");
            _canvas = myCanvas.AddComponent<Canvas>();
            _canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            _graphicRaycaster = _canvas.gameObject.AddComponent<GraphicRaycaster>();
            CreateMenuPanel();

            _uiData = Resources.Load<UIData>("StartButtonData");
            _startGame = CreateButton(_uiData);
            _startGame.onClick.AddListener(GameStart);

            _uiData = Resources.Load<UIData>("ExitButtonData");
            _exit = CreateButton(_uiData);
            _exit.onClick.AddListener(ExitGame);

            _uiData = Resources.Load<UIData>("ResumeButtonData");
            _resume = CreateButton(_uiData);
            _resume.gameObject.SetActive(false);
            _resume.onClick.AddListener(ResumeGame);

            _uiData = Resources.Load<UIData>("GameOverTextData");
            _gameOverText = CreateGameOverText(_uiData);
            _gameOverText.gameObject.SetActive(false);                             
        }

        private RectTransform CreateCanvasElement()
        {
            _canvasComponent = new GameObject("NewCanvasElement").AddComponent<RectTransform>();
            _canvasComponent.SetParent(_canvas.transform);
            return _canvasComponent;
        }

        private RectTransform CreateMenuPanelElement()
        {
            _canvasComponent = new GameObject("NewMenuElement").AddComponent<RectTransform>();
            _canvasComponent.SetParent(_menuPanel.transform);
            return _canvasComponent;
        }

        private void CreateMenuPanel()
        {
            _menuPanel = CreateCanvasElement();
            _menuPanel.name = "MenuPanel";
            _uiData = Resources.Load<UIData>("MenuPanel");
            _sprite = _uiData.Sprite;
            _menuPanel.anchorMin = new Vector2(0.5f, 0.5f);
            _menuPanel.anchorMax = new Vector2(0.5f, 0.5f);
            _menuPanel.pivot = new Vector2(0.5f, 0.5f);
            _menuPanel.localScale = new Vector3(1, 1, 1);
            _menuPanel.sizeDelta = new Vector2(_uiData.WidthTransform, _uiData.HeightTrnsform);
            _menuPanel.anchoredPosition = new Vector3(0, 0, 0);
            _image = _menuPanel.gameObject.AddComponent<Image>();
            _image.sprite = _sprite;
            _image.color = _uiData.Color;
        }

        private Button CreateButton(UIData buttonData)
        {
            _canvasComponent = CreateMenuPanelElement();
            var button = _canvasComponent.gameObject.AddComponent<Button>();
            button.name = _uiData.Name;
            _sprite = _uiData.Sprite;
            _canvasComponent.anchorMin = new Vector2(0.5f, 0.5f);
            _canvasComponent.anchorMax = new Vector2(0.5f, 0.5f);
            _canvasComponent.pivot = new Vector2(0.5f, 0.5f);
            _canvasComponent.localScale = new Vector3(1, 1, 1);
            _canvasComponent.sizeDelta = new Vector2(_uiData.WidthTransform, _uiData.HeightTrnsform);
            _canvasComponent.anchoredPosition = _uiData.Position;
            _image = _canvasComponent.gameObject.AddComponent<Image>();
            _image.sprite = _sprite;
            _image.color = _uiData.Color;

            _buttonText = CreateCanvasElement().gameObject.AddComponent<Text>();
            _buttonText.rectTransform.SetParent(button.transform);
            _buttonText.rectTransform.anchoredPosition = Vector3.zero;
            _buttonText.rectTransform.sizeDelta = new Vector2(_uiData.WidthTransform, _uiData.HeightTrnsform);
            _buttonText.text = _uiData.Text;
            _buttonText.color = _uiData.Color;
            _buttonText.font = _uiData.Font;
            _buttonText.alignment = TextAnchor.MiddleCenter;
            _buttonText.resizeTextForBestFit = true;

            return button;
        }

        private Text CreateGameOverText(UIData textData)
        {
            _gameOverText = CreateMenuPanelElement().gameObject.AddComponent<Text>();
            _gameOverText.name = _uiData.Name;
            _canvasComponent.anchorMin = new Vector2(0.5f, 0.5f);
            _canvasComponent.anchorMax = new Vector2(0.5f, 0.5f);
            _canvasComponent.pivot = new Vector2(0.5f, 0.5f);
            _canvasComponent.localScale = new Vector3(1, 1, 1);
            _canvasComponent.sizeDelta = new Vector2(_uiData.WidthTransform, _uiData.HeightTrnsform);
            _canvasComponent.anchoredPosition = _uiData.Position;
            _gameOverText.text = _uiData.Text;
            _gameOverText.color = _uiData.Color;
            _gameOverText.font = _uiData.Font;
            _gameOverText.alignment = TextAnchor.MiddleCenter;
            _gameOverText.fontStyle = FontStyle.Bold;
            _gameOverText.resizeTextForBestFit = true;
            return _gameOverText;
        }

        private void GameStart()
        {
            _startGame.gameObject.SetActive(false);
            _resume.gameObject.SetActive(true);
            _menuPanel.gameObject.SetActive(false);
            IsGameStart.Invoke(true);
        }

        private void ExitGame()
        {
            Application.Quit();
        }

        private void ResumeGame()
        {
            _menuPanel.gameObject.SetActive(false);
            IsGameStart.Invoke(true);
        }
    }
}

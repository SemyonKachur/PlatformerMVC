using UnityEngine;
using UnityEngine.UI;

namespace PlatformerMVC
{
    public class UILivesText
    {
        private Text _healthText;
        private UIFactory _uiFactory;
        private RectTransform _textRectTransform;
        private RectTransform _livesCountTransform;
        private UIData _UIData;
        private Vector3 _yOffset = new Vector3(0,-10,0);

        public UILivesText(UIFactory uiFactory, RectTransform uiLivesViewRectTransform, int playerLives)
        {
            _uiFactory = uiFactory;
            _UIData = Resources.Load<UIData>("UILivesText");
            _livesCountTransform = uiFactory.CreateNewCanvasElement();
            _livesCountTransform.gameObject.name = "LivesCount";
            _livesCountTransform.sizeDelta = new Vector2(_UIData.WidthTransform, _UIData.HeightTrnsform);
            _livesCountTransform.localScale = new Vector3(1, 1, 1);
            _livesCountTransform.anchorMin = new Vector2(1, 1);
            _livesCountTransform.anchorMax = new Vector2(1, 1);
            _livesCountTransform.pivot = new Vector2(1, 1);
            _livesCountTransform.anchoredPosition = new Vector3(0, 0, 0) + 
                                                    new Vector3(-uiLivesViewRectTransform.sizeDelta.x + 
                                                                uiLivesViewRectTransform.anchoredPosition.x,0,0)+_yOffset;
            _healthText = _livesCountTransform.gameObject.AddComponent<Text>();
            _healthText.text = playerLives.ToString();
            _healthText.color = _UIData.Color;
            _healthText.font = _UIData.Font;
            _healthText.alignment = TextAnchor.MiddleCenter;
            _healthText.resizeTextForBestFit = true;

            _textRectTransform = _uiFactory.CreateNewCanvasElement();
            _textRectTransform.gameObject.name = "LivesText";
            _textRectTransform.sizeDelta = new Vector2(_UIData.WidthTransform, _UIData.HeightTrnsform);
            _textRectTransform.localScale = new Vector3(1, 1, 1);
            _textRectTransform.anchorMin = new Vector2(1, 1);
            _textRectTransform.anchorMax = new Vector2(1, 1);
            _textRectTransform.pivot = new Vector2(1, 1);
            _textRectTransform.anchoredPosition = new Vector3(_livesCountTransform.anchoredPosition.x, 0, 0) + new Vector3(-_livesCountTransform.sizeDelta.x, 0, 0) + _yOffset;
            _healthText = _textRectTransform.gameObject.AddComponent<Text>();
            _healthText.text = _UIData.Text;
            _healthText.color = _UIData.Color;
            _healthText.font = _UIData.Font;
            _healthText.alignment = TextAnchor.MiddleCenter;
            _healthText.resizeTextForBestFit = true;
        }

    }
}

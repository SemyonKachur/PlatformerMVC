using UnityEngine;
using UnityEngine.UI;

namespace PlatformerMVC
{
    public class UIHealthText
    {
        private Text _healthText;
        private UIFactory _uiFactory;
        private RectTransform _textRectTransform;
        private UIData _UIData;

        public UIHealthText(UIFactory uiFactury)
        {
            _uiFactory = uiFactury;
            _UIData = Resources.Load<UIData>("UIHealthText");
            _textRectTransform = uiFactury.CreateNewCanvasElement();
            _textRectTransform.gameObject.name = "HealthText";
            _textRectTransform.sizeDelta = new Vector2(_UIData.WidthTransform, _UIData.HeightTrnsform);
            _textRectTransform.localScale = new Vector3(1,1,1);
            _textRectTransform.anchorMin = new Vector2(0, 1);
            _textRectTransform.anchorMax = new Vector2(0, 1);
            _textRectTransform.pivot = new Vector2(0, 1);
            _textRectTransform.anchoredPosition = new Vector3(0, 0, 0);
            _healthText = _textRectTransform.gameObject.AddComponent<Text>();
            _healthText.text = _UIData.Text;
            _healthText.color = _UIData.Color;
            _healthText.font = _UIData.Font;
            _healthText.alignment = TextAnchor.MiddleCenter;
            _healthText.resizeTextForBestFit = true;
        }
        public RectTransform GetRectTransform()
        {
            return _textRectTransform;
        }
    }
}

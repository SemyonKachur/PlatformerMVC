using UnityEngine;
using UnityEngine.UI;

namespace PlatformerMVC
{
    public class UILivesView
    {
        private UIFactory _uiFactory;
        private RectTransform _imageRectTransform;
        private Image _image;
        private Sprite _sprite;
        private float _imageWidth;
        private float _imageHeight;
        private UIData _imageData;
        private Vector3 _offset = new Vector3(-10, -10, 0);

        public UILivesView(UIFactory uiFactory)
        {
            _uiFactory = uiFactory;
            _imageData = Resources.Load<UIData>("UILivesView");
            _sprite = _imageData.Sprite;
            _imageWidth = _imageData.WidthTransform;
            _imageHeight = _imageData.HeightTrnsform;
            _imageRectTransform = _uiFactory.CreateNewCanvasElement();
            _imageRectTransform.gameObject.name = "LivesView";
            _imageRectTransform.anchorMin = new Vector2(1, 1);
            _imageRectTransform.anchorMax = new Vector2(1, 1);
            _imageRectTransform.pivot = new Vector2(1, 1);
            _imageRectTransform.localScale = new Vector3(1, 1, 1);
            _imageRectTransform.sizeDelta = new Vector2(_imageData.WidthTransform, _imageData.HeightTrnsform);
            _imageRectTransform.anchoredPosition = new Vector3(0, 0, 0) + _offset;
            _image = _imageRectTransform.gameObject.AddComponent<Image>();
            _image.sprite = _sprite;
            _image.color = _imageData.Color;
        }

        public RectTransform GetRectTransform()
        {
            return _imageRectTransform;
        }
    }
}

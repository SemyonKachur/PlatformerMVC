using UnityEngine.UI;
using UnityEngine;

namespace PlatformerMVC
{
    public class UIFactory
    {
        private GameObject _canvas;
        private RectTransform _canvasComponent;

        public UIFactory()
        {
            _canvas = GameObject.Find("Canvas");
        }
        public RectTransform CreateNewCanvasElement()
        {
            _canvasComponent = new GameObject("NewCanvasElement").AddComponent<RectTransform>();
            _canvasComponent.SetParent(_canvas.transform);
            return _canvasComponent;
        }

        public RectTransform GetCanvasElement()
        {
            return _canvasComponent;
        }

    }
}

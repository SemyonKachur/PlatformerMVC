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
            _canvas = GameObject.Find("Canvas");
            _canvasComponent = new GameObject("NewCanvasElement").AddComponent<RectTransform>();
            _canvasComponent.SetParent(_canvas.transform);
            _canvasComponent.localPosition = Vector3.zero;
            return _canvasComponent;
        }

        public RectTransform GetCanvasElement()
        {
            return _canvasComponent;
        }

    }
}

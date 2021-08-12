using UnityEngine;
using UnityEngine.UI;

namespace PlatformerMVC
{
    [CreateAssetMenu(fileName = "UIElement", menuName = "UI/UIElement")]
    public class UIData : ScriptableObject
    {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private Vector3 _position;
        [SerializeField] private float _widthTransform;
        [SerializeField] private float _heightTransform;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private string _name;
        [SerializeField] private string _text = "Health:";
        [SerializeField] private Color _color;
        [SerializeField] private Font _font;

        public RectTransform RectTransform => _rectTransform;
        public Vector3 Position => _position;
        public float WidthTransform => _widthTransform;
        public float HeightTrnsform => _heightTransform;
        public Sprite Sprite => _sprite;
        public string Text => _text;
        public string Name => _name;
        public Color Color => _color;
        public Font Font => _font;
    }
}


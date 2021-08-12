using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlatformerMVC
{
    public class UIHealthView
    {
        private UIFactory _uiFactory;
        private PlayerViewController _playerViewController;
        private RectTransform _textRextTransform;
        private RectTransform _imageRectTransform;
        private Image _spriteImage;
        private Sprite _image;
        private float _imageWidth;
        private float _imageHeight;
        private UIData _imageData;
        List<RectTransform> health = new List<RectTransform>();

        public UIHealthView(UIFactory uiFactory,PlayerViewController playerViewController,int playerHealth, RectTransform healthTextTransform)
        {
            _playerViewController = playerViewController;
            _uiFactory = uiFactory;
            _imageData = Resources.Load<UIData>("UIHealthView");
            _image = _imageData.Sprite;
            _imageWidth = _imageData.WidthTransform;
            _imageHeight = _imageData.HeightTrnsform;
            _textRextTransform = healthTextTransform;
            for (int i = 0; i < playerHealth; i++)
            {
                health.Add(_uiFactory.CreateNewCanvasElement());
                health[i].localPosition = Vector3.zero;
            }
            for (int i = 0; i < health.Count; i++)
            {
                _imageRectTransform = health[i];
                _imageRectTransform.gameObject.name = "Health" + i;
                _imageRectTransform.anchorMin = new Vector2(0, 1);
                _imageRectTransform.anchorMax = new Vector2(0, 1);
                _imageRectTransform.pivot = new Vector2(0, 1);
                _imageRectTransform.localScale = new Vector3(1, 1, 1);
                _imageRectTransform.sizeDelta = new Vector2(_imageData.WidthTransform, _imageData.HeightTrnsform);
                if (i == 0) _imageRectTransform.anchoredPosition = new Vector3(0, 0, 0) + new Vector3(_textRextTransform.sizeDelta.x, 0, 0);
                else _imageRectTransform.anchoredPosition = Vector3.zero + new Vector3(healthTextTransform.sizeDelta.x + _imageWidth * i, 0, 0);
                _spriteImage = _imageRectTransform.gameObject.AddComponent<Image>();
                _spriteImage.sprite = _image;
                _spriteImage.color = _imageData.Color;
            }
            _playerViewController.Damage += Damage;
        }
        public void Damage(int damage)
        {
            if (damage == 1)
            {
                health[health.Count - 1].gameObject.SetActive(false);
                health.Remove(health[health.Count - 1]);
            }
            else
            {
                for (int i = 0; i < damage; i++)
                {
                    health[health.Count - 1].gameObject.SetActive(false);
                    health.Remove(health[health.Count - 1]);
                }
            }
        }
        public void Heal()
        {
            if (health.Count <= 4)
            {
                health.Add(_uiFactory.CreateNewCanvasElement());
                _imageRectTransform = health[health.Count - 1];
                _imageRectTransform.gameObject.name = "Health" + health.Count;
                _imageRectTransform.anchorMin = new Vector2(0, 1);
                _imageRectTransform.anchorMax = new Vector2(0, 1);
                _imageRectTransform.pivot = new Vector2(0, 1);
                _imageRectTransform.localScale = new Vector3(1, 1, 1);
                _imageRectTransform.sizeDelta = new Vector2(_imageData.WidthTransform, _imageData.HeightTrnsform);
                _spriteImage = _imageRectTransform.gameObject.AddComponent<Image>();
                _spriteImage.sprite = _image;
                _spriteImage.color = _imageData.Color;
                _imageRectTransform.parent.transform.position = Vector3.zero;
                if (health[0]) _imageRectTransform.localPosition = Vector3.zero + new Vector3(_textRextTransform.sizeDelta.x, 0, 0);
                else _imageRectTransform.localPosition = Vector3.zero + new Vector3(_textRextTransform.sizeDelta.x + _imageWidth * health.Count - 2, 0, 0);
            }
        }
    }    
}


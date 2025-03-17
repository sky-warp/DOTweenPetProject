using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Project.Scripts.Views
{
    internal class CardView : MonoBehaviour, IPointerClickHandler
    {
        public event Action<string> OnCardClicked;

        private Image _image;
        private string _id;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        public void Draw(Sprite sprite)
        {
            _image.sprite = sprite;
        }

        public void ClearSprite()
        {
            _image.sprite = null;
        }

        public void GetCardName(string cardID)
        {
            _id = cardID;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            string clickedID = eventData.pointerClick.GetComponent<CardView>()._id;

            OnCardClicked?.Invoke(clickedID);
        }
    }
}
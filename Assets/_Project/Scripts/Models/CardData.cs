using System;
using UnityEngine;

namespace _Project.Scripts.Models
{
    [Serializable]
    public class CardData
    {
        [SerializeField] private string _identifier;
        [SerializeField] private Sprite _sprite;
    
        public Sprite Sprite => _sprite;
        public string Identifier => _identifier;
    }
}
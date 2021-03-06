﻿using UnityEngine;
using UnityEngine.UI;

namespace FlexibleUI
{
    [CreateAssetMenu(menuName = "Flexible UI Data")]
    public class FlexibleUIData : ScriptableObject
    {
        public Sprite buttonSprite;
        public SpriteState buttonSpriteState;

        public Color defaultColor;
        public Color confirmColor;
        public Color declineColor;
        public Color warningColor;
    }
}
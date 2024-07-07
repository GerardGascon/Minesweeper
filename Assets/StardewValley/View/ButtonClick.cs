using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace StardewValley.View {
    public class ButtonClick : MonoBehaviour, IPointerClickHandler
    {
        public Action leftClick;
        public Action rightClick;
        public void OnPointerClick(PointerEventData eventData)
        {
            if(eventData.button==PointerEventData.InputButton.Left)
            {
                leftClick();
            }
            else if(eventData.button == PointerEventData.InputButton.Right)
            {
                rightClick();
            }
        }
    }
}

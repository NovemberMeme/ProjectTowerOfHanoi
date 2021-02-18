using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TowerOfHanoi
{
    public class ButtonInteractionHandler : InteractionHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            PointerClickResponse();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            PointerEnterResponse();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            PointerExitResponse();
        }
    }
}
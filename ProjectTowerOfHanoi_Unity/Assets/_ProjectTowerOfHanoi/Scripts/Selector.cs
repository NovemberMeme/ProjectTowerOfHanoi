using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TowerOfHanoi
{
    public class Selector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public int RodIndex;

        public void OnPointerClick(PointerEventData eventData)
        {
            if(!Utils.IsMoving)
                DelegateManager.onSelected?.Invoke(RodIndex);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            
        }
    }
}
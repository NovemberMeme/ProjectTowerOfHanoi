using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TowerOfHanoi
{
    public class Disk : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public int MyRodIndex;

        public DataBaseSO DB;

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log(eventData.pointerPress.name);

        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Debug.Log(eventData.pointerEnter.name);

        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Debug.Log("Exited");

        }
    }
}
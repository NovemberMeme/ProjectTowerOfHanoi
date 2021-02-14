using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TowerOfHanoi
{
    public class InteractionHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public int RodIndex;

        private bool isHeldDiskAnimating = false;

        private ISelect MySelectorBehavior;
        private IStartHover MyStartHoverBehavior;

        private void Awake()
        {
            MySelectorBehavior = GetComponent<ISelect>();
            MyStartHoverBehavior = GetComponent<IStartHover>();
        }

        private void OnEnable()
        {
            
        }

        private void SetDiskState(bool _isAnimating)
        {

        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (!Utils.IsMoving)
            {
                MySelectorBehavior.OnSelect(RodIndex);
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if(!Utils.IsMoving)
                MyStartHoverBehavior.OnStartHover();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            
        }
    }
}
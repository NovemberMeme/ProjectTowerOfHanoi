using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    public class InteractionHandler : MonoBehaviour
    {
        public DataBaseSO DB;

        protected IPickUp MyPickUpBehavior;
        protected IPlace MyPlaceBehavior;
        protected IReturn MyReturnBehavior;
        protected IStartHover MyStartHoverBehavior;
        protected IStopHover MyStopHoverBehavior;

        private void Awake()
        {
            MyPickUpBehavior = GetComponent<IPickUp>();
            MyPlaceBehavior = GetComponent<IPlace>();
            MyReturnBehavior = GetComponent<IReturn>();
            MyStartHoverBehavior = GetComponent<IStartHover>();
            MyStopHoverBehavior = GetComponent<IStopHover>();
        }

        protected virtual void PointerClickResponse()
        {
            
        }

        protected virtual void PointerEnterResponse()
        {
            MyStartHoverBehavior.OnStartHover();
        }

        protected virtual void PointerExitResponse()
        {
            MyStopHoverBehavior.OnStopHover();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TowerOfHanoi
{
    public class RodInteractionHandler : InteractionHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public int RodIndex;

        protected IPickUp MyPickUpBehavior;
        protected IPlace MyPlaceBehavior;
        protected IReturn MyReturnBehavior;

        protected override void Awake()
        {
            base.Awake();
            MyPickUpBehavior = GetComponent<IPickUp>();
            MyPlaceBehavior = GetComponent<IPlace>();
            MyReturnBehavior = GetComponent<IReturn>();
        }

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

        public override void PointerClickResponse()
        {
            if (!DB.GameIsOngoing)
                return;

            if (DB.CurrentSO_StateData.SO_State != DB.AnimatingState)
            {
                if (DB.CurrentSO_StateData.SO_State == DB.HeldState)
                {
                    if (DB.CurrentSO_StateData.RodIndex == RodIndex)
                    {
                        MyReturnBehavior.OnReturn(RodIndex);
                    }
                    else
                    {
                        MyPlaceBehavior.OnPlace(RodIndex);
                    }
                }
                else if (DB.CurrentSO_StateData.SO_State == DB.PlacedState)
                {
                    MyPickUpBehavior.OnPickUp(RodIndex);
                }
            }
        }

        public override void PointerEnterResponse()
        {
            if (!DB.GameIsOngoing)
                return;

            if (DB.CurrentSO_StateData.SO_State == DB.PlacedState &&
                            !DB.IsOnHoverCooldown)
            {
                MyStartHoverBehavior.OnStartHover();
            }
        }

        public override void PointerExitResponse()
        {
            if (!DB.GameIsOngoing)
                return;

            if (DB.CurrentSO_StateData.SO_State == DB.PlacedState)
            {
                MyStopHoverBehavior.OnStopHover();
            }
        }
    }
}
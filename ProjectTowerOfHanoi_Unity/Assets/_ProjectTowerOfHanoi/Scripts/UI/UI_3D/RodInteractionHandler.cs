using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TowerOfHanoi
{
    public class RodInteractionHandler : InteractionHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public int RodIndex;

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

        protected override void PointerClickResponse()
        {
            if (DB.CurrentSO_StateData.SO_State != DB.StateDefinition.AnimatingState)
            {
                if (DB.CurrentSO_StateData.SO_State == DB.StateDefinition.HeldState)
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
                else if (DB.CurrentSO_StateData.SO_State == DB.StateDefinition.PlacedState)
                {
                    MyPickUpBehavior.OnPickUp(RodIndex);
                }
            }
        }

        protected override void PointerEnterResponse()
        {
            if (DB.CurrentSO_StateData.SO_State == DB.StateDefinition.PlacedState &&
                            !DB.IsOnHoverCooldown)
            {
                MyStartHoverBehavior.OnStartHover();
            }
        }

        protected override void PointerExitResponse()
        {
            if (DB.CurrentSO_StateData.SO_State == DB.StateDefinition.PlacedState &&
                            !DB.IsOnHoverCooldown)
            {
                MyStopHoverBehavior.OnStopHover();
            }
        }

        private IEnumerator _BeginHoverSFXCooldown()
        {
            DB.IsOnHoverCooldown = true;
            yield return new WaitForSeconds(DB.HoverSFXCooldown);
            DB.IsOnHoverCooldown = false;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TowerOfHanoi
{
    public class InteractionHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public int RodIndex;

        public DataBaseSO DB;

        private IPickUp MyPickUpBehavior;
        private IPlace MyPlaceBehavior;
        private IReturn MyReturnBehavior;
        private IStartHover MyStartHoverBehavior;
        private IStopHover MyStopHoverBehavior;

        private void Awake()
        {
            MyPickUpBehavior = GetComponent<IPickUp>();
            MyPlaceBehavior = GetComponent<IPlace>();
            MyReturnBehavior = GetComponent<IReturn>();
            MyStartHoverBehavior = GetComponent<IStartHover>();
            MyStopHoverBehavior = GetComponent<IStopHover>();
        }

        private void OnEnable()
        {

        }

        private void OnDisable()
        {

        }

        private void SetDiskState(SO_StateData _newDiskStateData)
        {

        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (DB.CurrentSO_StateData.SO_State != DB.StateDefinition.AnimatingState)
            {
                if (DB.CurrentSO_StateData.SO_State == DB.StateDefinition.HeldState)
                {
                    if(DB.CurrentSO_StateData.RodIndex == RodIndex)
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

        public void OnPointerEnter(PointerEventData eventData)
        {
            if(DB.CurrentSO_StateData.SO_State == DB.StateDefinition.PlacedState &&
                !DB.IsOnHoverCooldown)
            {
                MyStartHoverBehavior.OnStartHover();
            }
        }

        public void OnPointerExit(PointerEventData eventData)
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
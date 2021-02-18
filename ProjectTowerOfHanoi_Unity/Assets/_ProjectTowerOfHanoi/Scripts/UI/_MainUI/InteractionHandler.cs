using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    /// <summary>
    /// The main script of the part of the game which follows the strategy design pattern, allowing a developer to define
    /// multiple behaviors per interface, while this script simply calls the interface function/s and should never need
    /// to be modified in the future, although it can be expanded upon usually by using inheritance like with 
    /// the RodInteractionHandler
    /// </summary>
    public class InteractionHandler : MonoBehaviour
    {
        public DataBaseSO DB;

        protected IClick MyClickBehavior;
        protected IStartHover MyStartHoverBehavior;
        protected IStopHover MyStopHoverBehavior;

        protected virtual void Awake()
        {
            MyClickBehavior = GetComponent<IClick>();
            MyStartHoverBehavior = GetComponent<IStartHover>();
            MyStopHoverBehavior = GetComponent<IStopHover>();
        }

        public virtual void PointerClickResponse()
        {
            MyClickBehavior.OnClick();
        }

        public virtual void PointerEnterResponse()
        {
            MyStartHoverBehavior.OnStartHover();
        }

        public virtual void PointerExitResponse()
        {
            MyStopHoverBehavior.OnStopHover();
        }
    }
}
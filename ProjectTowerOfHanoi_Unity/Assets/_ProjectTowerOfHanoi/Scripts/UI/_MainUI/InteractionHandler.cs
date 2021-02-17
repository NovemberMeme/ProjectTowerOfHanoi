using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
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

        protected virtual void PointerClickResponse()
        {
            MyClickBehavior.OnClick();
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Core
{
    public abstract class BaseController : MonoBehaviour
    {
        private BaseState currentyActiveState;

        protected abstract void InjectReferences();

        protected virtual void Start()
        {
            InjectReferences();
            currentyActiveState?.InstantiateState();
        }
        protected virtual void Update()
        {
            currentyActiveState?.UpdateState();
        }
        protected virtual void OnDestroy()
        {
            currentyActiveState?.DestroyState();
        }

        public void ChangeState(BaseState newState)
        {
            currentyActiveState?.DestroyState();
            currentyActiveState = newState;
            currentyActiveState?.InstantiateState();
        }
    }
}
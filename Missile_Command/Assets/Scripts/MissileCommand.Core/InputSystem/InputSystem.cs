using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MissileCommand.Core
{
    public class InputSystem : MonoBehaviour
    {
        [SerializeField]
        private List<RocketLauncherController> rocketLaunchers;
        [SerializeField]
        private Camera mainCamera;
        public void UpdateInputs()
        {
            if (Input.GetMouseButtonDown(0) && !IsMouseOverUI())
            {
                LaunchMissile(mainCamera.ScreenToWorldPoint(Input.mousePosition));
            }
        }

        private bool IsMouseOverUI()
        {
            return EventSystem.current.IsPointerOverGameObject();
        }

        private void LaunchMissile(Vector2 clickPosition)
        {
            RocketLauncherController launcherToShot = null;
            float closestDistance = float.MaxValue;
            foreach (var launcher in rocketLaunchers)
            {
                if (launcher.IsEmpty())
                    continue;
                if (launcher.IsDisabled())
                    continue;

                float distanceBetween = Vector2.Distance(launcher.transform.position, clickPosition);
                if (distanceBetween < closestDistance)
                {
                    closestDistance = distanceBetween;
                    launcherToShot = launcher;
                }
            }
            if (launcherToShot == null)
                return;
            launcherToShot.FireMissile(clickPosition);
        }
    } 
}
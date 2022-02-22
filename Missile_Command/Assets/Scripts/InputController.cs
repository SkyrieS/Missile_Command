using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private List<RocketLauncherController> rocketLaunchers;
    [SerializeField] private Camera mainCamera;
    void Update()
    {
        //Test
        if (Input.GetMouseButtonDown(0))
        {

            LaunchMissile(mainCamera.ScreenToWorldPoint(Input.mousePosition));
        }
    }

    private void LaunchMissile(Vector2 clickPosition)
    {
        RocketLauncherController launcherToShot = null;
        float closestDistance = float.MaxValue;
        foreach (var launcher in rocketLaunchers)
        {
            if(launcher.IsEmpty())
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

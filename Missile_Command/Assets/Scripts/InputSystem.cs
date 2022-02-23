using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    [SerializeField] 
    private List<RocketLauncher> rocketLaunchers;
    [SerializeField]
    private Camera mainCamera;
    public void UpdateInputs()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LaunchMissile(mainCamera.ScreenToWorldPoint(Input.mousePosition));
        }
    }

    private void LaunchMissile(Vector2 clickPosition)
    {
        RocketLauncher launcherToShot = null;
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

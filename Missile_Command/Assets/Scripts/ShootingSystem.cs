using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    [SerializeField]
    RocketLauncher[] rocketLaunchers;

    public void Initialize()
    {
        foreach (var launchers in rocketLaunchers)
        {
            launchers.Initialize();
        }
    }

    public void UpdateLaunchers()
    {
        foreach (var launchers in rocketLaunchers)
        {
            launchers.UpdateMissiles();
        }
    }

    public void ResetLaunchers()
    {
        foreach (var launchers in rocketLaunchers)
        {
            launchers.UpdateMissiles();
        }
    }
}

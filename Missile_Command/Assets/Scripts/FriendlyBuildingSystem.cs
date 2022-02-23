using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FriendlyBuildingSystem : MonoBehaviour
{
    [SerializeField] 
    private CityController[] cityController;
    public void Initialize(UnityAction events)
    {
        foreach (var cityController in cityController)
        {
            cityController.Initialize(events);
        }
    }

    public void Destroy()
    {
        foreach (var cityController in cityController)
        {
            cityController.DestroyEvents();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D),typeof(Rigidbody2D))]
public class CityController : MonoBehaviour
{
    private UnityAction events;

    public void Initialize(UnityAction events)
    {
        this.events = events;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DestroyCity();
    }

    public void DestroyEvents()
    {
        events = null;
    }

    private void DestroyCity()
    {
        this.gameObject.SetActive(false);
        events.Invoke();
    }
}

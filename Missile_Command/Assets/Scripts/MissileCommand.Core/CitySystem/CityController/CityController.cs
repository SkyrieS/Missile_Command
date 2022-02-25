using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MissileCommand.Core
{
    [RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
    public class CityController : MonoBehaviour
    {
        private UnityAction events;

        public void Initialize(UnityAction firstEvent, UnityAction secondEvent)
        {
            this.events += firstEvent;
            this.events += secondEvent;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Enemy")
            {
                DestroyCity();
            }
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
}

using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace MissileCommand.UI
{
    public abstract class BaseView : MonoBehaviour
    {
        public virtual void ShowView()
        {
            gameObject.SetActive(true);
        }
        public virtual void HideView()
        {
            gameObject.SetActive(false);
        }
    } 
}

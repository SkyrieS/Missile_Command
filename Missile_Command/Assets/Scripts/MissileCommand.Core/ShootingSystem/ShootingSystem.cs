using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MissileCommand.Core
{
    public class ShootingSystem : MonoBehaviour
    {
        [SerializeField]
        RocketLauncherController[] rocketLaunchers;

        private int numberOfAliveLaunchers;
        public int NumberOfAlivelaunchers => numberOfAliveLaunchers;

        public void Initialize(UnityAction events)
        {
            numberOfAliveLaunchers = rocketLaunchers.Length;
            foreach (var launchers in rocketLaunchers)
            {
                launchers.gameObject.SetActive(true);
                launchers.enabled = true;
                launchers.Initialize(events, DecreasenumberOfAliveLaunchers);
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
                launchers.ResetMissiles();
            }
        }

        public void DecreasenumberOfAliveLaunchers()
        {
            numberOfAliveLaunchers--;
        }
    } 
}
using UnityEngine;
using UnityEngine.Events;

namespace MissileCommand.Core
{
    public class CitySystem : MonoBehaviour
    {
        [SerializeField]
        private CityController[] cityController;

        private int numberOfAliveCites;
        public int NumberOfAliveCites => numberOfAliveCites;

        public void Initialize(UnityAction events)
        {
            numberOfAliveCites = cityController.Length;
            foreach (var cityController in cityController)
            {
                cityController.gameObject.SetActive(true);
                cityController.Initialize(events, DecreasenumberOfAliveCites);
            }
        }

        public void ResetCities()
        {
            numberOfAliveCites = cityController.Length;
            foreach (var cityController in cityController)
            {
                cityController.gameObject.SetActive(true);
            }
        }

        public void Destroy()
        {
            foreach (var cityController in cityController)
            {
                cityController.gameObject.SetActive(false);
                cityController.DestroyEvents();
            }
        }

        public void DecreasenumberOfAliveCites()
        {
            numberOfAliveCites--;
        }

    } 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StardewValley.View
{
    public class PassDayButton : MonoBehaviour
    {
        Farm farm => FindAnyObjectByType<Dependencies>().farm;

        private void PassDay()
        {
            farm.PassDay();
        }

        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(PassDay);
        }
    }
}


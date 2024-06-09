using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StardewValley.View
{
    public class PassDayButton : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(PassDay);
        }

        private void PassDay()
        {
            FindAnyObjectByType<Dependencies>().passday.Run();
        }
    }
}


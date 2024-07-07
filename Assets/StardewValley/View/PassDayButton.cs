using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StardewValley.View
{
    public class PassDayButton : MonoBehaviour
    {
        PassDay passDay;

        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(PassDay);
        }
        public void Inject(PassDay passDay)
        {
            this.passDay = passDay;
        }

        private void PassDay()
        {
            passDay.Run();

        }
    }
}


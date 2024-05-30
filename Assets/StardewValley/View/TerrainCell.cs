using UnityEngine;
using UnityEngine.UI;

public class TerrainCell : MonoBehaviour
{

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(Water);
    }

    private void Water() 
    {
        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverHandeler : MonoBehaviour
{
    
    public void OnHoverOpen(GameObject Canvas)
    {
        Canvas.SetActive(true);
    }
    public void OnHoverClose(GameObject Canvas)
    {
        Canvas.SetActive(false);
    }
}

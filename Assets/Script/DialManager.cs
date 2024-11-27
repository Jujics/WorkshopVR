using System.Collections;
using System.Collections.Generic;
using LevelUP.Dial;
using TMPro;
using UnityEngine;

public class DialManager : MonoBehaviour 
{
    public TMP_Text[] dials;
    public string[] dialTexts;
    public GameObject Box;
    BoxOpening BoxOpening => Box.GetComponent<BoxOpening>();
    
    public void OpenDial()
    {
        if (dials[0].text == dialTexts[0] && dials[1].text == dialTexts[1] && dials[2].text == dialTexts[2] &&
            dials[3].text == dialTexts[3])
        {
            //
            BoxOpening.BoxOpened = true;
        }
    }
}

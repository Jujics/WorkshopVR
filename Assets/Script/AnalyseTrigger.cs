using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnalyseTrigger : MonoBehaviour
{
    public TMP_Text text;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pierre")
        {
            text.text = "Berylium 20% \n Carbone 80%";
        }
    }
}

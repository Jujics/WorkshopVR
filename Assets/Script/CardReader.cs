using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardReader : MonoBehaviour
{
    private bool[] cardsSwiped = {false,false,false};
    private Transform[] CardsSlot;
    private int i = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Card")
        {
            cardsSwiped[i] = true;
            other.gameObject.transform.position = CardsSlot[i].position;
            i++;
        }
    }

    private void CheckIfAllCardsSwiped()
    {
        
    }
}

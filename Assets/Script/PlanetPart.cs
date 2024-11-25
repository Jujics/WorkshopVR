using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetPart : MonoBehaviour
{
    public GameObject OtherPart;
    public GameObject CombinedItem;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == OtherPart)
        {
            CompleteItem();
        }
    }
    
    private void CompleteItem()
    {
        CombinedItem.transform.SetParent(transform.parent);
        CombinedItem.SetActive(true);
        Destroy(OtherPart.gameObject);
        Destroy(gameObject);
    }
}

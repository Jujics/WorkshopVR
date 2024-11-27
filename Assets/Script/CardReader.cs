using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardReader : MonoBehaviour
{
    public Transform[] CardsSlot;
    public GameObject[] CardInserted;
    public GameObject[] PlanetList;
    public bool[] cardsSwiped;
    private int i = 0;

    private void Start()
    {
        cardsSwiped = new bool[CardsSlot.Length];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Carte") && i < CardsSlot.Length)
        {
            cardsSwiped[i] = true;
            CardInserted[i].SetActive(true);
            PlanetList[i].SetActive(true);
            Destroy(other.gameObject);
            //son
            i++;
            CheckIfAllCardsSwiped();
        }
    }

    private void CheckIfAllCardsSwiped()
    {
        bool allSwiped = Array.TrueForAll(cardsSwiped, swiped => swiped);

        if (allSwiped)
        {
            Debug.Log("All cards swiped!");
        }
    }
}
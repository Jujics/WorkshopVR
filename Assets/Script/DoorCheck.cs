using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCheck : MonoBehaviour
{
    public GameObject door;
    public GameObject CardReader;
    public Transform StartPos;
    public Transform EndPos;
    public float speed = 1.0f;
    private bool IsMoving = false;
    private float startTime;
    private float journeyLength;
    private float fractionOfJourney;
    private bool HasMoved = false;
    
    CardReader cardReader;
    

    void Start()
    {
        startTime = Time.time;
        cardReader = CardReader.GetComponent<CardReader>();
        journeyLength = Vector3.Distance(StartPos.position, EndPos.position);
    }
    void Update()
    {
        if (HasMoved)
        {
            return;
        }
        bool allSwiped = Array.TrueForAll(cardReader.cardsSwiped, swiped => swiped);
        if (allSwiped)
        {
            transform.position = EndPos.position;
            HasMoved = true;
        }
    }
}

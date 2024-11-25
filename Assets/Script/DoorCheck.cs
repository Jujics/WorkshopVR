using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCheck : MonoBehaviour
{
    public GameObject door;
    public GameObject CodeManagerHolder;
    public Transform StartPos;
    public Transform EndPos;
    public float speed = 1.0f;
    private bool IsMoving = false;
    private float startTime;
    private float journeyLength;
    private float fractionOfJourney;
    
    CodeManager codeManager;
    Collider doorCollider;

    void Start()
    {
        startTime = Time.time;
        codeManager = CodeManagerHolder.GetComponent<CodeManager>();
        doorCollider = GetComponent<Collider>();
        journeyLength = Vector3.Distance(StartPos.position, EndPos.position);
    }
    void Update()
    {
        if (codeManager.HasEnteredCode3 == true && fractionOfJourney <= 1.0f)
        {
            if (!IsMoving)
            {
                startTime = Time.time;
                IsMoving = true;
            }
            doorCollider.enabled = false;
            float distCovered = (Time.time - startTime) * speed;
            fractionOfJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(StartPos.position, EndPos.position, fractionOfJourney);
        }
    }
}

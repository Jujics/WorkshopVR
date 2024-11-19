using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCheck : MonoBehaviour
{
    public GameObject door;
    public GameObject GameManagerHolder;
    public Transform StartPos;
    public Transform EndPos;
    public float speed = 1.0f;
    private bool IsMoving = false;
    private float startTime;
    private float journeyLength;
    private float fractionOfJourney;
    
    GameManager gameManager;
    Collider doorCollider;

    void Start()
    {
        startTime = Time.time;
        gameManager = GameManagerHolder.GetComponent<GameManager>();
        doorCollider = GetComponent<Collider>();
        journeyLength = Vector3.Distance(StartPos.position, EndPos.position);
    }
    void Update()
    {
        if (gameManager.gameState == GameState.InGameAll && fractionOfJourney <= 1.0f)
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

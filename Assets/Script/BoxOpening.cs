using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class BoxOpening : MonoBehaviour
{
    public InputActionReference TriggerInputAction; 
    public GameObject BoxDoor;
    public GameObject BoxDoor2;
    public bool BoxOpened = false;
    public GameObject Pierre;
    private bool isScrewdriverInZone = false; 
    private bool isHandPressingTrigger = false; 
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Screwdriver"))
        {
            isScrewdriverInZone = true;
            StartCoroutine(WaitForTriggerPress());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Screwdriver"))
        {
            isScrewdriverInZone = false;
            StopAllCoroutines();
        }
    }

    private void Update()
    {
        if (BoxOpened)
        {
            StartCoroutine(OpenBox());
            Pierre.SetActive(true);
        }
    }

    private IEnumerator WaitForTriggerPress()
    {
        while (isScrewdriverInZone)
        {
            float triggerValue = TriggerInputAction.action.ReadValue<float>();

            if (triggerValue >= 0.9f) 
            {
                isHandPressingTrigger = true;
                BoxOpened = true;
                break; 
            }

            yield return null;
        }

        isHandPressingTrigger = false;
    }

    private IEnumerator OpenBox()
    {
        float targetAngle = -20f; 
        float speed = 50f;

        while (BoxDoor.transform.localEulerAngles.x > targetAngle || BoxDoor2.transform.localEulerAngles.x > targetAngle)
        {
            float currentAngleBoxDoor = BoxDoor.transform.localEulerAngles.x;
            float currentAngleBoxDoor2 = BoxDoor2.transform.localEulerAngles.x;

            if (currentAngleBoxDoor > 180) currentAngleBoxDoor -= 360;
            if (currentAngleBoxDoor2 > 180) currentAngleBoxDoor2 -= 360;

            float newAngleBoxDoor = Mathf.MoveTowards(currentAngleBoxDoor, targetAngle, speed * Time.deltaTime);
            float newAngleBoxDoor2 = Mathf.MoveTowards(currentAngleBoxDoor2, targetAngle, speed * Time.deltaTime);

            BoxDoor.transform.localEulerAngles = new Vector3(newAngleBoxDoor, -90, -90);
            BoxDoor2.transform.localEulerAngles = new Vector3(newAngleBoxDoor2, 90, 270);

            yield return null; 
        }
    }
}

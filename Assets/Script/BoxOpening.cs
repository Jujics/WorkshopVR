using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class BoxOpening : MonoBehaviour
{
    public InputActionReference TriggerInputAction; 
    public GameObject BoxDoor;
    public GameObject BoxDoor2;
    public bool BoxOpened = false;
    public bool Has1Key;
    public bool Has2Key;
    public bool Has3Key;
    public GameObject[] GameObjectsSpawned;
    public string[] TagList;
    public bool isObject1InZone = false; 
    public bool isObject0InZone = false; 
    public bool isObject2InZone = false;
    public float target;
    public AudioSource OpenAudio;
    private bool isHandPressingTrigger = false; 
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagList[0]))
        {
            isObject0InZone = true;
        }

        if (Has2Key || Has3Key)
        {
            if (other.CompareTag(TagList[1]))
            {
                isObject1InZone = true;
            }
        }

        if (Has3Key)
        {
            if (other.CompareTag(TagList[2]))
            {
                isObject2InZone = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(TagList[0]))
        {
            isObject0InZone = false;
        }

        if (Has2Key || Has3Key)
        {
            if (other.CompareTag(TagList[1]))
            {
                isObject1InZone = false;
            }
        }

        if (Has3Key)
        {
            if (other.CompareTag(TagList[2]))
            {
                isObject2InZone = false;
            }
        }
    }

    private void Update()
    {
        if (Has1Key)
        {
            if (isObject0InZone)
            {
                StartCoroutine(WaitForTriggerPress());
            }
        }

        if (Has2Key)
        {
            if (isObject1InZone && isObject0InZone)
            {
                StartCoroutine(WaitForTriggerPress());
            }
        }

        if (Has3Key)
        {
            if (isObject1InZone && isObject0InZone && isObject2InZone)
            {
                StartCoroutine(WaitForTriggerPress());
            }
        }
        
        if (BoxOpened)
        {
            StartCoroutine(OpenBox());
            foreach (GameObject go in GameObjectsSpawned)
            {
                go.SetActive(true);
                OpenAudio.Play();
            }
            BoxOpened = false;
        }
    }

    private IEnumerator WaitForTriggerPress()
    {
        if (Has1Key)
        {
            while (isObject0InZone)
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
        }

        if (Has2Key)
        {
            while (isObject1InZone && isObject0InZone)
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
        }

        if (Has3Key)
        {
            while (isObject1InZone && isObject0InZone && isObject2InZone)
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
        }

        isHandPressingTrigger = false;
    }

    private IEnumerator OpenBox()
    {
        float targetAngle = target; 
        float speed = 50f;

        while (BoxDoor.transform.localEulerAngles.x > targetAngle || BoxDoor2.transform.localEulerAngles.x > targetAngle)
        {
            float currentAngley = BoxDoor.transform.localEulerAngles.y;
            float currentAnglez = BoxDoor2.transform.localEulerAngles.z;
            float currentAngleBoxDoor = BoxDoor.transform.localEulerAngles.x;
            float currentAngleBoxDoor2 = BoxDoor2.transform.localEulerAngles.x;

            if (currentAngleBoxDoor > 180) currentAngleBoxDoor -= 360;
            if (currentAngleBoxDoor2 > 180) currentAngleBoxDoor2 -= 360;

            float newAngleBoxDoor = Mathf.MoveTowards(currentAngleBoxDoor, targetAngle, speed * Time.deltaTime);
            float newAngleBoxDoor2 = Mathf.MoveTowards(currentAngleBoxDoor2, targetAngle, speed * Time.deltaTime);

            BoxDoor.transform.localEulerAngles = new Vector3(newAngleBoxDoor, currentAngley, currentAnglez);
            BoxDoor2.transform.localEulerAngles = new Vector3(newAngleBoxDoor2, currentAngley, currentAnglez);

            yield return null; 
        }
    }

    
}

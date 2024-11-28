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
    public Vector3 targetBox1EulerX;
    public Vector3 targetBox2EulerX;
    //public AudioSource OpenAudio;
    
    
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
            BoxOpened = true;
            StartCoroutine(OpenBox());
            //OpenAudio.Play();
            foreach (GameObject go in GameObjectsSpawned)
            {
                go.SetActive(true);
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
        /*BoxDoor.transform.rotation = Quaternion.Euler(targetBox1EulerX, BoxDoor.transform.rotation.y, BoxDoor.transform.rotation.z);
        BoxDoor2.transform.rotation = Quaternion.Euler(targetBox2EulerX, BoxDoor2.transform.rotation.y, BoxDoor2.transform.rotation.z);
        
        yield break;*/
        
        // targetBox1Euler => un Vector3 à rentrer direct en tant que valeur publique
        // targetBox2Euler => un Vector3 à rentrer direct en tant que valeur publique

        float animationDuration = 1f; //en secondes
        Vector3 startBox1Euler = BoxDoor.transform.localEulerAngles;
        Vector3 startBox2Euler = BoxDoor2.transform.localEulerAngles;
        float startBox1EulerX = startBox1Euler.x;
        float startBox2EulerX = startBox2Euler.x;
        float startBox1EulerY = startBox1Euler.y;
        float startBox2EulerY = startBox2Euler.y;
        float startBox1EulerZ = startBox1Euler.z;
        float startBox2EulerZ = startBox2Euler.z;
        
        while (targetBox1EulerX.x < -180f)
        {
            targetBox1EulerX.x += 360f;
        }
        targetBox1EulerX.x %= 360f;
        
        while (targetBox2EulerX.x < -180f)
        {
            targetBox2EulerX.x += 360f;
        }
        targetBox2EulerX.x %= 360f;
        
        while (targetBox1EulerX.y < -180f)
        {
            targetBox1EulerX.y += 360f;
        }
        targetBox1EulerX.y %= 360f;
        
        while (targetBox2EulerX.y < -180f)
        {
            targetBox2EulerX.y += 360f;
        }
        targetBox2EulerX.y %= 360f;
        
        while (targetBox1EulerX.z < -180f)
        {
            targetBox1EulerX.z += 360f;
        }
        targetBox1EulerX.z %= 360f;
        
        while (targetBox2EulerX.z < -180f)
        {
            targetBox2EulerX.z += 360f;
        }
        targetBox2EulerX.z %= 360f;
        
        float progression = 0f;

        while(progression < animationDuration)
        {
            BoxDoor.transform.localEulerAngles = new Vector3(Mathf.Lerp(startBox1EulerX, targetBox1EulerX.x, progression / animationDuration),
                Mathf.Lerp(startBox1EulerY, targetBox1EulerX.y, progression / animationDuration), Mathf.Lerp(startBox1EulerZ, targetBox1EulerX.z, progression / animationDuration));//Vector3.Lerp(startBox1Euler, targetBox1Euler, progression / animationDuration);
            BoxDoor2.transform.localEulerAngles = new Vector3(Mathf.Lerp(startBox2EulerX, targetBox2EulerX.x, progression / animationDuration),
                Mathf.Lerp(startBox2EulerY, targetBox2EulerX.y, progression / animationDuration), Mathf.Lerp(startBox2EulerZ, targetBox2EulerX.z, progression / animationDuration));//Vector3.Lerp(startBox2Euler, targetBox2Euler, progression / animationDuration);
      
            yield return null;
            progression += Time.deltaTime;
            
        }
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerialUISummoner : MonoBehaviour
{
    [SerializeField] private float minDistance = 2;
    [SerializeField] private bool showing = false;
    
    protected Animator[] children;

    void Start()
    {
        children = GetComponentsInChildren<Animator>();
        for (int a = 0; a < children.Length; a++)
        {
            children[a].SetBool("Shown", showing);
        }
    }

    void Update()
    {
        Vector3 delta = Camera.main.transform.position - transform.position;
        if (delta.magnitude < minDistance) 
        {
            if (showing) return;
            showing = true;
            for(int a = 0; a < children.Length; a++)
            {
                children[a].SetBool("Shown", true);
            }
        }
        else
        {
            if(!showing) return;
            showing = false;
            for(int a = 0; a < children.Length; a++)
            {
                children[a].SetBool("Shown", false);
            }
        }
    }
}

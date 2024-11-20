using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerialUISummoner : MonoBehaviour
{
    public float minDistance = 2;
    public bool EnterIn = false;
    
    protected Animator[] children;

    void Start()
    {
        children = GetComponentsInChildren<Animator>();
        for (int a = 0; a < children.Length; a++)
        {
            children[a].SetBool("EnterIn", EnterIn);
        }
    }

    void Update()
    {
        Vector3 delta = Camera.main.transform.position - transform.position;
        if (delta.magnitude < minDistance) 
        {
            if (EnterIn) return;
            EnterIn = true;
            for(int a = 0; a < children.Length; a++)
            {
                children[a].SetBool("EnterIn", true);
            }
        }
        else
        {
            if(!EnterIn) return;
            EnterIn = false;
            for(int a = 0; a < children.Length; a++)
            {
                children[a].SetBool("EnterIn", false);
            }
        }
    }
}
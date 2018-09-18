using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControl : MonoBehaviour {
    public float launchForce;
    public _3CSettings settings;
    private Vector3 screenPoint;
    private Vector3 offset;
    private Rigidbody2D rgb;
    private Transform character;
    private int forceIndex;
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        character = transform.parent;
    }

    void Update()
    {
        
    }

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        character.rotation = Quaternion.Inverse(Rotation());
        Launch();
    }

    private void OnMouseUp()
    {
        transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        Debug.Log("Force Index : " + forceIndex);
        Debug.Log("Force to Add : " + settings.parts[forceIndex] * settings.maxForce / 100);
    }

    Quaternion Rotation()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion mouseRotation = Quaternion.LookRotation(Vector3.back, -(mousePos - character.position));
        return mouseRotation;
    }

    float Launch()
    {
        //code here : Heroes fly with force
        Vector3 mousePos = Input.mousePosition - new Vector3(375, 1334/2);
        var worldToPixels = ((Screen.height / 2.0f) / Camera.main.orthographicSize);
        float distance = Vector3.Distance(mousePos, character.position) /worldToPixels;
        if(distance < settings.maxDistance / worldToPixels)
        {
            forceIndex = Mathf.RoundToInt(distance / (settings.distancePerPart / worldToPixels)) - 1;
            if(forceIndex >= 0)
            {
                transform.localPosition = new Vector3(0, -distance, 0);
            }
            
        }
        return 0.0f;
    }
}
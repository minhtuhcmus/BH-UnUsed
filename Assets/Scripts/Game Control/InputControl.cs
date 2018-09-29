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

    public float resForce;
    private float t;
    private Vector3 orgPoint;

    private bool isFly;
    private bool isClick;
    private Vector3 direction;
    void Start()
    {

        character = transform.parent;
        rgb = character.GetComponent<Rigidbody2D>();
        

        t = 0;
        isFly = false;
        isClick = false;
    }

    void Update()
    {
       
    }

    void OnMouseDown()
    {
        
        isClick = true;
        orgPoint = Input.mousePosition;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));



    }

    void OnMouseDrag()
    {
        character.rotation = Quaternion.Inverse(Rotation());
        direction = orgPoint - Input.mousePosition;
        Launch();
    }

    private void OnMouseUp()
    {
        transform.localScale = new Vector3(1, 1, 1);
        transform.localPosition = Vector3.zero;



        //Debug.Log("Force Index : " + forceIndex);

        launchForce = settings.parts[forceIndex] * settings.maxForce / 100;
        //Debug.Log("Force to Add : " + launchForce);
        
        Fly();
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
        float distance = Vector3.Distance(mousePos, character.position* worldToPixels) /worldToPixels;
        Debug.Log(mousePos);
        Debug.Log(character.position);
        if (distance < settings.maxDistance / worldToPixels)
        {
            forceIndex = Mathf.RoundToInt(distance / (settings.distancePerPart / worldToPixels)) - 1;
            if(forceIndex >= 0)
            {
                transform.localScale = new Vector3(0.2f, distance*0.5f, 1);
                transform.localPosition = new Vector3(0, distance / 4, 0);
            }
            
        }

        
        return 0.0f;


    }

    void Fly()
    {
        //Debug.Log("Fly Force : " + launchForce.ToString());
        isFly = true;
        rgb.AddForce(direction.normalized * launchForce);
    }


}
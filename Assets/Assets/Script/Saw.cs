using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour {
    private float minY = 1000;
    private float maxY = 2000;
    private float range = 200;
    private int side = 0;
    private bool isEnable = false;

    public _3CSettings settings;

    private bool isRunToA = false;
    private Vector3 pos_A;
    private Vector3 pos_B;
    private float speed = 0.5f;

    public void intit(float minY, float maxY, float range, int side)
    {
        float worldToPixels = ((Screen.height / 2.0f) / Camera.main.orthographicSize);

        Vector3 position_Random = new Vector3((side * settings.screenWidth - settings.screenWidth / 2) / worldToPixels, (Random.Range(minY, maxY) - settings.screenHeight / 2) / worldToPixels, 0.0f);
        pos_A = position_Random - new Vector3(0, range / worldToPixels / 2, 0);
        pos_B = position_Random + new Vector3(0, range / worldToPixels / 2, 0);
        Debug.Log(position_Random);
        Debug.Log(pos_A);
        Debug.Log(pos_B);

        if (Random.Range(0, 2) == 0)
        {
            transform.position = pos_B;
            StartCoroutine(MoveToA());
        }
        else
        {
            transform.position = pos_A;
            StartCoroutine(MoveToB());
        }

        setEnable(true);
    }

    public void setEnable(bool isEnable)
    {
        this.isEnable = isEnable;
    }

    // Use this for initialization
    void Awake () {
        transform.position = new Vector3(5000, 5000, 0);
    }
	
	// Update is called once per frame
	void Update () {
        if (isEnable == false) return;

        transform.Rotate(new Vector3(0.0f,0.0f,2.0f), 3600.0f * Time.deltaTime);
		if(isRunToA)
        {
            //Debug.LogWarning("MoveToA");
            transform.position = Vector3.Lerp(transform.position, pos_A, speed * Time.deltaTime);
        }
        else
        {
            //Debug.LogWarning("MoveToB");
            transform.position = Vector3.Lerp(transform.position, pos_B, speed * Time.deltaTime);
        }
    }

    public IEnumerator MoveToA()
    {
        isRunToA = true;
        //Debug.LogWarning("MoveToA");
        yield return new WaitForSeconds(speed * 6);
        StartCoroutine(MoveToB());
    }

    public IEnumerator MoveToB()
    {
        isRunToA = false;
        //Debug.LogWarning("MoveToB");
        yield return new WaitForSeconds(speed * 6);
        StartCoroutine(MoveToA());
    }
}

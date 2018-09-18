using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "3CSettings", menuName = "3CSettings", order = 1)]
[ExecuteInEditMode]
public class _3CSettings : ScriptableObject {
    [HideInInspector]
    public int screenWidth = 750;
    [HideInInspector]
    public int screenHeight = 1334;

    [Header("Max Distance")]
    [SerializeField]
    public float maxDistance = 300f;

    [Header("Max Force")]
    [SerializeField]
    public float maxForce = 300f;

    public float distancePerPart;

    [Header("Force Parts")]
    [SerializeField]
    public List<float> parts = new List<float>();

    [Header("Time Reach Full Force")]
    [SerializeField]
    public float reachFullForceTime = 5.0f;

    [Header("Minimum Distance Percent From Last Parts")]
    [SerializeField]
    public float minimumDistancePercent = 0.2f;

    [Header("First Part Percent From Player Force")]
    [SerializeField]
    public float firstPartPercentPlayerForce = 0.3f;

    [Header("Time Percent Reach First Part")]
    [SerializeField]
    public float timePercentFirstPart = 0.2f;

    [Header("Second Part Percent From Player Force")]
    [SerializeField]
    public float secondPartPercentPlayerForce = 0.7f;

    [Header("Time Percent Reach Second Part")]
    [SerializeField]
    public float timePercentSecondPart = 0.8f;

    [Header("Time Reach 0")]
    [SerializeField]
    public float timeReach0 = 3f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnValidate()
    {
        Debug.Log("a");
        float size = parts.Count;
        float percentPerPart = 100.0f / size;
        for (int i = 0; i < size; i++)
        {
            parts[i] = i * percentPerPart + percentPerPart;
           
        }
        distancePerPart = maxDistance / size;
    }
}

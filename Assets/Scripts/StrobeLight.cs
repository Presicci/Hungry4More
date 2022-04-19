using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrobeLight : MonoBehaviour
{
    private Light light;

    // Start is called before the first frame update
    void Start()
    {
        light = transform.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (light.isActiveAndEnabled)
            //light
    }
}

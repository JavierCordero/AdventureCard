using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinFunction : MonoBehaviour
{
    public float distance = 50f;
    public float time = 2;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f / distance * Mathf.Sin(Time.time * time) * Time.deltaTime
         ,transform.position.z);
    }
}

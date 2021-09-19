using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ScreenResize : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        float desiredHalfWidth = 16.0f / 9.0f * 5.0f;
        float aspect = Camera.main.aspect;
        Camera.main.orthographicSize = 1 / aspect * desiredHalfWidth;
    }

    // Update is called once per frame
    void Update()
    {
        float desiredHalfWidth = 16.0f / 9.0f * 5.0f;
        float aspect = Camera.main.aspect;
        Camera.main.orthographicSize = 1 / aspect * desiredHalfWidth;
    }
}

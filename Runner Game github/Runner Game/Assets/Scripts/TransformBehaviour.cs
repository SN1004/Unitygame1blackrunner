using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformBehaviour : MonoBehaviour
{
    [SerializeField]
    private float SidewaysBy_Value, UpAndDownBy_Value, RotateBy_Value;
    [SerializeField]
    private float MaxX, MinX, MaxY,MinY;

    // Update is called once per frame
    void Update()
    {
        if(SidewaysBy_Value != 0)
            HorizontalMove();
        if (UpAndDownBy_Value != 0)
            VerticalMove();
        if (RotateBy_Value != 0)
            Rotate();
    }

    void HorizontalMove()
    {
        transform.localPosition += Time.deltaTime * (new Vector3(SidewaysBy_Value, 0f, 0f));
        if (transform.localPosition.x >= MaxX) 
        { 
            SidewaysBy_Value = (-1)*(SidewaysBy_Value); 
        }
        else if (transform.localPosition.x <= MinX)
            SidewaysBy_Value = Mathf.Abs(SidewaysBy_Value);
    }
    void VerticalMove()
    {
        transform.position += Time.deltaTime * (new Vector3(0f, UpAndDownBy_Value, 0f));
        if (transform.position.y >= MaxY)
            UpAndDownBy_Value = -(UpAndDownBy_Value);
        else if (transform.position.y <= MinY)
            UpAndDownBy_Value = Mathf.Abs(UpAndDownBy_Value);
    }
    void Rotate()
    {
        transform.eulerAngles += Time.deltaTime * (new Vector3(0f, 0f, RotateBy_Value));
    }
}

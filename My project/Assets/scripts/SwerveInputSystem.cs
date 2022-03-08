using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveInputSystem : MonoBehaviour
{
    private float _lastFrameFingerPositionX;
    private float _moveFactorX;
    public float MoveFactorX()
    {
        return _moveFactorX;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && transform.GetComponent<script>().getIsClickPlayButtonValue())
        {
            _lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0) && transform.GetComponent<script>().getIsClickPlayButtonValue())
        {
            _moveFactorX = Input.mousePosition.x - _lastFrameFingerPositionX;
            _lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0) && transform.GetComponent<script>().getIsClickPlayButtonValue() )
        {
            _moveFactorX = 0f;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_ChangePoint : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Transform look_point;
    [SerializeField] Transform point_near;
    [SerializeField] Transform point_far;    
    [SerializeField] float     speed;

    private bool now_near;


    void Start()
    {
        now_near = true;
    }


    void Update()
    {
        target.localPosition *= 1f / (1f + (speed * Time.deltaTime));

        target.LookAt(look_point);
    }


    //---------------
    // タップしたら
    //---------------
    public void Tap()
    {
        if (now_near)
        {
            target.parent = point_far;
        }
        else
        {
            target.parent = point_near;
        }

        now_near = !now_near;
    }
}
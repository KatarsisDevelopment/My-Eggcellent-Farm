using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    FixedJoystick FixedJoystick;
    // Start is called before the first frame update
    void Start()
    {
        FixedJoystick = FindObjectOfType<FixedJoystick>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(FixedJoystick.Horizontal, 0, FixedJoystick.Vertical) * 2.5f * Time.deltaTime;
        Camera.main.transform.position = transform.position + new Vector3(-6, 9, -6);
        if (FixedJoystick.Horizontal != 0 && FixedJoystick.Vertical != 0)
        {
            transform.forward = new Vector3(FixedJoystick.Horizontal, 0, FixedJoystick.Vertical);
        }
     
    }
}

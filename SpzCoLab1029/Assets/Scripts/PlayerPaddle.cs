using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddle : Paddle
{
    // Update is called once per frame
    void Update()
    {
        Move(Input.GetAxis("Vertical"));
    }
}

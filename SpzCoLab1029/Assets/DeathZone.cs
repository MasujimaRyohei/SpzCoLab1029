using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour {
   public enum Side
    {
        Right,
        Left
    }
    [SerializeField]
    private Side side;

   public void CheckSide()
    {
        switch (side)
        {
            case Side.Right:
                print("Right side wins");
                break;
            case Side.Left:
                print("Left side wins");
                break;
        }
    }
}

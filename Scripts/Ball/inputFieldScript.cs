using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class inputFieldScript : MonoBehaviour
{
    TMP_InputField _inputField;
    public string inputField;
    //public float XPosG;
    //public float XVPosG;
    //public GameObject ball;
    //private BallPhysics Ball_Script;

    void Start()
    {
        _inputField = GameObject.Find(inputField).GetComponent<TMP_InputField>();
    }

    void FixedUpdate()
    {
        //Ball_Script = ball.GetComponent<BallPhysics>();
        //if (name == "GameObject (X)" && Ball_Script.atMax == 0 && Ball_Script.cycle != 0)
        //{
        //    XPosG = Ball_Script.XPos;
        //    _inputField.text = XPosG.ToString();
        //}
        //if (name == "GameObject (XV)" && Ball_Script.atMax == 0 && Ball_Script.cycle != 0)
        //{
        //    XVPosG = Ball_Script.XVPos;
        //    _inputField.text = XVPosG.ToString();
        //}
        //_inputField.text = ".5";
    }

    public void InputName()
    {
        string name = _inputField.text;
    }

}

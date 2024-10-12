using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BallPhysics : MonoBehaviour
{
    public List<float> listTime = new List<float>();
    public List<float> listX = new List<float>();
    public List<float> listY = new List<float>();
    public List<float> listXVelocity = new List<float>();
    public List<float> listYVelocity = new List<float>();
    public float inputInitalVelocity;
    public float inputMass;
    public float inputAngle;
    public float timeStep;
    public float initalX;
    public float initalY;
    float rho;
    float a;
    public float cD;
    public float XPos;
    public float YPos;
    public float XVPos;
    public float YVPos;
    public float Time;
    int inputT;
    int maxT;
    public int atMax;
    public int cycle;
    GameObject YUp;
    GameObject YDown;
    GameObject XRight;
    GameObject XLeft;
    public Text ballUIText; // assign it from inspector
    TMP_InputField cD_inputField;
    TMP_InputField A_inputField;
    TMP_InputField TP_inputField;
    public UnityEngine.UI.Button play;
    public UnityEngine.UI.Button reset;
    public UnityEngine.UI.Button pause;
    public UnityEngine.UI.Button reverse;
    public UnityEngine.UI.Button retur;
    private inputFieldScript Input_Script;


    // Start is called before the first frame update
    void Start()
    {
        listX.Add(initalX);
        listY.Add(initalY);
        listXVelocity.Add(inputInitalVelocity * Mathf.Cos(inputAngle));
        listYVelocity.Add(inputInitalVelocity * Mathf.Sin(inputAngle));
        listTime.Add(0);
        rho = 1.168f;
        a = 0.1f;
        cD = 1.0f;
        cycle = 0;
        YUp = GameObject.Find("YUp");
        YDown = GameObject.Find("YDown");
        XRight = GameObject.Find("XRight");
        XLeft = GameObject.Find("XLeft");
        cD_inputField = GameObject.Find("InputField (TMP)").GetComponent<TMP_InputField>();
        A_inputField = GameObject.Find("InputField (TMP) (1)").GetComponent<TMP_InputField>();
        TP_inputField = GameObject.Find("InputField (TMP) (TP)").GetComponent<TMP_InputField>();
        play.onClick.AddListener(() => Play(play));
        reset.onClick.AddListener(() => Reset(reset));
        pause.onClick.AddListener(() => Pause(pause));
        reverse.onClick.AddListener(() => Reverse(reverse));
        retur.onClick.AddListener(() => Retur(retur));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        


        if (cycle != 0)
        {
            if (atMax == 0)
            {
                listTime.Add(listTime[inputT] + timeStep);
                cD = (float)Convert.ToDouble(cD_inputField.text);
                a = (float)Convert.ToDouble(A_inputField.text);
                timeStep = (float)Convert.ToDouble(TP_inputField.text);
                if (a > 5){
                    a = 5;
                }
                if (cD > 5){
                    cD = 5;
                }
                if (timeStep > 1){
                    timeStep = (float)0.1;
                }
                if (timeStep == 0){
                    timeStep = (float)0.00001;
                }
                listX.Add(listX[inputT] + (timeStep * listXVelocity[inputT]));
                listY.Add(listY[inputT] + (timeStep * listYVelocity[inputT]));
                if ((float)listXVelocity[inputT] + (timeStep * (-rho * 0.5f * (Mathf.Sqrt((float)Math.Pow(listXVelocity[inputT], 2f) + (float)Math.Pow(listYVelocity[inputT], 2f)) * listXVelocity[inputT] * cD * a)) / inputMass) > 3.4 * (float)Math.Pow(10, 38)){
                    listXVelocity.Add((float)Math.Pow(10, 38));
                }
                else{
                listXVelocity.Add(listXVelocity[inputT] + (timeStep * (-rho * 0.5f * (Mathf.Sqrt((float)Math.Pow(listXVelocity[inputT], 2f) + (float)Math.Pow(listYVelocity[inputT], 2f)) * listXVelocity[inputT] * cD * a)) / inputMass));
                }
                if ((float)listYVelocity[inputT] + (timeStep * (-9.81f - rho * 0.5f * (Mathf.Sqrt((float)Math.Pow(listXVelocity[inputT], 2f) + (float)Math.Pow(listYVelocity[inputT], 2f)) * listYVelocity[inputT] * cD * a)) / inputMass) > (float)Math.Pow(10, 38)){
                    listYVelocity.Add((float)Math.Pow(10, 38));
                }
                else{
                    listYVelocity.Add(listYVelocity[inputT] + (timeStep * (-9.81f - rho * 0.5f * (Mathf.Sqrt((float)Math.Pow(listXVelocity[inputT], 2f) + (float)Math.Pow(listYVelocity[inputT], 2f)) * listYVelocity[inputT] * cD * a)) / inputMass));
                }
                Time = listTime[inputT];
                XPos = listX[inputT];
                YPos = listY[inputT];
                XVPos = listXVelocity[inputT];
                YVPos = listYVelocity[inputT];
            }


            if (cycle == 1)
            {
                if (maxT == inputT)
                {
                    atMax = 0;
                }
                inputT = inputT + 1;
            }
            if (cycle == -1)
            {
                if (atMax == 0)
                {
                    maxT = inputT;
                    atMax = 1;
                }
                inputT = inputT - 1;
            }




            if (listXVelocity[inputT] <= 0)
            {
                XRight.gameObject.transform.localScale = new Vector3(Math.Abs((float)0.25 * listXVelocity[inputT]), Math.Abs((float)0.25 * listXVelocity[inputT]), Math.Abs((float)0.25 * listXVelocity[inputT]));
                XLeft.gameObject.transform.localScale = new Vector3(0, 0, 0);
            }
            else
            {
                XLeft.gameObject.transform.localScale = new Vector3(Math.Abs((float)0.25 * listXVelocity[inputT]), Math.Abs((float)0.25 * listXVelocity[inputT]), Math.Abs((float)0.25 * listXVelocity[inputT]));
                XRight.gameObject.transform.localScale = new Vector3(0, 0, 0);
            }
            if (listYVelocity[inputT] <= 0)
            {
                YDown.gameObject.transform.localScale = new Vector3(Math.Abs((float)0.25 * listYVelocity[inputT]), Math.Abs((float)0.25 * listYVelocity[inputT]), Math.Abs((float)0.25 * listYVelocity[inputT]));
                YUp.gameObject.transform.localScale = new Vector3(0, 0, 0);
            }
            else
            {
                YUp.gameObject.transform.localScale = new Vector3(Math.Abs((float)0.25 * listYVelocity[inputT]), Math.Abs((float)0.25 * listYVelocity[inputT]), Math.Abs((float)0.25 * listYVelocity[inputT]));
                YDown.gameObject.transform.localScale = new Vector3(0, 0, 0);
            }

            //Debug.Log("X: " + listX[inputT] + " Y: " + listY[inputT] + " XV: " + listXVelocity[inputT] + " YV: " + listYVelocity[inputT] + " ");
            if (!Double.IsNaN(listX[inputT]) || !Double.IsNaN(listY[inputT]) || !Double.IsInfinity(listX[inputT]) || !Double.IsInfinity(listY[inputT]))
            {
                transform.position = new Vector3(listX[inputT], listY[inputT], 0);
            }
            else
            {
                Debug.Log("NOOOOOO");
            }

        }

        ballUIText.text = ("Time: " + listTime[inputT] + Environment.NewLine + "X Position: " + (listX[inputT]) + Environment.NewLine + "Y position: " + listY[inputT] + Environment.NewLine + "X Velocity: " + (listXVelocity[inputT]) + Environment.NewLine + "Y Velocity: " + (listYVelocity[inputT]) + Environment.NewLine + "Time Step: " + timeStep);

        if (inputT == 0)
        {
            cycle = 0;
        }
    }
    private void Play(Button play)
    {
        Debug.Log("Play");
        cycle = 1;
    }
    private void Pause(Button pause)
    {
        Debug.Log("Pause");
        cycle = 0;
    }
    private void Reverse(Button reverse)
    {
        Debug.Log("Reverse");
        cycle = -1;
    }
    private void Retur(Button retur)
    {
        Debug.Log("Return");
        SceneManager.LoadScene("Menu");
    }
    private void Reset(Button reset)
    {
        Debug.Log("Reset");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

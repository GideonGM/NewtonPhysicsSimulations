using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PendulumPhysics : MonoBehaviour
{
    public List<float> listTime = new List<float>();
    public List<float> listAngle = new List<float>();
    public List<float> listAngleDer = new List<float>();
    int inputT;
    public float inputAngleDer;
    public float inputLength;
    public float timeStep;
    public int cycle;
    public int atMax;
    GameObject leftArrow;
    GameObject rightArrow;
    public UnityEngine.UI.Button play;
    public UnityEngine.UI.Button pause;
    public UnityEngine.UI.Button reverse;
    public UnityEngine.UI.Button reset;
    public UnityEngine.UI.Button retur;
    int maxT;
    TMP_InputField TS_inputField;

    public Text pendulumUIText; // assign it from inspector

    // Start is called before the first frame update
    void Start()
    {
        
        listAngle.Add((float)1);
        listTime.Add(0);
        inputLength = 1;
        timeStep = (float)0.01;
        cycle = 0;
        play.onClick.AddListener(() => Play(play));
        pause.onClick.AddListener(() => Pause(pause));
        reverse.onClick.AddListener(() => Reverse(reverse));
        reset.onClick.AddListener(() => Reset(reset));
        retur.onClick.AddListener(() => Retur(retur));
        listAngleDer.Add((((float)Math.Sqrt(Math.Abs(((2 * timeStep * (float)9.81) / inputLength) * ((float)Math.Cos(listAngle[inputT]) - (float)Math.Cos(listAngle[0] + (float).0001)))))));

        leftArrow = GameObject.Find("arrowLeft");
        rightArrow = GameObject.Find("arrowRight");
        TS_inputField = GameObject.Find("InputField (TS)").GetComponent<TMP_InputField>();

        transform.eulerAngles = new Vector3(Mathf.Rad2Deg * (listAngle[(int)inputT]), 0, 0);

            if (listAngleDer[inputT] >= 0)
            {
                rightArrow.gameObject.transform.localScale = new Vector3(Math.Abs((float)0.25 * listAngleDer[inputT]), Math.Abs((float)0.25 * listAngleDer[inputT]), Math.Abs((float)0.25 * listAngleDer[inputT]));
                leftArrow.gameObject.transform.localScale = new Vector3(0, 0, 0);
            }
            else
            {
                leftArrow.gameObject.transform.localScale = new Vector3(Math.Abs((float)0.25 * listAngleDer[inputT]), Math.Abs((float)0.25 * listAngleDer[inputT]), Math.Abs((float)0.25 * listAngleDer[inputT]));
                rightArrow.gameObject.transform.localScale = new Vector3(0, 0, 0);
            }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (cycle != 0)
        {
            Debug.Log(("Time: " + listTime[inputT] + Environment.NewLine + "Angle: " + (listAngle[inputT]) + Environment.NewLine + "Angular Velocity: " + listAngleDer[inputT] + Environment.NewLine + "Length: " + inputLength + Environment.NewLine + "Gravity: 9.81" + Environment.NewLine + "Time Step: " + timeStep));
            if (atMax == 0)
            {
                timeStep = (float)Convert.ToDouble(TS_inputField.text);
                if (timeStep > 1){
                    timeStep = (float)0.1;
                }
                if (timeStep == 0){
                    timeStep = (float)0.00001;
                }
                listTime.Add(listTime[inputT] + timeStep);
                listAngle.Add(listAngle[inputT] + (listAngleDer[inputT] * timeStep));
                
                listAngleDer.Add((listAngleDer[inputT] - (((timeStep * (float)9.81) / inputLength) * listAngle[inputT])));
                
                //Debug.Log((listAngle[inputT] + (listAngleDer[inputT] * timeStep)));
                //if (((listAngleDer[inputT] - (((timeStep * (float)9.81) / inputLength) * listAngle[inputT]))) > 0)
                //{
                    
                 //   listAngleDer.Add(((float)Math.Sqrt(Math.Abs(((2 * timeStep * (float)9.81) / inputLength) * ((float)Math.Cos(listAngle[inputT]) - (float)Math.Cos(listAngle[0]+ (float).0001))))));
                //    //Debug.Log((listAngleDer[inputT] - (float)Math.Sqrt(Math.Abs(((2 * timeStep * (float)9.81) / inputLength) * ((float)Math.Cos(listAngle[inputT]) - (float)Math.Cos(listAngle[0] + (float).0001))))));


               // }
                //else
                //{
                    
                 //   listAngleDer.Add((-(float)Math.Sqrt(Math.Abs(((2 * timeStep * (float)9.81) / inputLength) * ((float)Math.Cos(listAngle[inputT]) - (float)Math.Cos(listAngle[0] + (float).0001))))));
                    //Debug.Log((listAngleDer[inputT] + (float)Math.Sqrt(Math.Abs(((2 * timeStep * (float)9.81) / inputLength) * ((float)Math.Cos(listAngle[inputT]) - (float)Math.Cos(listAngle[0] + (float).0001))))));

               // }
                


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

            transform.eulerAngles = new Vector3(Mathf.Rad2Deg * (listAngle[(int)inputT]), 0, 0);

            if (listAngleDer[inputT] >= 0)
            {
                rightArrow.gameObject.transform.localScale = new Vector3(Math.Abs((float)0.25 * listAngleDer[inputT]), Math.Abs((float)0.25 * listAngleDer[inputT]), Math.Abs((float)0.25 * listAngleDer[inputT]));
                leftArrow.gameObject.transform.localScale = new Vector3(0, 0, 0);
            }
            else
            {
                leftArrow.gameObject.transform.localScale = new Vector3(Math.Abs((float)0.25 * listAngleDer[inputT]), Math.Abs((float)0.25 * listAngleDer[inputT]), Math.Abs((float)0.25 * listAngleDer[inputT]));
                rightArrow.gameObject.transform.localScale = new Vector3(0, 0, 0);
            }
        }
        if (inputT == 0)
        {
            cycle = 0;
        }

        pendulumUIText.text = ("Time: " + listTime[inputT] + Environment.NewLine + "Angle: " + (listAngle[inputT]) + Environment.NewLine + "Angular Velocity: " + listAngleDer[inputT] + Environment.NewLine + "Length: " + inputLength + Environment.NewLine + "Gravity: 9.81" + Environment.NewLine + "Time Step: " + timeStep);
        //Debug.Log(("Time: " + listTime[inputT] + Environment.NewLine + "Angle: " + (listAngle[inputT]) + Environment.NewLine + "Angular Velocity: " + listAngleDer[inputT] + Environment.NewLine + "Length: " + inputLength + Environment.NewLine + "Gravity: 9.81" + Environment.NewLine + "Time Step: " + timeStep));
        

        
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

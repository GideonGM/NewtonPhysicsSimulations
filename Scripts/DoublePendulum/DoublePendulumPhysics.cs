using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DoublePendulumPhysics : MonoBehaviour
{
    public List<float> listTime = new List<float>();
    public List<float> listA1 = new List<float>();
    public List<float> listA2 = new List<float>();
    public List<float> listD1 = new List<float>();
    public List<float> listD2 = new List<float>();
    int inputT;
    public int atMax;
    public float inputD1;
    public float inputD2;
    public float inputLength1;
    public float inputLength2;
    public float timeStep;
    public int cycle;
    GameObject leftArrow1;
    GameObject rightArrow1;
    GameObject leftArrow2;
    GameObject rightArrow2;
    GameObject pendulum2;
    int maxT;
    public UnityEngine.UI.Button play;
    public UnityEngine.UI.Button pause;
    public UnityEngine.UI.Button reverse;
    public UnityEngine.UI.Button reset;
    public UnityEngine.UI.Button retur;
    TMP_InputField TSS_inputField;

    public Text pendulumUIText; // assign it from inspector

    // Start is called before the first frame update
    void Start()
    {
        listD1.Add(0);
        listD2.Add(0);
        listA1.Add((float)1);
        listA2.Add((float)1);
        listTime.Add(0);
        inputLength1 = 1;
        inputLength2 = 1;
        timeStep = (float)0.001;
        cycle = 0;
        play.onClick.AddListener(() => Play(play));
        pause.onClick.AddListener(() => Pause(pause));
        reverse.onClick.AddListener(() => Reverse(reverse));
        reset.onClick.AddListener(() => Reset(reset));
        retur.onClick.AddListener(() => Retur(retur));

        leftArrow1 = GameObject.Find("arrowLeft1");
        rightArrow1 = GameObject.Find("arrowRight1");
        leftArrow2 = GameObject.Find("arrowLeft2");
        rightArrow2 = GameObject.Find("arrowRight2");
        pendulum2 = GameObject.Find("Pendulum (2)");

        TSS_inputField = GameObject.Find("InputField (TSS)").GetComponent<TMP_InputField>();
        pendulumUIText.text = ("Time: " + listTime[inputT] + Environment.NewLine + "Angle 1: " + (listA1[inputT]) + Environment.NewLine + "Angle 2: " + (listA2[inputT]) + Environment.NewLine + "Angular Velocity 1: " + listD1[inputT] + Environment.NewLine + "Angular Velocity 2: " + listD2[inputT] + Environment.NewLine + "Length 1: " + inputLength1 + Environment.NewLine + "Length 2: " + inputLength2 + Environment.NewLine + "Gravity: 9.81" + Environment.NewLine + "Time Step: " + timeStep);
        transform.eulerAngles = new Vector3(Mathf.Rad2Deg * (listA1[(int)inputT]), 0, 0);
            pendulum2.transform.eulerAngles = new Vector3(Mathf.Rad2Deg * (listA2[(int)inputT]), 0, 0);

            
            //Debug.Log(listA1[inputT]);
            if (listD1[inputT] >= 0)
            {
                rightArrow1.gameObject.transform.localScale = new Vector3(Math.Abs((float)0.25 * listD1[inputT]), Math.Abs((float)0.25 * listD1[inputT]), Math.Abs((float)0.25 * listD1[inputT]));
                leftArrow1.gameObject.transform.localScale = new Vector3(0, 0, 0);
            }
            else
            {
                leftArrow1.gameObject.transform.localScale = new Vector3(Math.Abs((float)0.25 * listD1[inputT]), Math.Abs((float)0.25 * listD1[inputT]), Math.Abs((float)0.25 * listD1[inputT]));
                rightArrow1.gameObject.transform.localScale = new Vector3(0, 0, 0);
            }
            if (listD2[inputT] >= 0)
            {
                rightArrow2.gameObject.transform.localScale = new Vector3(Math.Abs((float)0.25 * listD2[inputT]), Math.Abs((float)0.25 * listD2[inputT]), Math.Abs((float)0.25 * listD2[inputT]));
                leftArrow2.gameObject.transform.localScale = new Vector3(0, 0, 0);
            }
            else
            {
                leftArrow2.gameObject.transform.localScale = new Vector3(Math.Abs((float)0.25 * listD2[inputT]), Math.Abs((float)0.25 * listD2[inputT]), Math.Abs((float)0.25 * listD2[inputT]));
                rightArrow2.gameObject.transform.localScale = new Vector3(0, 0, 0);
            }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (cycle != 0)
        {
            pendulumUIText.text = ("Time: " + listTime[inputT] + Environment.NewLine + "Angle 1: " + (listA1[inputT]) + Environment.NewLine + "Angle 2: " + (listA2[inputT]) + Environment.NewLine + "Angular Velocity 1: " + listD1[inputT] + Environment.NewLine + "Angular Velocity 2: " + listD2[inputT] + Environment.NewLine + "Length 1: " + inputLength1 + Environment.NewLine + "Length 2: " + inputLength2 + Environment.NewLine + "Gravity: 9.81" + Environment.NewLine + "Time Step: " + timeStep);
            if (atMax == 0)
            {
                timeStep = (float)Convert.ToDouble(TSS_inputField.text);
                if (timeStep > 1){
                    timeStep = (float)0.1;
                }
                if (timeStep == 0){
                    timeStep = (float)0.00001;
                }
                listTime.Add(listTime[inputT] + timeStep);
                Debug.Log(listA1[inputT] + " time: " + inputT);
                listD1.Add((float)(listD1[inputT] + (timeStep * ((((((float)-9.81) * (2 * 1 + 1)) * Math.Sin(listA1[inputT])) - (1 * ((float)9.81) * Math.Sin(listA1[inputT] - (listA2[inputT] * 2))) - (2 * (Math.Sin(listA1[inputT] - listA2[inputT]))) * 1 * ((Math.Pow(listD2[inputT], 2) * (inputLength2) + (Math.Pow(listD1[inputT], 2)) * inputLength1 * (Math.Cos(listA1[inputT] - listA2[inputT])))) / (inputLength1 * (2 * 1 + 1 - 1 * Math.Cos(2 * listA1[inputT] - 2 * listA2[inputT]))))))));
                listD2.Add((float)(listD2[inputT] + (timeStep * ((((2 * Math.Sin(listA1[inputT] - listA2[inputT])) * (((Math.Pow(listD1[inputT], 2)) * inputLength1 * (1 + 1) + ((float)9.81) * (1 + 1) * Math.Cos(listA1[inputT]) + (Math.Pow(listD2[inputT], 2)) * inputLength2 * 1 * Math.Cos(listA1[inputT] - listA2[inputT]))))) / (inputLength2 * (2 * 1 + 1 - 1 * Math.Cos(2 * listA1[inputT] - (2 * listA2[inputT]))))))));
                listA1.Add(listA1[inputT] + (listD1[inputT] * timeStep));
                listA2.Add(listA2[inputT] + (listD2[inputT] * timeStep));
                Debug.Log("Time: " + listTime[inputT] + "Angle 1: " + (listA1[inputT]) + "Angle 2: " + (listA2[inputT]) + "Angular Velocity 1: " + listD1[inputT] + "Angular Velocity 2: " + listD2[inputT] + "Length 1: " + inputLength1 + "Length 2: " + inputLength2 + "Gravity: 9.81" + "Time Step: " + timeStep);
            }
            transform.eulerAngles = new Vector3(Mathf.Rad2Deg * (listA1[(int)inputT]), 0, 0);
            pendulum2.transform.eulerAngles = new Vector3(Mathf.Rad2Deg * (listA2[(int)inputT]), 0, 0);

            
            //Debug.Log(listA1[inputT]);
            if (listD1[inputT] >= 0)
            {
                rightArrow1.gameObject.transform.localScale = new Vector3(Math.Abs((float)0.25 * listD1[inputT]), Math.Abs((float)0.25 * listD1[inputT]), Math.Abs((float)0.25 * listD1[inputT]));
                leftArrow1.gameObject.transform.localScale = new Vector3(0, 0, 0);
            }
            else
            {
                leftArrow1.gameObject.transform.localScale = new Vector3(Math.Abs((float)0.25 * listD1[inputT]), Math.Abs((float)0.25 * listD1[inputT]), Math.Abs((float)0.25 * listD1[inputT]));
                rightArrow1.gameObject.transform.localScale = new Vector3(0, 0, 0);
            }
            if (listD2[inputT] >= 0)
            {
                rightArrow2.gameObject.transform.localScale = new Vector3(Math.Abs((float)0.25 * listD2[inputT]), Math.Abs((float)0.25 * listD2[inputT]), Math.Abs((float)0.25 * listD2[inputT]));
                leftArrow2.gameObject.transform.localScale = new Vector3(0, 0, 0);
            }
            else
            {
                leftArrow2.gameObject.transform.localScale = new Vector3(Math.Abs((float)0.25 * listD2[inputT]), Math.Abs((float)0.25 * listD2[inputT]), Math.Abs((float)0.25 * listD2[inputT]));
                rightArrow2.gameObject.transform.localScale = new Vector3(0, 0, 0);
            }
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

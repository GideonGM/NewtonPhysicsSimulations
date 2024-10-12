using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public UnityEngine.UI.Button ball;
    public UnityEngine.UI.Button dubs;
    public UnityEngine.UI.Button single;
    public UnityEngine.UI.Button exit;
    public UnityEngine.UI.Button retur;
    public UnityEngine.UI.Button info;

    // Start is called before the first frame update
    void Start()
    {
        ball.onClick.AddListener(() => Ball(ball));
        dubs.onClick.AddListener(() => Dubs(dubs));
        single.onClick.AddListener(() => Single(single));
        exit.onClick.AddListener(() => Exit(exit));
        retur.onClick.AddListener(() => Retur(retur));
        info.onClick.AddListener(() => Info(info));
    }


    private void Ball(Button ball)
    {
        Debug.Log("Ball");
        SceneManager.LoadScene("BallSim");
    }
    private void Dubs(Button dubs)
    {
        Debug.Log("Dubs");
        SceneManager.LoadScene("DoublePendulum");
    }
    private void Single(Button single)
    {
        Debug.Log("Single");
        SceneManager.LoadScene("BrokenPhysics");
    }
    private void Exit(Button exit)
    {
        Debug.Log("Shutting Down...");
        Application.Quit();
    }
    private void Retur(Button retur)
    {
        Debug.Log("Return");
        SceneManager.LoadScene("Menu");
    }
    private void Info(Button info)
    {
        Debug.Log("Info");
        SceneManager.LoadScene("Info");
    }
}

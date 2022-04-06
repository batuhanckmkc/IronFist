using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public  GameObject GameOverPopUp;
    private void Start()
    {
        GameOverPopUp.SetActive(false);
    }
    public void ActivateGameOverButton()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }
}

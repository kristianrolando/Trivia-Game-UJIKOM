using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PackLauncher : MonoBehaviour
{
    public void GoBack()
    {
        SceneManager.LoadScene("Home");
    }
    public void SelectPack(int packID)
    {
        Debug.Log(packID);
        PlayerPrefs.SetInt("PackIDSelected", packID);
        SceneManager.LoadScene("Level");
    }
}

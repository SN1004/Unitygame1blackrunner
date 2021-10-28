using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSelectController : MonoBehaviour
{
    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void Story()
    {
        SceneManager.LoadScene("Story Level Select");
    }
    public void Survival()
    {
        SceneManager.LoadScene("Survival");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StoryLevelController : MonoBehaviour
{
    public void Level1()
    {
        SceneManager.LoadScene("Story Level 1");
    }
    public void Level2()
    {
        SceneManager.LoadScene("Story Level 2");
    }
    public void Level3()
    {
        SceneManager.LoadScene("Story Level 3");
    }
    public void Level4()
    {
        SceneManager.LoadScene("Story Level 4");
    }
}

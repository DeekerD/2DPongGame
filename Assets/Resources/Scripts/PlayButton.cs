using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
  public void PlayGame(int sceneId)
    {
        //Moves us to the next scene
        SceneManager.LoadScene(sceneId);
    }
}

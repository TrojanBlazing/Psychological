using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
  public static SceneController instance;
     GameObject Player;
    [SerializeField] Animator sceneAnimator;
    [SerializeField] Canvas SceneTransitionCanvas;
    private void Awake()
    {
        
        if(instance == null)
        {
            instance = this;
           
        }
        else
        {
            Destroy(gameObject);
        }

        Player = GameObject.Find("Player");
    }

    public void NextLevel()
    {
        if (Player != null)
        {
            Player.GetComponent<CharacterController>().enabled = false;
        }
        //Getting the transition canvas in front
        SceneTransitionCanvas.sortingOrder = 1;
        StartCoroutine(LoadLevel());
    }
    IEnumerator LoadLevel()
    {
        sceneAnimator.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex+1);
        sceneAnimator.SetTrigger("Start");
    }
}

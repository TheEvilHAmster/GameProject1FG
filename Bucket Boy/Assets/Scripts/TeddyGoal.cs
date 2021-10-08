using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeddyGoal : MonoBehaviour
{
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(WinningTheLevel());
    }

    IEnumerator WinningTheLevel()
    {
        yield return new WaitForSeconds(0);
        SceneManager.LoadScene(3);
    }
}

using CookieGambler;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScript : MonoBehaviour
{
    public void WaitToLoadCurrentLevel()
    {
        StartCoroutine(ResetLevel());
    }

    private IEnumerator ResetLevel()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("__Test_Ju");
    }
}

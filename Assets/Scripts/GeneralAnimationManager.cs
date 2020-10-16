using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GeneralAnimationManager : MonoBehaviour
{
    private bool currentlyWorking = false;
    public Image BlackBG;
    public void FadeIn(string sceneToLoad = "")
    {
        StartCoroutine(FadeInRoutine(sceneToLoad));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutRoutine());
    }


    IEnumerator FadeInRoutine(string sceneToLoad)
    {
        while (currentlyWorking)
            yield return null;

        BlackBG.gameObject.SetActive(true);

        currentlyWorking = true;

        Color c = BlackBG.color;
        c.a = 0;
        BlackBG.color = c;

        while (BlackBG.color.a < 1)
        {
            c = BlackBG.color;
            c.a += 1f * Time.deltaTime;
            BlackBG.color = c;
            yield return null;
        }
        currentlyWorking = false;

        if (sceneToLoad != "")
            SceneManager.LoadScene(sceneToLoad);

    }

    IEnumerator FadeOutRoutine()
    {

        while (currentlyWorking)
            yield return null;

        BlackBG.gameObject.SetActive(true);

        currentlyWorking = true;

        Color c = BlackBG.color;
        c.a = 1;
        BlackBG.color = c;

        while (BlackBG.color.a > 0)
        {
            c = BlackBG.color;
            c.a -= 1f * Time.deltaTime;
            BlackBG.color = c;
            yield return null;
        }
        currentlyWorking = false;

    }

}

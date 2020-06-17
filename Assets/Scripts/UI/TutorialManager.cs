using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public enum Tutorial { WASD, Click, E }

public class TutorialManager : MonoBehaviour
{
    private static TutorialManager instance;
    public static TutorialManager Instance
    {
        get
        {
            return instance;
        }
    }

    public GameObject wasdText, clickText, eText;
    private Dictionary<Tutorial, GameObject> tutorialText;

    private void Awake()
    {
        instance = this;

        tutorialText = new Dictionary<Tutorial, GameObject>();
        tutorialText.Add(Tutorial.WASD, wasdText);
        tutorialText.Add(Tutorial.Click, clickText);
        tutorialText.Add(Tutorial.E, eText);
    }

    public void DisplayText(Tutorial key, bool autoHide = false, float hideTimer = 0.0f) 
    {
        GameObject txt;
        tutorialText.TryGetValue(key, out txt);
        txt.SetActive(true);

        if (autoHide)
        {
            IEnumerator c = AutoHideText(txt, hideTimer);
            StartCoroutine(c);
        }
    }

    private IEnumerator AutoHideText(GameObject txt, float timer)
    {
        yield return new WaitForSeconds(timer);
        txt.SetActive(false);
    }

    public void HideText(Tutorial key) 
    {
        GameObject txt;
        tutorialText.TryGetValue(key, out txt);
        txt.SetActive(false);
    }




}

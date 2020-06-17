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
    private Dictionary<Tutorial, bool> textDisplayed;
    private Tutorial currentKey;
    private GameObject currentText;
    

    private void Awake()
    {
        instance = this;

        tutorialText = new Dictionary<Tutorial, GameObject>();
        tutorialText.Add(Tutorial.WASD, wasdText);
        tutorialText.Add(Tutorial.Click, clickText);
        tutorialText.Add(Tutorial.E, eText);

        textDisplayed = new Dictionary<Tutorial, bool>();
        textDisplayed.Add(Tutorial.WASD, false);
        textDisplayed.Add(Tutorial.Click, false);
        textDisplayed.Add(Tutorial.E, false);
    }

    public void DisplayText(Tutorial key, bool autoHide = false, float hideTimer = 0.0f) 
    {
        if (textDisplayed[key])
        {
            return;
        }

        GameObject txt;
        tutorialText.TryGetValue(key, out txt);

        if (currentText != null)
        {
            if (currentText==txt)
            {
                return;
            }
            foreach(Tutorial t in tutorialText.Keys)
            {
                tutorialText[t].SetActive(false);
            }
        }

        txt.SetActive(true);
        textDisplayed[key] = true;
        currentKey = key;
        currentText = txt;

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
        currentText = null;
    }




}

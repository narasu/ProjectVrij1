using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraProp : Interactable
{
    [SerializeField] private GameObject tutorialText;

    public void EnableText()
    {
        TutorialManager.Instance.DisplayText(Tutorial.Click);
    }

    public void DisableText()
    {
        TutorialManager.Instance.HideText(Tutorial.Click);
    }

    public override void HandleInteraction()
    {
        base.HandleInteraction();
        Player.Instance.GetCamera();
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraProp : Interactable
{
    [SerializeField] private GameObject tutorialText;

    public void EnableText()
    {
        TutorialManager.Instance.DisplayText(Tutorial.Click, true, 3.0f);
    }


    public override void HandleInteraction()
    {
        base.HandleInteraction();
        Player.Instance.GetCamera();
        Destroy(gameObject);
    }
}

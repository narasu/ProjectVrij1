using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraProp : Interactable
{
    [SerializeField] private GameObject tutorialText;

    public void EnableText()
    {
        tutorialText.SetActive(true);
    }

    public void DisableText()
    {
        tutorialText.SetActive(false);
    }

    public override void HandleInteraction()
    {
        base.HandleInteraction();
        Player.Instance.GetCamera();
        Destroy(gameObject);
    }
}

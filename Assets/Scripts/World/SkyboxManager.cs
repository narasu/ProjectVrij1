using UnityEngine;
using System.Collections;

public class SkyboxManager : MonoBehaviour
{
    private Material skyboxMain;
    private Material skyboxAlt;

    private void Awake()
    {
        skyboxMain = Resources.Load<Material>("Skyboxes/skybox_main");
        skyboxAlt = Resources.Load<Material>("Skyboxes/skybox_alt");
    }

    public void ToAltWorld()
    {
        RenderSettings.skybox = skyboxAlt;
    }

    public void ToMainWorld()
    {
        RenderSettings.skybox = skyboxMain;
    }
}

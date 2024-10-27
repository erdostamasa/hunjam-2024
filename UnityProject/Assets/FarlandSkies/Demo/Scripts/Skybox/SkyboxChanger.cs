using UnityEngine;
using UnityEngine.UI;

public class SkyboxChanger : MonoBehaviour
{
    public Material[] Skyboxes;

    public void Awake()
    {
        RenderSettings.skybox = Skyboxes[0];
    }

    public void Update()
    {
        ChangeSkybox();
    }

    public void ChangeSkybox()
    {
        var time = TimeManager.CurrentTime;
        var index = (int)(time * Skyboxes.Length);
        var nextIndex = (index + 1) % Skyboxes.Length;
        var lerp = time * Skyboxes.Length - index;
        Debug.Log($"index: {index}, nextIndex: {nextIndex}, lerp: {lerp}");

        // Retrieve the current and next skybox materials
        var currentSkybox = Skyboxes[index];
        var nextSkybox = Skyboxes[nextIndex];

        // Create a new material to store the lerped properties
        var lerpedSkybox = new Material(currentSkybox);

        // Lerp the properties of the skybox materials
        lerpedSkybox.Lerp(currentSkybox, nextSkybox, (float)lerp);

        // Apply the lerped material to the RenderSettings
        RenderSettings.skybox = lerpedSkybox;
        RenderSettings.skybox.SetFloat("_Rotation", 0);
        DynamicGI.UpdateEnvironment();
    }
}
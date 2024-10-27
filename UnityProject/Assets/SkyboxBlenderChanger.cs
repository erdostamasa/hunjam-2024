using UnityEngine;

public class SkyboxBlenderChanger : MonoBehaviour
{

    SkyboxBlender skyboxBlender;

    [SerializeField] private Material[] Skyboxes;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        skyboxBlender = GetComponent<SkyboxBlender>();
        skyboxBlender.updateLightingEveryFrame = true;
    }

    // Update is called once per frame
    void Update()
    {
        var time = TimeManager.CurrentTime;
        var index = (int)(time * Skyboxes.Length);
        var nextIndex = (index + 1) % Skyboxes.Length;
        var lerp = time * Skyboxes.Length - index;
        Debug.Log($"index: {index}, nextIndex: {nextIndex}, lerp: {lerp}");
        skyboxBlender.skyBox1 = Skyboxes[index];
        skyboxBlender.skyBox2 = Skyboxes[nextIndex];
        skyboxBlender.blend = (float)lerp;
        skyboxBlender.BindTextures();
    }
}
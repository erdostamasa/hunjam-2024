using UnityEngine;

public class HourGlassClock : MonoBehaviour
{
    [SerializeField] private Transform upSand;
    [SerializeField] private Transform downSand;

    [SerializeField] private Transform upSandCollider;
    [SerializeField] private Transform downSandCollider;

    [SerializeField] private float upStartScale = 1f;
    [SerializeField] private float upEndScale = 0f;

    [SerializeField] private float downStartScale = 0f;
    [SerializeField] private float downEndScale = 1f;


    [SerializeField] private float upStartColliderScale = 1f;
    [SerializeField] private float upEndColliderScale = 0f;

    [SerializeField] private float downStartColliderScale = 0f;
    [SerializeField] private float downEndColliderScale = 1f;

    [SerializeField] private Material sandMat;
    [SerializeField] private Transform fallingSand;
    private Vector3 fallingSandStartScale;
    [SerializeField] private AnimationCurve sandSizeCurve;

    private void Start()
    {
        fallingSandStartScale = fallingSand.localScale;
    }

    private void LateUpdate()
    {
        sandMat.SetFloat("_YOffset", (float)TimeManager.UnwrappedTime);

        float unwrappedTimeMax = 0.2f;

        float sizeScale = sandSizeCurve.Evaluate(TimeManager.UnwrappedTime / unwrappedTimeMax);
        
        // x z változik
        Vector3 newScale = new Vector3(fallingSandStartScale.x * sizeScale, fallingSandStartScale.y,
            fallingSandStartScale.z * sizeScale);
        fallingSand.localScale = newScale;
    }

    private void FixedUpdate()
    {
        float time = TimeManager.UnwrappedTime * 5f; // [0..1]
        time = Mathf.Clamp01(time);

        upSand.localScale = new Vector3(
            upSand.localScale.x,
            upSand.localScale.y,
            Mathf.Lerp(upStartScale, upEndScale, time)
        );

        downSand.localScale = new Vector3(
            downSand.localScale.x,
            downSand.localScale.y,
            Mathf.Lerp(downStartScale, downEndScale, time)
        );

        upSandCollider.localScale = new Vector3(
            upSandCollider.localScale.x,
            Mathf.Lerp(upStartColliderScale, upEndColliderScale, time),
            upSandCollider.localScale.z
        );

        downSandCollider.localScale = new Vector3(
            downSandCollider.localScale.x,
            Mathf.Lerp(downStartColliderScale, downEndColliderScale, time),
            downSandCollider.localScale.z
        );
    }
}
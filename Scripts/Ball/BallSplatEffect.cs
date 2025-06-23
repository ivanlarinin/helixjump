using UnityEngine;

public class BallSplatEffect : BallEvents
{
    [SerializeField] private GameObject splatPrefab;
    [SerializeField] private Transform visualModel;
    [SerializeField] private Transform levelTransform;

    private const float Y_OFFSET = 0.005f;
    private Color _splatColor;
    public void SetSplatColor(Color color)
    {
        _splatColor = color;
    }

    protected override void OnBallCollisionSegment(SegmentType type)
    {
        if (type != SegmentType.Empty)
        {
            GenerateSplat();
        }
    }

    private void GenerateSplat()
    {
        if (splatPrefab == null)
        {
            Debug.LogWarning("Splat Prefab is not assigned in BallSplatEffect.", this);
            return;
        }

        if (visualModel == null)
        {
            Debug.LogWarning("Visual Model is not assigned in BallSplatEffect.", this);
            return;
        }
        if (levelTransform == null)
        {
            Debug.LogError("Level Transform is not assigned in BallSplatEffect. Please assign the 'Level' GameObject's Transform in the Inspector for BallSplatEffect.", this);
            return;
        }

        Vector3 splatPosition = new Vector3(visualModel.position.x, transform.position.y + Y_OFFSET, visualModel.position.z);
        GameObject splat = Instantiate(splatPrefab, splatPosition, Quaternion.identity);
        splat.transform.rotation = Quaternion.Euler(90, Random.Range(0, 360), 0);
        splat.transform.SetParent(levelTransform);

        SpriteRenderer splatSpriteRenderer = splat.GetComponentInChildren<SpriteRenderer>();
        if (splatSpriteRenderer != null)
        {
            splatSpriteRenderer.color = _splatColor;
        }
    }
}
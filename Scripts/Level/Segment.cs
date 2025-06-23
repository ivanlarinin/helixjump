using UnityEngine;

public enum SegmentType
{
    Default,
    Trap,
    Empty,
    Finish
}

[RequireComponent(typeof(MeshRenderer))]
public class Segment : MonoBehaviour
{
    [SerializeField] private SegmentType type;
    public SegmentType Type => type;
    private MeshRenderer meshRenderer;
    
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void SetTrap(Color trapColor)
    {
        meshRenderer.enabled = true;
        type = SegmentType.Trap;
        meshRenderer.material.color = trapColor;
    }

    public void SetEmpty()
    {
        meshRenderer.enabled = false;
        type = SegmentType.Empty;
    }

    public void SetFinish(Color finishColor)
    {
        meshRenderer.enabled = true;
        meshRenderer.material.color = finishColor;
        type = SegmentType.Finish;
    }
    
    public void SetDefault(Color defaultColor)
    {
        meshRenderer.enabled = true;
        type = SegmentType.Default;
        meshRenderer.material.color = defaultColor;
    }
}
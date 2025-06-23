using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform axis;
    [SerializeField] private Floor floorPrefab;

    [Header("Settings")]
    [SerializeField] private int defaultFloorAmount;
    [SerializeField] private float floorHeight;
    [SerializeField] private int amountEmptySegment;
    [SerializeField] private int minTrapSegment;
    [SerializeField] private int maxTrapSegment;

    private float floorAmount = 0;
    public float FloorAmount => floorAmount;
    private float lastFloorY = 0;
    public float LastFloorY => lastFloorY;

    [SerializeField] private PaletteManager paletteManager;

    public void Generate(int level)
    {
        DestroyChild();

        floorAmount = defaultFloorAmount + level;

        axis.transform.localScale = new Vector3(1, floorAmount * floorHeight + floorHeight, 1);

        PaletteManager.ColorPalette currentPalette = paletteManager.GetSelectedPalette();

        for (int i = 0; i < floorAmount; i++)
        {
            Floor floor = Instantiate(floorPrefab, transform);
            floor.transform.Translate(0, i * floorHeight, 0);
            floor.name = "Floor " + i;
            floor.Initialize(currentPalette.defaultSegmentColor);

            if (i == 0)
            {
                floor.SetFinishSegment(currentPalette.finishSegmentColor);
            }

            if (i > 0 && i < floorAmount - 1)
            {
                floor.SetRandomRotate();
                floor.AddEmptySegment(amountEmptySegment);
                floor.AddRandomTrapSegment(Random.Range(minTrapSegment, maxTrapSegment + 1), currentPalette.trapSegmentColor);
            }

            if (i == floorAmount - 1)
            {
                floor.AddEmptySegment(amountEmptySegment);
                lastFloorY = floor.transform.position.y + .6f;
            }
        }
    }

    private void DestroyChild()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i) == axis) continue;

            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
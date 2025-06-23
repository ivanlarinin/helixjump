using UnityEngine;

public class SceneSetup : MonoBehaviour
{
    [SerializeField] private LevelGenerator levelGenerator;
    [SerializeField] private BallController ballController;
    [SerializeField] private LevelProgress levelProgress;
    [SerializeField] private PaletteManager paletteManager;
    [SerializeField] private BallSplatEffect ballSplatEffect;

    private void Start()
    {
        if (paletteManager != null)
        {
            paletteManager.ApplyRandomPalette();
        }
        if (ballSplatEffect != null && paletteManager != null)
        {
            ballSplatEffect.SetSplatColor(paletteManager.GetSelectedPalette().ballColor);
        }

        levelGenerator.Generate(levelProgress.CurrentLevel);
        ballController.transform.position = new Vector3(ballController.transform.position.x, levelGenerator.LastFloorY, ballController.transform.position.z);
    }
}
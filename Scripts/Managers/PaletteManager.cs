using UnityEngine;
using System.Collections.Generic;

public class PaletteManager : MonoBehaviour
{
    [Header("Material References")]
    [SerializeField] private MeshRenderer ballMeshRenderer;
    [SerializeField] private MeshRenderer axisMeshRenderer;

    [Header("Color Palettes")]
    [SerializeField] private List<ColorPalette> palettes = new List<ColorPalette>();

    [System.Serializable]
    public class ColorPalette
    {
        public Color ballColor;
        public Color axisColor;
        public Color defaultSegmentColor;
        public Color trapSegmentColor;
        public Color finishSegmentColor;
    }

    private ColorPalette _currentSelectedPalette;

    public void ApplyRandomPalette()
    {
        if (palettes == null || palettes.Count == 0)
        {
            Debug.LogWarning("No color palettes assigned to PaletteManager.", this);
            _currentSelectedPalette = new ColorPalette();
            return;
        }

        int randomIndex = Random.Range(0, palettes.Count);
        _currentSelectedPalette = palettes[randomIndex];

        if (ballMeshRenderer != null)
        {
            ballMeshRenderer.material.color = _currentSelectedPalette.ballColor;
        }

        if (axisMeshRenderer != null)
        {
            axisMeshRenderer.material.color = _currentSelectedPalette.axisColor;
        }
    }


    public ColorPalette GetSelectedPalette()
    {
        if (_currentSelectedPalette == null)
        {
            Debug.LogError("Current selected palette is null. Call ApplyRandomPalette() first.", this);
            return new ColorPalette();
        }
        return _currentSelectedPalette;
    }
}
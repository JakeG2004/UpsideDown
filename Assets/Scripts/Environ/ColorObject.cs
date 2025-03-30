using UnityEngine;

public class ColorObject : MonoBehaviour
{
    [SerializeField] private int _colorIndex;
    private SpriteRenderer _spriteRenderer;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        UpdateColor(BackgroundColorChanger.Instance.GetColor(_colorIndex), _colorIndex);
    }

    public void UpdateColor(Color color, int currentColorIndex)
    {
        _spriteRenderer.color = color;
        gameObject.SetActive(_colorIndex == currentColorIndex);
    }

    public int GetColorIndex()
    {
        return _colorIndex;
    }
}

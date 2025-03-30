using UnityEngine;

public class BackgroundColorChanger : MonoBehaviour
{
    public static BackgroundColorChanger Instance { get; private set; }

    [SerializeField] private Color[] _colors;
    private int _curColorIndex = 0;
    [SerializeField] private KeyCode _switchColor = KeyCode.Q;
    private ColorObject[] _colorObjects;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Multiple instances of BackgroundColorChanger detected. Destroying the new one.");
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        if (_colors.Length == 0)
        {
            Debug.LogWarning("No colors set in BackgroundColorChanger!");
        }

        _colorObjects = FindObjectsByType<ColorObject>(FindObjectsSortMode.None);
        UpdateColors();
    }

    void Update()
    {
        if (Input.GetKeyDown(_switchColor))
        {
            _curColorIndex = (_curColorIndex + 1) % _colors.Length;
            UpdateColors();
        }
    }

    private void UpdateColors()
    {
        foreach (ColorObject co in _colorObjects)
        {
            bool isActive = co.GetColorIndex() != _curColorIndex;
            co.gameObject.SetActive(isActive);
        }

        if (Camera.main != null)
        {
            Camera.main.backgroundColor = _colors[_curColorIndex];
        }
        else
        {
            Debug.LogWarning("No Main Camera found to change background color.");
        }
    }

    public Color GetColor(int index)
    {
        if (index < 0 || index >= _colors.Length)
        {
            Debug.LogWarning("Color index out of range.");
            return Color.black;
        }
        return _colors[index];
    }
} 

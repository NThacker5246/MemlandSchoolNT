using UnityEngine;

public class PerlinNoiseGenerator: MonoBehaviour
{
    private static PerlinNoiseGenerator s_Instance = null;
    public static PerlinNoiseGenerator Instance
    {
        get
        {
            if (s_Instance == null)
            {
                s_Instance = new PerlinNoiseGenerator();
            }

            return s_Instance;
        }
    }

    [SerializeField] private Texture2D _textureSource = new Texture2D(32, 32);

    [SerializeField] private int _width = 32;
    [SerializeField] private int _height = 32;

    [SerializeField] private float _noiseScale = 8.0f;

    [SerializeField] private float _offsetX = 0.0f;
    [SerializeField] private float _offsetY = 0.0f;

    public Texture2D GeneratePerlinNoise(Texture2D textureSource, int width, int height, float scale, float offsetX, float offsetY)
    {
        textureSource.Reinitialize(width, height); // Изменяем размер текстуры под указанные параметры.

        for (int x = 0; x < width; x++) // Проходимся по пикселям ширины.
        {
            for (int y = 0; y < height; y++) // Проходимся по пикселя высоты.
            {
                // Просчитывает и возвращаем цвет пикселя на позиции X,Y.
                Color color = CalculateColor(width, height, x, y, scale, offsetX, offsetY);
                textureSource.SetPixel(x, y, color); // Устанавливаем пиксель в текстуре.
            }
        }

        textureSource.Apply(); // Применяем все изменения в текстуре.
        return textureSource;
    }

    public void Start(){
    	_textureSource = GeneratePerlinNoise(_textureSource, _width, _height, _noiseScale, _offsetX, _offsetY);
    	GetComponent<Renderer>().material.mainTexture = _textureSource;
    }

    private Color CalculateColor(int width, int height, int x, int y, float scale, float offsetX, float offsetY)
    {
        float xCoord = (float)x / width * scale + offsetX; // Координата по X.
        float yCoord = (float)y / height * scale + offsetY; // Координата по Y.

        float sample = Mathf.PerlinNoise(xCoord, yCoord); // Сэмпл, который и станет цветом пикселя.
        return new Color(sample, sample, sample);
    }

    
}
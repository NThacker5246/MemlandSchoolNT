using UnityEngine;

public class ChangeTexture : MonoBehaviour
{
    public Texture2D newTexture; // Перетащите PNG рисунок сюда в окне "Inspector"

    void Start()
    {
        ChangeObjectTexture();
    }

    void ChangeObjectTexture()
    {
        Renderer renderer = GetComponent<Renderer>();

        if (renderer != null && newTexture != null)
        {
            // Создаем новый материал с новой текстурой
            Material newMaterial = new Material(renderer.sharedMaterial);
            newMaterial.mainTexture = newTexture;

            // Устанавливаем повторение текстуры на объекте
            newMaterial.mainTexture.wrapMode = TextureWrapMode.Repeat;

            // Устанавливаем масштабирование текстуры на объекте
            newMaterial.mainTextureScale = new Vector2(transform.localScale.x, transform.localScale.z);

            // Применяем новый материал к объекту
            renderer.sharedMaterial = newMaterial;
        }
    }
}

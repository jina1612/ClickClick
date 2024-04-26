using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite appleSprite;
    [SerializeField] private Sprite blueberrySprite;

    private bool isApple;

    public void SetSprite(bool isApple)
    {
        this.isApple = isApple;
        spriteRenderer.sprite = isApple ? appleSprite : blueberrySprite;

    }

    public void Destory()
    {
        GameObject.Destroy(gameObject);
        if (isApple)
        {
            SoundManager.Instance.Sound(0);
        }
        if (!isApple)
        {
            SoundManager.Instance.Sound(1);
        }
    }

    public void DeleteNote()
    {
        GameManager.Instance.CalculateScore(isApple);
        Destory();
    }
}





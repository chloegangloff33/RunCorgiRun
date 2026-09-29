using UnityEngine;

public class Corgi : MonoBehaviour
{
    private SpriteRenderer CorgiSpriteRenderer;

    public void Awake()
    {
        CorgiSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Move(Vector2 direction) //vector 2 has an x and y built into it - like saying (intx, inty)
    {
        FaceCorrectDirection(direction);
        Vector2 moveAmount = direction * GameParameters.CorgiMoveSpeed * Time.deltaTime;
        CorgiSpriteRenderer.transform.Translate(direction);
    }

    private void FaceCorrectDirection(Vector2 direction)
    {
        if (direction.x > 0)
        {
            CorgiSpriteRenderer.flipX = false;
        }
        else if (direction.x < 0)
        {
            CorgiSpriteRenderer.flipX = true;
        }
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}

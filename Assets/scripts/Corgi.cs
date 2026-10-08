using UnityEngine;
using System.Collections;


public class Corgi : MonoBehaviour
{

    public Sprite DrunkSprite;
    public Sprite SoberSprite;
    private bool isDrunk;
    
    private SpriteRenderer CorgiSpriteRenderer;
    

    public void Awake()
    {
        isDrunk = false;
        CorgiSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Move(Vector2 direction) //vector 2 has an x and y built into it - like saying (intx, inty)
    {
        direction = ApplyDrunkenness(direction);
        FaceCorrectDirection(direction);
        Vector2 moveAmount = direction * GameParameters.CorgiMoveSpeed * Time.deltaTime;
        CorgiSpriteRenderer.transform.Translate(direction); //(direction) should be (movement.x, movement.y, 0f) but missing code for that?
        
        //simple v good
        CorgiSpriteRenderer.transform.position = SpriteTools.ConstrainToScreen(CorgiSpriteRenderer);
    }

    private Vector2 ApplyDrunkenness(Vector2 direction)
    {
        if (isDrunk)
        {
            direction.x = direction.x * -1;
            direction.y = direction.y * -1;
        }
        
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Beer"))
        {
            if (other.gameObject.CompareTag("Beer"))
            {
                GetDrunk();
            }
        }
        else if (other.gameObject.CompareTag("Bone"))
        {
            ScorePoint();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Pill"))
        {
            SoberUp();
            Destroy(other.gameObject);
        }
    }

    private void ScorePoint()
    {
        print(message: "GOALLLLL");
    }

    private void GetDrunk()
    {
        isDrunk = true;
        ChangeToDrunkSprite();
        StartSoberingUp();
    }

    private void StartSoberingUp()
    {
        //timers are coroutines! -- coroutines always look like IEnumerator
        StartCoroutine(CountdownUntilSober());
    }

    IEnumerator CountdownUntilSober()
    {
        yield return new WaitForSeconds(GameParameters.CorgiDrunkSeconds);
        SoberUp();
    }

    private void SoberUp()
    {
        isDrunk = false;        
        ChangeToSoberSprite();
    }

    private void ChangeToSoberSprite()
    {
        CorgiSpriteRenderer.sprite = SoberSprite;
    }

    private void ChangeToDrunkSprite()
    {
        CorgiSpriteRenderer.sprite = DrunkSprite;
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

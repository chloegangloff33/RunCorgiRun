using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;


public class Corgi : MonoBehaviour
{
    private SpriteRenderer CorgiSpriteRenderer;
    public Sprite DrunkSprite;
    public Sprite SoberSprite;
    private bool isDrunk;
    private bool isPlastered;
    private Coroutine soberUpCoroutine;
    
    private int randomMoveCounter = 0;
    private int lastRandomeDirection = 0;
    
    

    public void Awake()
    {
        isDrunk = false;
        CorgiSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        if (isPlastered)
        {
            MoveRandomly();
        }
    }

    private void MoveRandomly()
    {
        int direction = lastRandomeDirection;
        if (randomMoveCounter == 0)
        {
            direction = Random.Range(0, 4);
            randomMoveCounter = Random.Range(GameParameters.CorgiMinimumRandomMoveLength, GameParameters.CorgiMaximumRandomMoveLength);
            lastRandomeDirection = direction;
        }

        switch (direction)
        {
            case 0:
                Move(Vector2.up);
                break;
            case 1:
                Move(Vector2.down);
                break;
            case 2:
                Move(Vector2.left);
                break;
            case 3:
                Move(Vector2.right);
                break;
        }
        randomMoveCounter--;
    }

    public void MoveManually(Vector2 direction)
    {
        if (isPlastered)
            return;
        Move(direction);
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
        if (!isDrunk)
        {
            return direction;
        }
        direction.x = direction.x * -1;
        direction.y = direction.y * -1;

        return direction;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Moonshine"))
        {
            GetPlastered();
            Destroy(other.gameObject);
        }
    }

    private void GetPlastered()
    {
        isPlastered = true;
        ChangeToDrunkSprite();
        StartSoberingUp(); 
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Beer"))
        {
            if (other.gameObject.CompareTag("Beer"))
            {
                GetDrunk();
                Destroy(other.gameObject);
            }
        }
        else if (other.gameObject.CompareTag("Bone"))
        {
            AddPointToScore();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Pill"))
        {
            SoberUp();
            Destroy(other.gameObject);
        }
    }

    private void AddPointToScore()
    {
        ScoreKeeper.AddPoint();
        print(message: "Score is: " + ScoreKeeper.GetScore());
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
        Inebriate();
    }

    private void Inebriate()
    {
        isPlastered = false;
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

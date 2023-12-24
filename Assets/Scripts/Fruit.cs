using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public Sprite appleSprite;
    public Sprite pinappleSprite;
    public Sprite strawberrySprite;
    public Sprite bananaSprite;
    public Sprite orangeSprite;
    public Sprite kiwiSprite;

    public int minRotationSpeed = 20;
    public int maxRotationSpeed = 50;

    private bool rotateClockwise = false;
    private bool rotateCounterClockwise = false;
    private bool vibrate = false;
    
    private float rotationSpeed;
    private float vibrationMaxPerSide = 20.0f;
    private float currentVibration = 0.0f;
    private bool vibrationClockWise = false;

    // Start is called before the first frame update
    void Start()
    {
        int animation = Random.Range(0, 4);
        switch (animation)
        {
            case 0:
                rotateClockwise = true;
                break;
            case 1:
                rotateCounterClockwise = true;
                break;
            case 2:
                vibrate = true;
                break;
            case 3:
                break;
        }
        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (rotateClockwise)
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
        else if (rotateCounterClockwise)
        {
            transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        }
        else if (vibrate && vibrationClockWise)
        {
            currentVibration += rotationSpeed * Time.deltaTime;
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
            vibrationClockWise = currentVibration < vibrationMaxPerSide;
        }
        else if (vibrate)
        {
            currentVibration -= rotationSpeed * Time.deltaTime;
            transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
            vibrationClockWise = currentVibration < -vibrationMaxPerSide;
        }
    }

    public void repaint(int fruitIndex)
    {
        switch (fruitIndex)
        {
            case 1:
                this.GetComponent<SpriteRenderer>().sprite = pinappleSprite;
                break;
            case 2:
                this.GetComponent<SpriteRenderer>().sprite = strawberrySprite;
                break;
            case 3:
                this.GetComponent<SpriteRenderer>().sprite = kiwiSprite;
                break;
            case 4:
                this.GetComponent<SpriteRenderer>().sprite = bananaSprite;
                break;
            case 5:
                this.GetComponent<SpriteRenderer>().sprite = orangeSprite;
                break;
            case 0:
                this.GetComponent<SpriteRenderer>().sprite = appleSprite;
                break;
        }
    }
}

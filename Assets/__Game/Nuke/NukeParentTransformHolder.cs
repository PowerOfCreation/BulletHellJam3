using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NukeParentTransformHolder : MonoBehaviour
{
    public static NukeParentTransformHolder self;

    private Animator animator;
    private Image image;

    public List<Sprite> sprites;

    public float chargePerSecond = 1;
    public float maxCharge = 10;

    private float currentCharge = 0f;

    public float decreaseGrowthAfterSeconds = 5f;
    public float nextDecreaseAtTime = 0f;

    public float decreasePerSecond = 2f;

    public bool isCharged = false;

    void Awake()
    {
        self = this;
        animator = GetComponentInChildren<Animator>();
        image = GetComponentInChildren<Image>();
        positionX = transform.position.x;
    }

    public void Update()
    {
        if(!isCharged && currentCharge > 0 && nextDecreaseAtTime < Time.time)
        {
            currentCharge -= decreasePerSecond * Time.time;
            if(currentCharge < 0f)
            {
                currentCharge = 0f;
            }
        }
    }

    public void Charge()
    {
        currentCharge += chargePerSecond * Time.deltaTime;
        UpdateSpriteRenderer();
    }

    public void UpdateSpriteRenderer()
    {
        if(currentCharge >= maxCharge)
        {
            isCharged = true;
        }
        
        nextDecreaseAtTime = Time.time + decreaseGrowthAfterSeconds;

        float sum = 0f;

        for (int i = 0; i < sprites.Count; i++)
        {
            sum += maxCharge / sprites.Count;

            if(currentCharge <= sum)
            {
                image.sprite = sprites[i];
                break;
            }
        }
    }

    float positionX;

    void Start()
    {
        AdjustPositionToScreen();
        ScreenBoundary.screenChanged += AdjustPositionToScreen;
    }

    void AdjustPositionToScreen()
    {
        transform.position = new Vector3(((((17.8f / (Camera.main.orthographicSize * (16f/9f) * 2f)) -1f) * 2f) + 1f)  * positionX, transform.position.y, 0);
    }

    void OnDestroy()
    {
        ScreenBoundary.screenChanged -= AdjustPositionToScreen;
    }
}

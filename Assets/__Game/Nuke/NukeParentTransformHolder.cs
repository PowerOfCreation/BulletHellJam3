using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukeParentTransformHolder : MonoBehaviour
{
    public static NukeParentTransformHolder self;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

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
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
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
                spriteRenderer.sprite = sprites[i];
                break;
            }
        }
    }
}

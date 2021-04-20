using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class NukeParentTransformHolder : MonoBehaviour
{
    public static NukeParentTransformHolder self;

    private Animator animator;
    private Image image;

    public Image nukeChargedImage;
    public Animator nukeChargedAnimator;

    public float chargePerSecond = 1;
    public float maxCharge = 10;

    private float currentCharge = 0f;

    public float decreaseGrowthAfterSeconds = 5f;
    public float nextDecreaseAtTime = 0f;

    public float decreasePerSecond = 2f;

    public bool isCharged = false;

    public List<GameObject> nukeableGameObjects = new List<GameObject>();

    void Awake()
    {
        self = this;
        animator = GetComponentInChildren<Animator>();
        image = GetComponentInChildren<Image>();
        positionX = transform.position.x;
    }

    public void Update()
    {
        if(!isCharged && currentCharge > 0f && nextDecreaseAtTime < Time.time)
        {
            currentCharge -= decreasePerSecond * Time.deltaTime;

            if(currentCharge < 0f)
            {
                currentCharge = 0f;
            }

            UpdateSpriteRenderer();
        }
    }

    public bool Charge()
    {
        if(isCharged) return false;

        currentCharge += chargePerSecond * Time.deltaTime;
        nextDecreaseAtTime = Time.time + decreaseGrowthAfterSeconds;
        UpdateSpriteRenderer();

        return true;
    }

    public void Nuke()
    {
        if(!isCharged) return;

        isCharged = false;
        currentCharge = 0f;

        var enemyHealths = EnemyHolder.self.GetComponentsInChildren<EnemyHealth>();

        for(int i = 0; i < enemyHealths.Length; i++)
        {
            enemyHealths[i].Damage(100);
        }

        nukeChargedAnimator.SetBool("isCharged", false);
        UpdateSpriteRenderer();
    }

    public void UpdateSpriteRenderer()
    {
        if(currentCharge >= maxCharge)
        {
            isCharged = true;
            nukeChargedAnimator.SetBool("isCharged", true);
        }

        nukeChargedImage.fillAmount = currentCharge / maxCharge;
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

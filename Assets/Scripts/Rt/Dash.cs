using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController2D))]
public class Dash : OwnedObject
{
    [SerializeField]
    public PlayerSpriteList dashSprites;

    [SerializeField]
    private float dashForce = 1500f;

    [SerializeField]
    private float dashDuration = 0.25f;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private bool isDashing;

    protected override void Awake()
	{
        base.Awake();
		rb = GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}

    void Update()
    {
        string suffix = ((Player)Owner).ToSuffix();
        if (Input.GetButtonDown("Dash" + suffix) && !isDashing)
            StartCoroutine(DashAnimation());
    }

    private IEnumerator DashAnimation()
    {
        isDashing = true;
        float dir = transform.eulerAngles.y < 90 ? 1 : -1;

        var originalSprite = spriteRenderer.sprite;
        spriteRenderer.sprite = dashSprites[Owner];
        rb.AddForce(new Vector2(dir * dashForce, 0f));

        yield return new WaitForSeconds(dashDuration);
        spriteRenderer.sprite = originalSprite;
        
        isDashing = false;
    }
}
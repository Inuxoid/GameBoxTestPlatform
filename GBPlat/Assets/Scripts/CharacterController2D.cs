using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI textScore;
	[SerializeField] private GameObject deathPanel;
	[SerializeField] private int hp;
	[SerializeField] private int score;
	[SerializeField] private UIController ui;
	[SerializeField] private Animator anim;
	[SerializeField] private Settings settings;
	[SerializeField] private float jumpForce = 400f;
	[Range(0, .3f)][SerializeField] private float movementSmoothing = .05f;
	[SerializeField] private bool airControl = false;
	[SerializeField] private LayerMask whatIsGround;
	[SerializeField] private Transform groundCheck;

	const float groundedRadius = .1f;
	private bool isGrounded;
	private Rigidbody2D rb;
	private bool m_FacingRight = true;
	private Vector3 velocity = Vector3.zero;
    private bool canDoubleJump;

    public int HP
    {
        get => hp; set
        {
            if (value > 0)
            {
				hp = value;
				ui.UIUpdate();
            }
            else
            {
				Death();
			}
        }
    }

	public int Score
	{
		get => score; set
		{
			score = value;
			ui.UIUpdate();
		}
	}

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}


	private void FixedUpdate()
	{
		isGrounded = false;

		Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);
		if (colliders.Length == 0)
        {
			isGrounded = false;
			anim.SetBool("isGrounded", false);
		}

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                isGrounded = true;
                anim.SetBool("isGrounded", true);
                break;
            }
        }
	}

	public void AddScore() => Score++;
	public void GetDamage()
    {
		HP--;
	}

	public void GetHeart()
	{
		HP++;
	}

	public void Death()
    {
		Destroy(gameObject.GetComponent<Collider2D>());
		airControl = false;
		StartCoroutine(DeathTimer());
	}

	public void Move(float move, bool crouch, bool jump)
	{
		if (anim.GetBool("isGrounded"))
			anim.SetFloat("horizontalVelocity", Math.Abs(move));

		if (isGrounded || airControl)
		{
			Vector3 targetVelocity = new Vector2(move * 10f, rb.velocity.y);
			rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movementSmoothing);

			if (move > 0 && !m_FacingRight)
			{
				Flip();
			}

			else if (move < 0 && m_FacingRight)
			{
				Flip();
			}
		}

		if (isGrounded && jump)
		{
			anim.SetBool("isGrounded", false);
			isGrounded = false;
			rb.AddForce(new Vector2(0f, jumpForce));
			canDoubleJump = true;
		} else if (canDoubleJump && jump)
        {
			canDoubleJump = false;
			rb.AddForce(new Vector2(0f, jumpForce));
		}
	}


	private void Flip()
	{
		m_FacingRight = !m_FacingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	IEnumerator DeathTimer()
	{
		yield return new WaitForSeconds(0.5f);
		settings.Pause();
		deathPanel.SetActive(true);
		textScore.text = (Score * 3).ToString();
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
	public class PlayerController : MonoBehaviour
	{
		public float movingSpeed;
		public float jumpForce;
		public bool blockInput;
		private float moveInput;
		private int jumpCounter = 0;

		private bool facingRight = false;
		[HideInInspector]
		//public bool deathState = false;

		private bool isGrounded;
		public Transform groundCheck;

		private Rigidbody2D rigidbody;
		private Animator animator;
		private GameManager gameManager;

		[SerializeField]
		private HpPlayer hp;
		private const float KNOCKBACK_FORCE = 150;
		private const int MAX_JUMPS = 2;

		void Start()
		{
			rigidbody = GetComponent<Rigidbody2D>();
			animator = GetComponent<Animator>();
			gameManager = GameManager.instance;

			if (hp == null)
			{
				hp = transform.GetComponent<HpPlayer>();
			}

		}

		private void FixedUpdate()
		{
			CheckGround();
		}

		void Update()
		{
			if (blockInput)
			{
				return;
			}

			if (Input.GetButton("Horizontal"))
			{
				moveInput = Input.GetAxis("Horizontal");
				Vector3 direction = transform.right * moveInput;
				transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, movingSpeed * Time.deltaTime);
				animator.SetInteger("playerState", 1); // Turn on run animation
			}
			else
			{
				if (isGrounded) animator.SetInteger("playerState", 0); // Turn on idle animation
			}
			if (Input.GetKeyDown(KeyCode.Space) && jumpCounter < MAX_JUMPS - 1)
			{
				jumpCounter = Mathf.Clamp(jumpCounter, 0, MAX_JUMPS - 1);
				rigidbody.linearVelocity = Vector2.zero;
				rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
				jumpCounter++;
			}
			if (!isGrounded) animator.SetInteger("playerState", 2); // Turn on jump animation

			if (facingRight == false && moveInput > 0)
			{
				Flip();
			}
			else if (facingRight == true && moveInput < 0)
			{
				Flip();
			}
		}

		private void Flip()
		{
			facingRight = !facingRight;
			Vector3 Scaler = transform.localScale;
			Scaler.x *= -1;
			transform.localScale = Scaler;
		}

		private void CheckGround()
		{
			Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.transform.position, 0.2f);
			isGrounded = colliders.Length > 1;

			if (isGrounded)
			{
				jumpCounter = 0;
			}
		}

		private void OnCollisionEnter2D(Collision2D other)
		{
			switch (other.gameObject.tag)
			{
				case "Enemy":
					hp.RemoveHp(1);

					Vector2 direction = facingRight ? Vector2.left : Vector2.right;
					direction += Vector2.up;
					rigidbody.AddForce(direction * KNOCKBACK_FORCE);
					break;

				case "Hazard":
					hp.RemoveHp(hp.maxHp);
					rigidbody.AddForce(Vector3.up * KNOCKBACK_FORCE);
					break;
			}
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.gameObject.tag == "Coin")
			{
				gameManager?.AddCoins(1);
				other.gameObject.SetActive(false);
			}
		}
	}
}

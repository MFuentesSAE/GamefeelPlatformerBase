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

		[SerializeField]
		public bool isGrounded;
		public Transform groundCheck;
		public LayerMask groundMask;

		private Rigidbody2D rigidbody;
		private Animator animator;
		private GameManager gameManager;

		[SerializeField]
		private HpPlayer hp;
		private const float KNOCKBACK_FORCE = 150;
		private const int MAX_JUMPS = 2;
		public float groundedRadius = 1;

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
		}

		void Update()
		{
			CheckGround();
			if (blockInput)
			{
				return;
			}

			moveInput = Input.GetAxisRaw("Horizontal");
			Vector3 direction = transform.right * moveInput;
			transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, movingSpeed * Time.deltaTime);

			if (isGrounded)
			{
				bool moving = Mathf.Abs(moveInput) > 0 ? true : false;
				animator?.SetBool("Moving", moving);
				animator?.SetBool("Jump", false);

			}

			if (Input.GetKeyDown(KeyCode.Space))
			{
				jumpCounter++;

				if (jumpCounter >= MAX_JUMPS)
				{
					return;
				}

				jumpCounter = Mathf.Clamp(jumpCounter, 0, MAX_JUMPS - 1);
				rigidbody.linearVelocity = Vector2.zero;
				rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
				animator?.SetBool("Jump", true);
			}

			if (!facingRight && moveInput > 0)
			{
				Flip();
			}
			else if (facingRight && moveInput < 0)
			{
				Flip();
			}
		}

		public void BlockInput(bool value)
		{
			blockInput = value;
		}

		public void Death()
		{
			BlockInput(true);
			animator?.SetBool("Death", true);
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
			Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.transform.position, groundedRadius, groundMask);
			isGrounded = colliders.Length > 0;

			if (isGrounded)
			{
				jumpCounter = 0;
			}
		}

		private void OnCollisionEnter2D(Collision2D other)
		{
			if (hp == null || !hp.IsAlive())
			{
				return;
			}

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

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.yellow;
			Gizmos.DrawWireSphere(groundCheck.transform.position, groundedRadius);
		}
	}
}

using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class BallControll : MonoBehaviour
{
	//[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static event Action eventEndTurn;

	private void OnEnable()
	{
		this.end = false;
		this.circleBox.enabled = true;
		this.touch = 0;
		this.rgb.WakeUp();
        this.rgb.velocity = BallControll.direction * this.force * (float)BallControll.duplicate;        
        
		GameControll.eventX2 += this.IncreaVelocity;
		GameControll.eventBallComeBack += this.BallComeBack;        
	}    

	private IEnumerator MoveEnd()
	{
		while (this.end)
		{
			//@TODO
			base.transform.position = Vector2.MoveTowards(base.transform.position, BallControll.posEnd, 20f * Time.deltaTime);
			if (base.transform.position == (Vector3)BallControll.posEnd)
			{
				BallControll.ballEndShow++;
				BallControll.ballEnd++;
				GameControll.instane.SetTextBall();
				if (BallControll.ballEnd == GameControll.instane.ballShooted && !GameControll.instane.shotBall)
				{
					BallControll.duplicate = 1;
					GameControll.instane.EndTurn();
					if (BallControll.eventEndTurn != null)
					{
						BallControll.eventEndTurn();
					}
				}
				GameControll.eventBallComeBack -= this.BallComeBack;
				GameControll.eventX2 -= this.IncreaVelocity;
                rgb.position = Vector2.zero;
				base.gameObject.SetActive(false);                
			}
			yield return null;
		}
		yield break;
	}

	private void BallComeBack()
	{
		this.circleBox.enabled = false;
		this.rgb.Sleep();
		this.end = true;
		BallControll.ballEndShow = GameControll.totalBall - GameControll.instane.ballShooted + BallControll.ballEnd;
		if (BallControll.ballEnd == 0)
		{
			BallControll.ballEnd = 1;
			GameControll.instane.SetPosBallFirst(BallControll.posEnd);
		}
		if (base.gameObject.activeInHierarchy)
		{
			base.StartCoroutine(this.MoveEnd());
		}
	}

	public static IEnumerator CheckEndTurn()
	{
		yield return new WaitUntil(() => BallControll.ballEnd == GameControll.instane.ballShooted);
		yield return null;
		if (!GameControll.instane.ballEnd)
		{
			GameControll.instane.EndTurn();
			if (BallControll.eventEndTurn != null)
			{
				BallControll.eventEndTurn();
			}
		}
		yield break;
	}

	public void IncreaVelocity()
	{
		this.rgb.velocity = this.rgb.velocity * 2f;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		try
		{
            // Prevent balls collide with the dim of a square.
            if (collision.gameObject.layer == 16)
            {
                Physics2D.IgnoreLayerCollision(16, 9);
            }
        }
		catch
		{

		}

        try
        {
            // Prevent balls collide with each other.
            if (collision.gameObject.layer == 9)
            {
                Physics2D.IgnoreLayerCollision(9, 9);
            }
        }
        catch
        {

        }

        this.touch++;
		if (this.touch % 5 == 0)
		{
			float x = this.rgb.velocity.x;
			float y = this.rgb.velocity.y;
			if (x < 0.5f && x >= 0f)
			{
				this.rgb.velocity = new Vector2(1f, y);
			}
			if (x > -0.5f && x <= 0f)
			{
				this.rgb.velocity = new Vector2(-1f, y);
			}
			if (y < 0.5f && y >= 0f)
			{
				this.rgb.velocity = new Vector2(x, 1f);
			}
			if (y > -0.5f && y <= 0f)
			{
				this.rgb.velocity = new Vector2(x, -1f);
			}            
		}
		if (collision.gameObject.CompareTag("bottom"))
		{
			this.rgb.Sleep();
			if (BallControll.ballEnd == 0)
			{
				BallControll.ballEnd++;
				BallControll.ballEndShow++;
				GameControll.instane.SetTextBall();
				BallControll.posEnd = new Vector2(base.transform.position.x, -5.445f);
				GameControll.instane.SetPosBallFirst(BallControll.posEnd);
				GameControll.eventX2 -= this.IncreaVelocity;
				GameControll.eventBallComeBack -= this.BallComeBack;
				base.gameObject.SetActive(false);
			}
			else
			{
				this.end = true;
				if (gameObject.activeSelf) base.StartCoroutine(this.MoveEnd());
			}
		}
	}

    private void OnTriggerEnter2D(Collider2D collision)
	{        
        if (collision.gameObject.layer == 19)
		{
			this.rgb.velocity = Vector2.zero;
			int num = UnityEngine.Random.Range(0, 5);
			if (num <= 2)
			{
				this.rgb.velocity = new Vector2(UnityEngine.Random.Range(-35f, -25f), UnityEngine.Random.Range(25f, 35f));
			}
			else
			{
				this.rgb.velocity = new Vector2(UnityEngine.Random.Range(25f, 35f), UnityEngine.Random.Range(25f, 35f));
			}
		}
	}

    private void OnDisable()
    {
		StopAllCoroutines();
    }

    public Rigidbody2D rgb;

	public float force;

	public CircleCollider2D circleBox;

	public static Vector2 direction;

	public static int ballEnd;

	public static int ballEndShow;

	public static Vector2 posEnd;

	public static int duplicate = 1;

	private bool end;

	private int touch;    
}

using System;
using System.Collections;
using UnityEngine;

public class ObjectPoolerManager : MonoBehaviour
{
	public static ObjectPoolerManager Instance { get; private set; }

	private void Awake()
	{
		if (ObjectPoolerManager.Instance == null)
		{
			ObjectPoolerManager.Instance = this;
		}
		else if (ObjectPoolerManager.Instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		if (this.effectTouchTgtrPooler == null)
		{
			GameObject gameObject = new GameObject("effectTouchTgtrPooler");
			this.effectTouchTgtrPooler = gameObject.AddComponent<ObjectPooler>();
			this.effectTouchTgtrPooler.PooledObject = this.effectTouchTgtrPrefab;
			gameObject.transform.parent = base.gameObject.transform;
			this.effectTouchTgtrPooler.Initialize();
		}
		if (this.effectTouchTgtlPlooer == null)
		{
			GameObject gameObject2 = new GameObject("effectTouchTgtlPlooer");
			this.effectTouchTgtlPlooer = gameObject2.AddComponent<ObjectPooler>();
			this.effectTouchTgtlPlooer.PooledObject = this.effectTouchTgtlPrefab;
			gameObject2.transform.parent = base.gameObject.transform;
			this.effectTouchTgtlPlooer.Initialize();
		}
		if (this.effectTouchTgbrPooler == null)
		{
			GameObject gameObject3 = new GameObject("effectTouchTgbtPooler");
			this.effectTouchTgbrPooler = gameObject3.AddComponent<ObjectPooler>();
			this.effectTouchTgbrPooler.PooledObject = this.effectTouchTgbtPrefab;
			gameObject3.transform.parent = base.gameObject.transform;
			this.effectTouchTgbrPooler.Initialize();
		}
		if (this.effectTouchTgblPlooer == null)
		{
			GameObject gameObject4 = new GameObject("effectTouchTgblPlooer");
			this.effectTouchTgblPlooer = gameObject4.AddComponent<ObjectPooler>();
			this.effectTouchTgblPlooer.PooledObject = this.effectTouchTgblPrefab;
			gameObject4.transform.parent = base.gameObject.transform;
			this.effectTouchTgblPlooer.Initialize();
		}
		if (this.effectTouchSquarePooler == null)
		{
			GameObject gameObject5 = new GameObject("effectTouchSquarePooler");
			this.effectTouchSquarePooler = gameObject5.AddComponent<ObjectPooler>();
			this.effectTouchSquarePooler.PooledObject = this.effectTouchSquarePrefab;
			gameObject5.transform.parent = base.gameObject.transform;
			this.effectTouchSquarePooler.Initialize();
		}
		if (this.effectStartPooler == null)
		{
			GameObject gameObject6 = new GameObject("effectStartPooler");
			this.effectStartPooler = gameObject6.AddComponent<ObjectPooler>();
			this.effectStartPooler.PooledObject = this.effectStartPrefab;
			gameObject6.transform.parent = base.gameObject.transform;
			this.effectStartPooler.Initialize();
		}
		if (this.effectPlusBallPooler == null)
		{
			GameObject gameObject7 = new GameObject("effectPlusBallPooler");
			this.effectPlusBallPooler = gameObject7.AddComponent<ObjectPooler>();
			this.effectPlusBallPooler.PooledObject = this.effectPlusBallPrefab;
			gameObject7.transform.parent = base.gameObject.transform;
			this.effectPlusBallPooler.Initialize();
		}
		if (this.brokenPooler == null)
		{
			GameObject gameObject8 = new GameObject("brokenPooler");
			this.brokenPooler = gameObject8.AddComponent<ObjectPooler>();
			this.brokenPooler.PooledObject = this.brokenPrefab;
			gameObject8.transform.parent = base.gameObject.transform;
			this.brokenPooler.Initialize();
		}
		if (this.effectLazerVerticalPooler == null)
		{
			GameObject gameObject9 = new GameObject("effectLazerVerticalPooler");
			this.effectLazerVerticalPooler = gameObject9.AddComponent<ObjectPooler>();
			this.effectLazerVerticalPooler.PooledObject = this.effectLazerVerticalPrefab;
			gameObject9.transform.parent = base.gameObject.transform;
			this.effectLazerVerticalPooler.Initialize();
		}
		if (this.effectLazerHorizontalPooler == null)
		{
			GameObject gameObject10 = new GameObject("effectLazerHorizontalPooler");
			this.effectLazerHorizontalPooler = gameObject10.AddComponent<ObjectPooler>();
			this.effectLazerHorizontalPooler.PooledObject = this.effectLazerHorizontalPrefab;
			gameObject10.transform.parent = base.gameObject.transform;
			this.effectLazerHorizontalPooler.Initialize();
		}
		if (this.effectBoomSquarePooler == null)
		{
			GameObject gameObject11 = new GameObject("effectBoomSquarePooler");
			this.effectBoomSquarePooler = gameObject11.AddComponent<ObjectPooler>();
			this.effectBoomSquarePooler.PooledObject = this.effectBoomSquarePrefab;
			gameObject11.transform.parent = base.gameObject.transform;
			this.effectBoomSquarePooler.Initialize();
		}
		if (this.effectBoomVerticalPooler == null)
		{
			GameObject gameObject12 = new GameObject("effectBoomVerticalPooler");
			this.effectBoomVerticalPooler = gameObject12.AddComponent<ObjectPooler>();
			this.effectBoomVerticalPooler.PooledObject = this.effectBoomVerticalPrefab;
			gameObject12.transform.parent = base.gameObject.transform;
			this.effectBoomVerticalPooler.Initialize();
		}
		if (this.effectBoomHorizontalPooler == null)
		{
			GameObject gameObject13 = new GameObject("effectBoomHorizontalPooler");
			this.effectBoomHorizontalPooler = gameObject13.AddComponent<ObjectPooler>();
			this.effectBoomHorizontalPooler.PooledObject = this.effectBoomHorizontalPrefab;
			gameObject13.transform.parent = base.gameObject.transform;
			this.effectBoomHorizontalPooler.Initialize();
		}
		if (this.xoayPooler == null)
		{
			GameObject gameObject14 = new GameObject("xoayPooler");
			this.xoayPooler = gameObject14.AddComponent<ObjectPooler>();
			this.xoayPooler.PooledObject = this.xoayPrefab;
			gameObject14.transform.parent = base.gameObject.transform;
			this.xoayPooler.Initialize();
		}
		if (this.plusBallPooler == null)
		{
			GameObject gameObject15 = new GameObject("plusBallPooler");
			this.plusBallPooler = gameObject15.AddComponent<ObjectPooler>();
			this.plusBallPooler.PooledObject = this.plusBallPrefab;
			gameObject15.transform.parent = base.gameObject.transform;
			this.plusBallPooler.Initialize();
		}
		if (this.laserCrossPooler == null)
		{
			GameObject gameObject16 = new GameObject("laserCrossPooler");
			this.laserCrossPooler = gameObject16.AddComponent<ObjectPooler>();
			this.laserCrossPooler.PooledObject = this.laserCrossPrefab;
			gameObject16.transform.parent = base.gameObject.transform;
			this.laserCrossPooler.Initialize();
		}
		if (this.laserVerticalPooler == null)
		{
			GameObject gameObject17 = new GameObject("laserVerticalPooler");
			this.laserVerticalPooler = gameObject17.AddComponent<ObjectPooler>();
			this.laserVerticalPooler.PooledObject = this.laserVerticalPrefab;
			gameObject17.transform.parent = base.gameObject.transform;
			this.laserVerticalPooler.Initialize();
		}
		if (this.laserHorizontalPooler == null)
		{
			GameObject gameObject18 = new GameObject("laserHorizontalPooler");
			this.laserHorizontalPooler = gameObject18.AddComponent<ObjectPooler>();
			this.laserHorizontalPooler.PooledObject = this.laserHorizontalPrefab;
			gameObject18.transform.parent = base.gameObject.transform;
			this.laserHorizontalPooler.Initialize();
		}
		if (this.squarePooler == null)
		{
			GameObject gameObject19 = new GameObject("squarePooler");
			this.squarePooler = gameObject19.AddComponent<ObjectPooler>();
			this.squarePooler.PooledObject = this.squarePrefab;
			gameObject19.transform.parent = base.gameObject.transform;
			this.squarePooler.Initialize();
		}
		if (this.ballPooler == null)
		{
			GameObject gameObject20 = new GameObject("ballPooler");
			this.ballPooler = gameObject20.AddComponent<ObjectPooler>();
			this.ballPooler.PooledObject = this.ballPrefab;
			gameObject20.transform.parent = base.gameObject.transform;
			this.ballPooler.Initialize();
		}
		if (this.triangleBottomLeftPooler == null)
		{
			GameObject gameObject21 = new GameObject("triangleBottomLeftPooler");
			this.triangleBottomLeftPooler = gameObject21.AddComponent<ObjectPooler>();
			this.triangleBottomLeftPooler.PooledObject = this.triangleBottomLeftPrefab;
			gameObject21.transform.parent = base.gameObject.transform;
			this.triangleBottomLeftPooler.Initialize();
		}
		if (this.triagleBottomRightPooler == null)
		{
			GameObject gameObject22 = new GameObject("triagleBottomRightPooler");
			this.triagleBottomRightPooler = gameObject22.AddComponent<ObjectPooler>();
			this.triagleBottomRightPooler.PooledObject = this.triagleBottomRightPrefab;
			gameObject22.transform.parent = base.gameObject.transform;
			this.triagleBottomRightPooler.Initialize();
		}
		if (this.triagleTopLeftPooler == null)
		{
			GameObject gameObject23 = new GameObject("triagleTopLeftPooler");
			this.triagleTopLeftPooler = gameObject23.AddComponent<ObjectPooler>();
			this.triagleTopLeftPooler.PooledObject = this.triagleTopLeftPrefab;
			gameObject23.transform.parent = base.gameObject.transform;
			this.triagleTopLeftPooler.Initialize();
		}
		if (this.triagleTopRightPooler == null)
		{
			GameObject gameObject24 = new GameObject("triagleTopRightPooler");
			this.triagleTopRightPooler = gameObject24.AddComponent<ObjectPooler>();
			this.triagleTopRightPooler.PooledObject = this.triagleTopRightPrefab;
			gameObject24.transform.parent = base.gameObject.transform;
			this.triagleTopRightPooler.Initialize();
		}
		if (this.squareHorizontalBomPooler == null)
		{
			GameObject gameObject25 = new GameObject("squareHorizontalBomPooler");
			this.squareHorizontalBomPooler = gameObject25.AddComponent<ObjectPooler>();
			this.squareHorizontalBomPooler.PooledObject = this.squareHorizontalBomPrefab;
			gameObject25.transform.parent = base.gameObject.transform;
			this.squareHorizontalBomPooler.Initialize();
		}
		if (this.squareVerticalBomPooler == null)
		{
			GameObject gameObject26 = new GameObject("squareVerticalBomPooler");
			this.squareVerticalBomPooler = gameObject26.AddComponent<ObjectPooler>();
			this.squareVerticalBomPooler.PooledObject = this.squareVerticalBomPrefab;
			gameObject26.transform.parent = base.gameObject.transform;
			this.squareVerticalBomPooler.Initialize();
		}
		if (this.squareCrossBomPooler == null)
		{
			GameObject gameObject27 = new GameObject("squareCrossBomPooler");
			this.squareCrossBomPooler = gameObject27.AddComponent<ObjectPooler>();
			this.squareCrossBomPooler.PooledObject = this.squareCrossBomPrefab;
			gameObject27.transform.parent = base.gameObject.transform;
			this.squareCrossBomPooler.Initialize();
		}
		if (this.squareSquareBomPooler == null)
		{
			GameObject gameObject28 = new GameObject("squareSquareBomPooler");
			this.squareSquareBomPooler = gameObject28.AddComponent<ObjectPooler>();
			this.squareSquareBomPooler.PooledObject = this.squareSquareBomPrefab;
			gameObject28.transform.parent = base.gameObject.transform;
			this.squareSquareBomPooler.Initialize();
		}
	}

	public void OffAllObject()
	{
		IEnumerator enumerator = base.transform.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Transform transform = (Transform)obj;
				transform.GetComponent<ObjectPooler>().DisableAllObject();
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = (enumerator as IDisposable)) != null)
			{
				disposable.Dispose();
			}
		}
	}

	[HideInInspector]
	public ObjectPooler squarePooler;

	[HideInInspector]
	public ObjectPooler ballPooler;

	[HideInInspector]
	public ObjectPooler triangleBottomLeftPooler;

	[HideInInspector]
	public ObjectPooler triagleBottomRightPooler;

	[HideInInspector]
	public ObjectPooler triagleTopLeftPooler;

	[HideInInspector]
	public ObjectPooler triagleTopRightPooler;

	[HideInInspector]
	public ObjectPooler squareHorizontalBomPooler;

	[HideInInspector]
	public ObjectPooler squareVerticalBomPooler;

	[HideInInspector]
	public ObjectPooler squareCrossBomPooler;

	[HideInInspector]
	public ObjectPooler squareSquareBomPooler;

	[HideInInspector]
	public ObjectPooler laserHorizontalPooler;

	[HideInInspector]
	public ObjectPooler laserVerticalPooler;

	[HideInInspector]
	public ObjectPooler laserCrossPooler;

	[HideInInspector]
	public ObjectPooler plusBallPooler;

	[HideInInspector]
	public ObjectPooler xoayPooler;

	[HideInInspector]
	public ObjectPooler effectBoomHorizontalPooler;

	[HideInInspector]
	public ObjectPooler effectBoomVerticalPooler;

	[HideInInspector]
	public ObjectPooler effectBoomSquarePooler;

	[HideInInspector]
	public ObjectPooler effectLazerHorizontalPooler;

	[HideInInspector]
	public ObjectPooler effectLazerVerticalPooler;

	[HideInInspector]
	public ObjectPooler brokenPooler;

	[HideInInspector]
	public ObjectPooler effectPlusBallPooler;

	[HideInInspector]
	public ObjectPooler effectStartPooler;

	[HideInInspector]
	public ObjectPooler effectTouchSquarePooler;

	[HideInInspector]
	public ObjectPooler effectTouchTgblPlooer;

	[HideInInspector]
	public ObjectPooler effectTouchTgbrPooler;

	[HideInInspector]
	public ObjectPooler effectTouchTgtlPlooer;

	[HideInInspector]
	public ObjectPooler effectTouchTgtrPooler;

	public GameObject squarePrefab;

	public GameObject ballPrefab;

	public GameObject triangleBottomLeftPrefab;

	public GameObject triagleBottomRightPrefab;

	public GameObject triagleTopLeftPrefab;

	public GameObject triagleTopRightPrefab;

	public GameObject squareHorizontalBomPrefab;

	public GameObject squareVerticalBomPrefab;

	public GameObject squareCrossBomPrefab;

	public GameObject squareSquareBomPrefab;

	public GameObject laserHorizontalPrefab;

	public GameObject laserVerticalPrefab;

	public GameObject laserCrossPrefab;

	public GameObject plusBallPrefab;

	public GameObject xoayPrefab;

	public GameObject effectBoomHorizontalPrefab;

	public GameObject effectBoomVerticalPrefab;

	public GameObject effectBoomSquarePrefab;

	public GameObject effectLazerHorizontalPrefab;

	public GameObject effectLazerVerticalPrefab;

	public GameObject brokenPrefab;

	public GameObject effectPlusBallPrefab;

	public GameObject effectStartPrefab;

	public GameObject effectTouchSquarePrefab;

	public GameObject effectTouchTgblPrefab;

	public GameObject effectTouchTgbtPrefab;

	public GameObject effectTouchTgtlPrefab;

	public GameObject effectTouchTgtrPrefab;
}

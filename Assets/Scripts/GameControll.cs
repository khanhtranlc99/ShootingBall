using com.F4A.MobileThird;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class GameControll : MonoBehaviour
{
	//[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static event Action eventBallComeBack;

	//[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static event Action eventX2;

	private void Awake()
	{
#if ENABLE_RESOLUTION
		Screen.SetResolution(1080, 1920, true);
#endif
		if (GameControll.instane == null)
		{
			GameControll.instane = this;
		}
		bool sound = GameUtilsOld.Sound;
		if (!sound)
		{
			if (!sound)
			{
				ControlSound.instance.OffSound();
			}
		}
		else
		{
			ControlSound.instance.OnSound();
		}
		if (!PlayerPrefs.HasKey(DataString.levelUnlock))
		{
			PlayerPrefs.SetInt(DataString.levelUnlock, 1);
		}
		if (!PlayerPrefs.HasKey("1"))
		{
			PlayerPrefs.SetInt("1", 0);
		}
	}

	private void Start()
	{
		GameController.Instance.admobAds.googleAdmobe.RequestBannerAd();
		if (GameControll.firstLoaded)
		{
			LeanTween.delayedCall(3f, delegate()
			{
				//SG_AdManager.ads.RequestAds();
			});
		}
		this.slMoveNext = 0;
		CheckGameEndFail.checkWatchedVideos = false;
		GameControll.firstLoaded = true;
		this.imgRunStar.fillAmount = 0f;
		this.shotBall = false;
		this.vectorUnit = new Vector2(0f, 0.99f + this.Yspace);
		TextAsset textAsset = Resources.Load<TextAsset>("ball_starting");
		string[] array = textAsset.text.Split(new char[]
		{
			'\n'
		});
		for (int i = 0; i < array.Length; i++)
		{
			GameControll.startBalls.Add(int.Parse(array[i].ToString()));
		}
		this.ObjectPooling = GameObject.Find("ObjectPooling").transform;
		ControlSound.instance.PlaySoundStart();
		if (GameControll.levelPlaying != 0)
		{
			if (GameControll.levelPlaying == PlayerPrefs.GetInt("b"))
			{
				int @int = PlayerPrefs.GetInt("j");
				int int2 = PlayerPrefs.GetInt("o");
				if (@int == 0 || int2 < GameControll.levelPlaying)
				{
					GameObject pooledObject = ObjectPoolerManager.Instance.effectStartPooler.GetPooledObject();
					pooledObject.transform.position = Vector3.zero;
					pooledObject.SetActive(true);
					GameControll.totalBall = GameControll.startBalls[GameControll.levelPlaying - 1];
					this.txtStage.text = "Stage - " + GameControll.levelPlaying.ToString();
					this.posBallFirst = new Vector2(0f, -5.445f);
					BallControll.posEnd = new Vector2(0f, -5.445f);
					this.ballImageStart.transform.position = BallControll.posEnd;
					this.txtSllBallStart.text = "x" + GameControll.totalBall.ToString();
					this.ballImageStart.SetActive(true);
					this.txtSllBallStart.gameObject.SetActive(true);
					this.ballImageEnd.SetActive(false);
					this.score = 0;
					this.star = 0;
					base.StopAllCoroutines();
					this.LoadDataMap();
					this.GetPositionSpawnItem();
					this.SpawnItemFirst();
					this.CalculateMaxScore();
					this.SetStar();
				}
				else
				{
					this.LoadGame();
				}
			}
			else
			{
				GameObject pooledObject2 = ObjectPoolerManager.Instance.effectStartPooler.GetPooledObject();
				pooledObject2.transform.position = Vector3.zero;
				pooledObject2.SetActive(true);
				GameControll.totalBall = GameControll.startBalls[GameControll.levelPlaying - 1];
				this.txtStage.text = "Stage - " + GameControll.levelPlaying.ToString();
				this.posBallFirst = new Vector2(0f, -5.445f);
				BallControll.posEnd = new Vector2(0f, -5.445f);
				this.ballImageStart.transform.position = BallControll.posEnd;
				this.txtSllBallStart.text = "x" + GameControll.totalBall.ToString();
				this.ballImageStart.SetActive(true);
				this.txtSllBallStart.gameObject.SetActive(true);
				this.ballImageEnd.SetActive(false);
				this.score = 0;
				this.star = 0;
				base.StopAllCoroutines();
				this.LoadDataMap();
				this.GetPositionSpawnItem();
				this.SpawnItemFirst();
				this.CalculateMaxScore();
				this.SetStar();
			}
		}
		else
		{
			LeanTween.delayedCall(2f, delegate()
			{
				if (RemoteSettingsHandler.remoteSettingsHandler.display_home_ads)
				{
					MoreAppController.instance.ShowSmartMoreApp();
					BackDeviceGame.status = 1;
				}
			});
			if (PlayerPrefs.GetInt("j") == 0)
			{
				GameObject pooledObject3 = ObjectPoolerManager.Instance.effectStartPooler.GetPooledObject();
				pooledObject3.transform.position = Vector3.zero;
				pooledObject3.SetActive(true);
				GameControll.levelPlaying = PlayerPrefs.GetInt("b");
				GameControll.totalBall = GameControll.startBalls[GameControll.levelPlaying - 1];
				this.txtStage.text = "Stage - " + GameControll.levelPlaying.ToString();
				this.posBallFirst = new Vector2(0f, -5.445f);
				BallControll.posEnd = new Vector2(0f, -5.445f);
				this.ballImageStart.transform.position = BallControll.posEnd;
				this.txtSllBallStart.text = "x" + GameControll.totalBall.ToString();
				this.ballImageStart.SetActive(true);
				this.txtSllBallStart.gameObject.SetActive(true);
				this.ballImageEnd.SetActive(false);
				this.score = 0;
				this.star = 0;
				base.StopAllCoroutines();
				this.LoadDataMap();
				this.GetPositionSpawnItem();
				this.SpawnItemFirst();
				this.CalculateMaxScore();
				this.SetStar();
			}
			else
			{
				this.LoadGame();
			}
		}
		if (GameControll.levelPlaying == 1)
		{
			this.tutorial.SetActive(true);
		}
		this.endTurn = true;
		GameControll.totalBall += RemoteSettingsHandler.remoteSettingsHandler.ball_bonus;
		PlayerPrefs.SetInt("j", 1);
		this.SaveGame();
		EventsManager.Instance.LogEvent("game_play", new Dictionary<string, object>
		{
			{
				"level_number",
				GameControll.levelPlaying
			}
		});
		this.SetAdsAfterOrBefore();
		EventDispatcher.EventDispatcher.Instance.RegisterListener(EventID.CHANGE_ADD_BALL, ChangeText);
		EventDispatcher.EventDispatcher.Instance.RegisterListener(EventID.CHANGE_THUNDER, ChangeText);
		tvAddBall.text = "" + UseProfile.AddBallsBooster;
		tvThunder.text = "" + UseProfile.ThunderBooster;
	}
	public List<BallControll> lsBallControlls; 
	private IEnumerator ShootBall()
	{
		while (this.shotBall)
		{
			if (this.ballShooted < this.totalBallNow)
			{
				if (Time.time - this.previousTime > 0.08f)
				{
					GameObject pooledObject = ObjectPoolerManager.Instance.ballPooler.GetPooledObject();
					pooledObject.transform.position = this.posSpawnBall;
					BallControll.direction = this.direction;
					pooledObject.SetActive(true);
					this.ballShooted++;
					this.previousTime = Time.time;
				}
				if (this.ballShooted == this.totalBallNow)
				{
					this.shotBall = false;
					this.ballImageStart.SetActive(false);
				}
			}
			yield return new WaitForFixedUpdate();
		}
		yield break;
	}

	private IEnumerator RunLineStar()
	{
		if (this.ratioScore > this.setFillAmountOneStar)
		{
			while (this.imgRunStar.fillAmount != this.ratioScore)
			{
				this.imgRunStar.fillAmount = Mathf.Lerp(this.imgRunStar.fillAmount, this.ratioScore, Time.deltaTime);
				yield return null;
			}
		}
		yield break;
	}

	private void OnApplicationQuit()
	{
		this.hits = Physics2D.BoxCastAll(base.transform.position, this.boxCheckAll.size, 0f, Vector2.zero, 0f, 1024);
		if (this.hits.Length == 0)
		{
			this.CheckKeys();
			if (!this.checkKey)
			{
				if (GameControll.levelPlaying >= PlayerPrefs.GetInt("b"))
				{
					PlayerPrefs.SetInt("b", GameControll.levelPlaying + 1);
				}
				PlayerPrefs.SetInt("j", 0);
				ControlEndgame.win = true;
				ControlEndgame.SetEndGame();
			}
		}
	}

	public void StartPlay()
	{
		if (GameControll.firstLoaded)
		{
			LeanTween.delayedCall(3f, delegate()
			{
				//SG_AdManager.ads.RequestAds();
			});
		}
		this.slMoveNext = 0;
		GameControll.firstLoaded = true;
		CheckGameEndFail.checkWatchedVideos = false;
		this.imgRunStar.fillAmount = 0f;
		this.shotBall = false;
		ControlSound.instance.PlaySoundStart();
		this.dangreous.SetActive(false);
		this.dangreous.transform.parent.gameObject.SetActive(true);
		this.groupBallComeBack.SetActive(false);
		this.groupShootBall.SetActive(true);
		if (GameControll.levelPlaying != 0)
		{
			GameObject pooledObject = ObjectPoolerManager.Instance.effectStartPooler.GetPooledObject();
			pooledObject.transform.position = Vector3.zero;
			pooledObject.SetActive(true);
			GameControll.totalBall = GameControll.startBalls[GameControll.levelPlaying - 1];
			this.txtStage.text = "Stage - " + GameControll.levelPlaying.ToString();
			this.posBallFirst = new Vector2(0f, -5.445f);
			BallControll.posEnd = new Vector2(0f, -5.445f);
			this.ballImageStart.transform.position = BallControll.posEnd;
			this.txtSllBallStart.text = "x" + GameControll.totalBall.ToString();
			this.ballImageStart.SetActive(true);
			this.txtSllBallStart.gameObject.SetActive(true);
			this.ballImageEnd.SetActive(false);
			this.score = 0;
			this.star = 0;
			base.StopAllCoroutines();
			this.LoadDataMap();
			this.GetPositionSpawnItem();
			this.SpawnItemFirst();
			this.CalculateMaxScore();
			this.SetStar();
		}
		else if (PlayerPrefs.GetInt("j") == 0)
		{
			GameObject pooledObject2 = ObjectPoolerManager.Instance.effectStartPooler.GetPooledObject();
			pooledObject2.transform.position = Vector3.zero;
			pooledObject2.SetActive(true);
			GameControll.levelPlaying = PlayerPrefs.GetInt("b");
			GameControll.totalBall = GameControll.startBalls[GameControll.levelPlaying - 1];
			this.txtStage.text = "Stage - " + GameControll.levelPlaying.ToString();
			this.posBallFirst = new Vector2(0f, -5.445f);
			BallControll.posEnd = new Vector2(0f, -5.445f);
			this.ballImageStart.transform.position = BallControll.posEnd;
			this.txtSllBallStart.text = "x" + GameControll.totalBall.ToString();
			this.ballImageStart.SetActive(true);
			this.txtSllBallStart.gameObject.SetActive(true);
			this.ballImageEnd.SetActive(false);
			this.score = 0;
			this.star = 0;
			base.StopAllCoroutines();
			this.LoadDataMap();
			this.GetPositionSpawnItem();
			this.SpawnItemFirst();
			this.CalculateMaxScore();
			this.SetStar();
		}
		else
		{
			this.LoadGame();
		}
		if (GameControll.levelPlaying == 1)
		{
			this.tutorial.SetActive(true);
		}
		this.endTurn = true;
		GameControll.totalBall += RemoteSettingsHandler.remoteSettingsHandler.ball_bonus;
		PlayerPrefs.SetInt("j", 1);
		this.SaveGame();
		EventsManager.Instance.LogEvent("game_play", new Dictionary<string, object>
        {
            {
                "level_number",
                GameControll.levelPlaying
            }
        });
		this.SetAdsAfterOrBefore();
	}

	private void SetAdsAfterOrBefore()
	{
		int num = UnityEngine.Random.Range(0, RemoteSettingsHandler.remoteSettingsHandler.inters_ads_before_ratio + RemoteSettingsHandler.remoteSettingsHandler.inters_ads_after_ratio);
		if (num < RemoteSettingsHandler.remoteSettingsHandler.inters_ads_before_ratio)
		{
			this.placementIntersAds = GameControll.PlacementIntersAds.BEFORE;
		}
		else
		{
			this.placementIntersAds = GameControll.PlacementIntersAds.AFTER;
		}
	}

	private void SaveGame()
	{
		PlayerPrefs.SetInt("f", GameControll.totalBall);
		PlayerPrefs.SetInt("e", GameControll.levelPlaying);
		PlayerPrefs.SetInt("d", this.score);
		PlayerPrefs.SetInt("g", this.maxScore);
		PlayerPrefs.SetFloat("m", this.posBallFirst.x);
		PlayerPrefs.SetFloat("n", this.posBallFirst.y);
		PlayerPrefs.SetInt("o", GameControll.levelPlaying);
		int num = this.slMoveNext * 9;
		this.strKey = string.Empty;
		this.strValue = string.Empty;
		for (int i = GameControll.keysDim.Count - 1; i >= num; i--)
		{
			if (i >= 0)
			{
				if (i == num || i == 0)
				{
					this.strKey += GameControll.keysDim[i].ToString();
					this.strValue += GameControll.valuesDim[i].ToString();
				}
				else
				{
					this.strKey = this.strKey + GameControll.keysDim[i].ToString() + ",";
					this.strValue = this.strValue + GameControll.valuesDim[i].ToString() + ",";
				}
			}
			else
			{
				this.strKey += ",0";
				this.strValue += ",0";
			}
		}
		PlayerPrefs.SetString("h", this.strKey);
		PlayerPrefs.SetString("i", this.strValue);
	}

	private void LoadGame()
	{
		GameObject pooledObject = ObjectPoolerManager.Instance.effectStartPooler.GetPooledObject();
		pooledObject.transform.position = Vector3.zero;
		pooledObject.SetActive(true);
		GameControll.levelPlaying = PlayerPrefs.GetInt("e");
		GameControll.totalBall = PlayerPrefs.GetInt("f");
		this.txtStage.text = "Stage - " + GameControll.levelPlaying.ToString();
		this.posBallFirst = new Vector2(PlayerPrefs.GetFloat("m"), PlayerPrefs.GetFloat("n"));
		BallControll.posEnd = this.posBallFirst;
		this.ballImageStart.transform.position = BallControll.posEnd;
		this.txtSllBallStart.text = "x" + GameControll.totalBall.ToString();
		this.ballImageStart.SetActive(true);
		this.txtSllBallStart.gameObject.SetActive(true);
		this.ballImageEnd.SetActive(false);
		this.score = PlayerPrefs.GetInt("d");
		this.star = 0;
		base.StopAllCoroutines();
		this.LoadDataMapPlaying();
		this.GetPositionSpawnItem();
		this.SpawnItemFirst();
		this.CalculateMaxScore();
		this.SetStar();
	}

	public void CalculateScore()
	{
		this.score += this.baseScore;
		this.baseScore += 10;
		this.SetStar();
	}

	private void CalculateMaxScore()
	{
		this.maxScore = 0;
		if (GameControll.levelPlaying <= 5)
		{
			switch (GameControll.levelPlaying)
			{
			case 1:
				this.maxScore = 30;
				break;
			case 2:
				this.maxScore = 60;
				break;
			case 3:
				this.maxScore = 270;
				break;
			case 4:
				this.maxScore = 550;
				break;
			case 5:
				this.maxScore = 780;
				break;
			}
		}
		else
		{
			float num = (float)this.totalBricks / 2f + 2f;
			int num2 = 0;
			while ((float)num2 < num)
			{
				this.maxScore += 10 * (num2 + 1);
				num2++;
			}
		}
	}

	private void SetStar()
	{
		this.ratioScore = (float)this.score / (float)this.maxScore;
		this.txtScore.text = this.score.ToString();
		if (this.score == 0)
		{
			this.effectStar1.Reset();
			this.effectStar2.Reset();
			this.effectStar3.Reset();
			this.setFillAmountOneStar = 0f;
			this.txtScore.text = this.score.ToString();
		}
		if (10 <= this.score && this.star < 1)
		{
			this.effectStar1.Win();
			this.setFillAmountOneStar = 0.05f;
			this.imgRunStar.fillAmount = this.setFillAmountOneStar;
			this.star = 1;
		}
		if ((int)((float)this.maxScore * 0.7f) <= this.score && this.star < 2)
		{
			this.effectStar2.Win();
			this.star = 2;
			base.StartCoroutine(this.RunLineStar());
		}
		if (this.score >= this.maxScore && this.star < 3)
		{
			this.effectStar3.Win();
			this.star = 3;
		}
		base.StartCoroutine(this.RunLineStar());
	}

	public void PointerDown()
	{
		if (this.endTurn)
		{
			this.tutorial.SetActive(false);
			float y = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition).y;
			if (y > -4.8f)
			{
				this.posHand = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
				this.direction = (this.posHand - this.posBallFirst).normalized;
				this.pointDim = Physics2D.Raycast(this.posBallFirst, this.direction, 50f, 65536);
				this.lineRenderer1.enabled = true;
				this.lineRenderer2.enabled = true;
				this.lineRenderer1.SetPosition(0, this.posBallFirst);
				if (this.pointDim)
				{
					this.ballDim.SetActive(true);
					this.ballDim.transform.position = this.pointDim.point;
				}
				if (this.pointDim)
				{
					this.lineRenderer1.SetPosition(1, this.pointDim.point);
					Vector2 a = Vector2.Reflect(this.pointDim.point - this.posBallFirst, this.pointDim.normal).normalized * 2f;
					this.lineRenderer2.SetPosition(0, this.pointDim.point);
					this.lineRenderer2.SetPosition(1, a + this.pointDim.point);
				}
				else
				{
					this.endLine = this.posBallFirst + this.direction * 50f;
					this.lineRenderer1.SetPosition(1, this.endLine);
				}
				this.down = true;
			}
			this.ballImageStart.transform.position = BallControll.posEnd;
			this.txtSllBallStart.text = "x" + GameControll.totalBall.ToString();
			this.ballImageStart.SetActive(true);
			this.txtSllBallStart.gameObject.SetActive(true);
			this.ballImageEnd.SetActive(false);
			this.baseScore = 10;
		}
	}

	public void PointerDrag()
	{
		if (this.down)
		{
			if (this.pointDim.point.y > -4.8f)
			{
				this.posHand = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
				this.direction = (this.posHand - this.posBallFirst).normalized;
				this.pointDim = Physics2D.Raycast(this.posBallFirst, this.direction, 50f, 65536);
				if (this.pointDim)
				{
					this.ballDim.SetActive(true);
					this.ballDim.transform.position = this.pointDim.point;
				}
				if (this.pointDim)
				{
					this.lineRenderer1.SetPosition(1, this.pointDim.point);
					Vector2 a = Vector2.Reflect(this.pointDim.point - this.posBallFirst, this.pointDim.normal).normalized * 2f;
					this.lineRenderer2.SetPosition(0, this.pointDim.point);
					this.lineRenderer2.SetPosition(1, a + this.pointDim.point);
				}
				else
				{
					this.endLine = this.posBallFirst + this.direction * 50f;
					this.lineRenderer1.SetPosition(1, this.endLine);
				}
			}
			else
			{
				this.posHand = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
				this.directionOut = (this.posHand - this.posBallFirst).normalized;
				this.pointDim = Physics2D.Raycast(this.posBallFirst, this.directionOut, 50f, this.layerWall);
			}
		}
	}

	public void PointerUp()
	{
		if (this.down)
		{
			this.lineRenderer1.enabled = false;
			this.lineRenderer2.enabled = false;
			this.endTurn = false;
			this.down = false;
			this.groupBallComeBack.SetActive(true);
			this.groupShootBall.SetActive(false);
			this.txtSllBallStart.gameObject.SetActive(false);
			this.dangreous.SetActive(false);
			base.StartCoroutine(this.Duplicated());
			this.totalBallNow = GameControll.totalBall;
			this.posSpawnBall = this.posBallFirst;
			this.previousTime = Time.time;
			this.ballDim.SetActive(false);
			this.ballEnd = false;
			this.ballShooted = 0;
			BallControll.ballEnd = 0;
			BallControll.ballEndShow = 0;
			this.shotBall = true;
			base.StartCoroutine(this.ShootBall());
		}
	}

	public void PointerExit()
	{
		this.down = false;
		this.ballDim.SetActive(false);
		this.lineRenderer1.enabled = false;
		this.lineRenderer2.enabled = false;
	}

	public void OnPointerDown()
	{
		if (this.endTurn)
		{
			this.tutorial.SetActive(false);
			this.lineRenderer1.enabled = true;
			this.lineRenderer2.enabled = true;
			float x = 2f * this.slider.value - 1f;
			float y = (-36f * Mathf.Pow(this.slider.value, 2f) + 36f * this.slider.value + 1f) / 10f;
			this.direction = new Vector2(x, y);
			this.pointDim = Physics2D.Raycast(this.posBallFirst, this.direction, 50f, 65536);
			this.lineRenderer1.SetPosition(0, this.posBallFirst);
			if (this.pointDim)
			{
				this.lineRenderer1.SetPosition(1, this.pointDim.point);
				Vector2 normalized = Vector2.Reflect(this.pointDim.point - this.posBallFirst, this.pointDim.normal).normalized;
				this.lineRenderer2.SetPosition(0, this.pointDim.point);
				this.lineRenderer2.SetPosition(1, normalized + this.pointDim.point);
				this.ballDim.SetActive(true);
				this.ballDim.transform.position = this.pointDim.point;
			}
			else
			{
				this.endLine = this.posBallFirst + this.direction * 50f;
				this.lineRenderer1.SetPosition(1, this.endLine);
			}
			this.shootBySlider = true;
			this.ballImageStart.transform.position = BallControll.posEnd;
			this.txtSllBallStart.text = "x" + GameControll.totalBall.ToString();
			this.ballImageStart.SetActive(true);
			this.txtSllBallStart.gameObject.SetActive(true);
			this.ballImageEnd.SetActive(false);
			this.baseScore = 10;
			this.phyMaterial.bounciness = 1f;
		}
	}

	public void ShootBallBySlider()
	{
		if (this.shootBySlider)
		{
			this.lineRenderer1.enabled = true;
			float x = 2f * this.slider.value - 1f;
			float y = (-36f * Mathf.Pow(this.slider.value, 2f) + 36f * this.slider.value + 1f) / 10f;
			this.direction = new Vector2(x, y);
			this.pointDim = Physics2D.Raycast(this.posBallFirst, this.direction, 50f, 65536);
			if (this.pointDim)
			{
				this.lineRenderer1.SetPosition(1, this.pointDim.point);
				Vector2 normalized = Vector2.Reflect(this.pointDim.point - this.posBallFirst, this.pointDim.normal).normalized;
				this.lineRenderer2.SetPosition(0, this.pointDim.point);
				this.lineRenderer2.SetPosition(1, normalized + this.pointDim.point);
				this.ballDim.transform.position = this.pointDim.point;
			}
			else
			{
				this.endLine = this.posBallFirst + this.direction * 50f;
				this.lineRenderer1.SetPosition(1, this.endLine);
			}
		}
	}

	public void OnPointerUp()
	{
		if (this.shootBySlider)
		{
			BallControll.ballEnd = 0;
			BallControll.ballEndShow = 0;
			this.lineRenderer1.enabled = false;
			this.lineRenderer2.enabled = false;
			this.endTurn = false;
			this.shootBySlider = false;
			this.groupBallComeBack.SetActive(true);
			this.groupShootBall.SetActive(false);
			this.txtSllBallStart.gameObject.SetActive(false);
			this.dangreous.SetActive(false);
			base.StartCoroutine(this.Duplicated());
			this.ballEnd = false;
			this.shotBall = true;
			this.ballShooted = 0;
			this.totalBallNow = GameControll.totalBall;
			this.posSpawnBall = this.posBallFirst;
			this.previousTime = Time.time;
			this.ballDim.SetActive(false);
			base.StartCoroutine(this.ShootBall());
		}
	}

	private IEnumerator Duplicated()
	{
		yield return new WaitForSeconds(5f);
		if (!this.ballEnd)
		{
			if (GameControll.eventX2 != null)
			{
				GameControll.eventX2();
			}
			this.x2.SetActive(true);
		}
		BallControll.duplicate = 2;
		base.StartCoroutine(this.Duplicated2());
		yield break;
	}

	private IEnumerator Duplicated2()
	{
		yield return new WaitForSeconds(7f);
		if (!this.ballEnd)
		{
			if (GameControll.eventX2 != null)
			{
				GameControll.eventX2();
			}
			this.x2.SetActive(true);
		}
		BallControll.duplicate = 4;
		yield break;
	}

	public void SetPosBallFirst(Vector2 pos)
	{
		this.posBallFirst = pos;
		this.ballImageEnd.transform.position = pos;
		this.ballImageEnd.SetActive(true);
	}

	public void SetTextBall()
	{
		this.txtSllBallEnd.text = "x" + BallControll.ballEndShow.ToString();
	}

	public void SkipAds()
	{
		ControlEndgame.win = false;
		this.panelEndgame.SetActive(true);
		this.dangreous.SetActive(false);
	}

	private IEnumerator ObjectMoveUp()
	{
		//@TODO
		Vector2 target = this.ObjectPooling.position + 4f * (Vector3)this.vectorUnit;
		yield return new WaitForSeconds(0.5f);
		//while (this.ObjectPooling.position != target)
		while(!this.ObjectPooling.position.Equals(target))
		{
			this.ObjectPooling.position = Vector2.MoveTowards(this.ObjectPooling.position, target, 4.5f * Time.deltaTime);
			//if (this.ObjectPooling.position == target)
			if(this.ObjectPooling.position.Equals(target))
			{
				this.slMoveNext -= 4;
				if (this.loaded >= 81)
				{
					this.loaded -= 27;
				}
				this.dangreous.transform.parent.gameObject.SetActive(true);
				PlayerPrefs.SetInt("j", 1);
				this.SaveGame();
			}
			yield return null;
		}
		yield break;
	}

	public void FinishAds()
	{
		this.panelEndgame.SetActive(false);
		this.panelContinue.SetActive(false);
		this.dangreous.SetActive(false);
		this.shotBall = false;
		CheckGameEndFail.checkWatchedVideos = true;
		BackDeviceGame.status = 0;
		base.StartCoroutine(this.ObjectMoveUp());
	}

	private void LoadDataMap()
	{
		TextAsset textAsset = Resources.Load<TextAsset>("mapdata" + GameControll.levelPlaying.ToString());
		this.valueData = textAsset.text.Split(new char[]
		{
			'.'
		});
		this.GetDataKeys();
		this.GetDataValues();
	}

	private void LoadDataMapPlaying()
	{
		this.valueData[0] = PlayerPrefs.GetString("h").ToString();
		this.valueData[1] = PlayerPrefs.GetString("i").ToString();
		this.GetDataKeys();
		this.GetDataValues();
	}

	private void GetDataKeys()
	{
		this.keys.Clear();
		GameControll.keysDim.Clear();
		this.totalBricks = 0;
		string[] array = this.valueData[0].Split(new char[]
		{
			','
		});
		for (int i = array.Length - 1; i >= 0; i--)
		{
			int num = -10;
			bool flag = int.TryParse(array[i].ToString(), out num);
			if (flag)
			{
				if (num != 0)
				{
					this.totalBricks++;
				}
				this.keys.Add(num);
			}
		}
		GameControll.keysDim = this.keys;
	}

	private void GetDataValues()
	{
		this.values.Clear();
		GameControll.valuesDim.Clear();
		string[] array = this.valueData[1].Split(new char[]
		{
			','
		});
		for (int i = array.Length - 1; i >= 0; i--)
		{
			int num = -10;
			bool flag = int.TryParse(array[i].ToString(), out num);
			if (flag)
			{
				this.values.Add(num);
			}
		}
		GameControll.valuesDim = this.values;
	}

	private void GetPositionSpawnItem()
	{
		for (int i = 0; i < 9; i++)
		{
			for (int j = 0; j > -9; j--)
			{
				Vector2 vector = new Vector3(this.Xstart + (float)j * (1f + this.Xspace), this.Ystart + (float)i * (1f + this.Yspace));
				this.posSpawnItem.Add(vector);
			}
		}
	}
	public List<Item> lsItem;
	public GameObject thunderIcon;
	public GameObject addBallIcon;
	public Transform transformThunder;
	public bool wasUseAddBall = false;
	public Image addBall;
	public Text tvThunder;
	public Text tvAddBall;
	public void BoosterThunder()
    {
		if(UseProfile.ThunderBooster > 0)
        {
			UseProfile.ThunderBooster -= 1;
			   var temp = Instantiate(thunderIcon, transformThunder.position, Quaternion.identity);
			temp.transform.parent = transformThunder.transform;
			temp.transform.localScale = new Vector3(1, 1, 0);
			temp.transform.DOMove(Vector3.zero, 0.4f).OnComplete(delegate {
				HandleBoosterThunder();
				temp.gameObject.SetActive(false);
				ControlSound.instance.PlaySoundLazer();
			});

		}		
		else
        {
			//ShopBox.Setup().Show();
			SuggetBox.Setup(GiftType.ThunderBooster).Show();
        }
	


	}
	private void HandleBoosterThunder()
    {
		foreach (var item in lsItem)
		{
			if (item != null && item.gameObject.activeSelf)
			{
				var ran = UnityEngine.Random.RandomRange(10, 20);
				item.HandleBoosterThunder(ran);
				CheckEndGame();
			}
		}

		void CheckEndGame()
		{
			var endgame = true;
			foreach (var item in lsItem)
			{
				if (item != null && item.gameObject.activeSelf)
				{
					endgame = false;
				}
			}
			if (endgame)
			{
				ControlEndgame.win = true;
				panelEndgame.SetActive(true);
			}
		}
	}

	public void BoosterAddBall()
    {
		if (UseProfile.AddBallsBooster > 0)
		{
			UseProfile.AddBallsBooster -= 1;
			if (!wasUseAddBall)
			{
				wasUseAddBall = true;
				var temp = Instantiate(addBallIcon, transformThunder.position, Quaternion.identity);
				temp.transform.parent = transformThunder.transform;
				temp.transform.localScale = new Vector3(1, 1, 0);
				temp.transform.DOMove(Vector3.zero, 0.4f).OnComplete(delegate {
					HandleBoosterAddBall();
					temp.gameObject.SetActive(false);
					ControlSound.instance.PlaySoundLazer();
				});
			}
		}
		else
        {
			SuggetBox.Setup(GiftType.ThunderBooster).Show();
		}
		
	}

	private void HandleBoosterAddBall()
    {
		
			totalBall += 50;
			BallControll.ballEndShow += 50;
			this.txtSllBallStart.text = "x" + GameControll.totalBall.ToString();
		addBall.color = new Color32(255,255,255,150);
			ControlSound.instance.PlaySoundLazer();
		

	}

	public void ChangeText(object param)
    {
		tvAddBall.text = "" + UseProfile.AddBallsBooster;
		tvThunder.text = "" + UseProfile.ThunderBooster;
	}
	private void SpawnItemFirst()
	{
		if (this.keys.Count >= 81)
		{
			this.loaded = 81;
			for (int i = 0; i < 81; i++)
			{
				switch (this.keys[i])
				{
				case 1:
				{
					GameObject pooledObject = ObjectPoolerManager.Instance.squarePooler.GetPooledObject();
					pooledObject.transform.position = this.posSpawnItem[i];
					pooledObject.GetComponent<Item>().value = this.values[i];
					pooledObject.GetComponent<Item>().stt = i;
					pooledObject.SetActive(true);
					lsItem.Add(pooledObject.GetComponent<Item>());
					break;
				}
				case 2:
				{
					GameObject pooledObject2 = ObjectPoolerManager.Instance.squarePooler.GetPooledObject();
					pooledObject2.transform.position = this.posSpawnItem[i];
					pooledObject2.GetComponent<Item>().value = this.values[i] * 2;
					pooledObject2.GetComponent<Item>().stt = i;
					pooledObject2.SetActive(true);
                    	lsItem.Add(pooledObject2.GetComponent<Item>());
					break;
				}
				case 3:
				{
					GameObject pooledObject3 = ObjectPoolerManager.Instance.triangleBottomLeftPooler.GetPooledObject();
					pooledObject3.transform.position = this.posSpawnItem[i];
					pooledObject3.GetComponent<Item>().value = this.values[i];
					pooledObject3.GetComponent<Item>().stt = i;
					pooledObject3.SetActive(true);
							lsItem.Add(pooledObject3.GetComponent<Item>());
							break;
				}
				case 4:
				{
					GameObject pooledObject4 = ObjectPoolerManager.Instance.triagleBottomRightPooler.GetPooledObject();
					pooledObject4.transform.position = this.posSpawnItem[i];
					pooledObject4.GetComponent<Item>().value = this.values[i];
					pooledObject4.GetComponent<Item>().stt = i;
					pooledObject4.SetActive(true);
							lsItem.Add(pooledObject4.GetComponent<Item>());
							break;
				}
				case 5:
				{
					GameObject pooledObject5 = ObjectPoolerManager.Instance.triagleTopRightPooler.GetPooledObject();
					pooledObject5.transform.position = this.posSpawnItem[i];
					pooledObject5.GetComponent<Item>().value = this.values[i];
					pooledObject5.GetComponent<Item>().stt = i;
					pooledObject5.SetActive(true);
							lsItem.Add(pooledObject5.GetComponent<Item>());
							break;
				}
				case 6:
				{
					GameObject pooledObject6 = ObjectPoolerManager.Instance.triagleTopLeftPooler.GetPooledObject();
					pooledObject6.transform.position = this.posSpawnItem[i];
					pooledObject6.GetComponent<Item>().value = this.values[i];
					pooledObject6.GetComponent<Item>().stt = i;
					pooledObject6.SetActive(true);
							lsItem.Add(pooledObject6.GetComponent<Item>());
							break;
				}
				case 7:
				{
					GameObject pooledObject7 = ObjectPoolerManager.Instance.squareHorizontalBomPooler.GetPooledObject();
					pooledObject7.transform.position = this.posSpawnItem[i];
					pooledObject7.GetComponent<Item>().value = this.values[i];
					pooledObject7.GetComponent<Item>().stt = i;
					pooledObject7.SetActive(true);
							lsItem.Add(pooledObject7.GetComponent<Item>());
							break;
				}
				case 8:
				{
					GameObject pooledObject8 = ObjectPoolerManager.Instance.squareVerticalBomPooler.GetPooledObject();
					pooledObject8.transform.position = this.posSpawnItem[i];
					pooledObject8.GetComponent<Item>().value = this.values[i];
					pooledObject8.GetComponent<Item>().stt = i;
					pooledObject8.SetActive(true);
							lsItem.Add(pooledObject8.GetComponent<Item>());
							break;
				}
				case 9:
				{
					GameObject pooledObject9 = ObjectPoolerManager.Instance.squareCrossBomPooler.GetPooledObject();
					pooledObject9.transform.position = this.posSpawnItem[i];
					pooledObject9.GetComponent<Item>().value = this.values[i];
					pooledObject9.GetComponent<Item>().stt = i;
					pooledObject9.SetActive(true);
							lsItem.Add(pooledObject9.GetComponent<Item>());
							break;
				}
				case 10:
				{
					GameObject pooledObject10 = ObjectPoolerManager.Instance.squareSquareBomPooler.GetPooledObject();
					pooledObject10.transform.position = this.posSpawnItem[i];
					pooledObject10.GetComponent<Item>().value = this.values[i];
					pooledObject10.GetComponent<Item>().stt = i;
					pooledObject10.SetActive(true);
							lsItem.Add(pooledObject10.GetComponent<Item>());
							break;
				}
				case 18:
				{
					GameObject pooledObject11 = ObjectPoolerManager.Instance.laserHorizontalPooler.GetPooledObject();
					pooledObject11.transform.position = this.posSpawnItem[i];
					pooledObject11.GetComponent<ItemLaser>().stt = i;
					pooledObject11.SetActive(true);
							lsItem.Add(pooledObject11.GetComponent<Item>());
							break;
				}
				case 19:
				{
					GameObject pooledObject12 = ObjectPoolerManager.Instance.laserVerticalPooler.GetPooledObject();
					pooledObject12.transform.position = this.posSpawnItem[i];
					pooledObject12.GetComponent<ItemLaser>().stt = i;
					pooledObject12.SetActive(true);
							lsItem.Add(pooledObject12.GetComponent<Item>());
							break;
				}
				case 20:
				{
					GameObject pooledObject13 = ObjectPoolerManager.Instance.laserCrossPooler.GetPooledObject();
					pooledObject13.transform.position = this.posSpawnItem[i];
					pooledObject13.GetComponent<ItemLaser>().stt = i;
					pooledObject13.SetActive(true);
							lsItem.Add(pooledObject13.GetComponent<Item>());
							break;
				}
				case 21:
				{
					GameObject pooledObject14 = ObjectPoolerManager.Instance.plusBallPooler.GetPooledObject();
					pooledObject14.transform.position = this.posSpawnItem[i];
					pooledObject14.GetComponent<ItemPlusBall>().stt = i;
					pooledObject14.SetActive(true);
							lsItem.Add(pooledObject14.GetComponent<Item>());
							break;
				}
				case 24:
				{
					GameObject pooledObject15 = ObjectPoolerManager.Instance.xoayPooler.GetPooledObject();
					pooledObject15.transform.position = this.posSpawnItem[i];
					pooledObject15.GetComponent<ItemXoay>().stt = i;
					pooledObject15.SetActive(true);
							lsItem.Add(pooledObject15.GetComponent<Item>());
							break;
				}
				}
			}
		}
		else
		{
			this.loaded = this.keys.Count;
			for (int j = 0; j < this.keys.Count; j++)
			{
				switch (this.keys[j])
				{
				case 1:
				{
					GameObject pooledObject16 = ObjectPoolerManager.Instance.squarePooler.GetPooledObject();
					pooledObject16.transform.position = this.posSpawnItem[j];
					pooledObject16.GetComponent<Item>().value = this.values[j];
					pooledObject16.GetComponent<Item>().stt = j;
					pooledObject16.SetActive(true);
							lsItem.Add(pooledObject16.GetComponent<Item>());
							break;
				}
				case 2:
				{
					GameObject pooledObject17 = ObjectPoolerManager.Instance.squarePooler.GetPooledObject();
					pooledObject17.transform.position = this.posSpawnItem[j];
					pooledObject17.GetComponent<Item>().value = this.values[j] * 2;
					pooledObject17.GetComponent<Item>().stt = j;
					pooledObject17.SetActive(true);
							lsItem.Add(pooledObject17.GetComponent<Item>());
							break;
				}
				case 3:
				{
					GameObject pooledObject18 = ObjectPoolerManager.Instance.triangleBottomLeftPooler.GetPooledObject();
					pooledObject18.transform.position = this.posSpawnItem[j];
					pooledObject18.GetComponent<Item>().value = this.values[j];
					pooledObject18.GetComponent<Item>().stt = j;
					pooledObject18.SetActive(true);
							lsItem.Add(pooledObject18.GetComponent<Item>());
							break;
				}
				case 4:
				{
					GameObject pooledObject19 = ObjectPoolerManager.Instance.triagleBottomRightPooler.GetPooledObject();
					pooledObject19.transform.position = this.posSpawnItem[j];
					pooledObject19.GetComponent<Item>().value = this.values[j];
					pooledObject19.GetComponent<Item>().stt = j;
					pooledObject19.SetActive(true);
							lsItem.Add(pooledObject19.GetComponent<Item>());
							break;
				}
				case 5:
				{
					GameObject pooledObject20 = ObjectPoolerManager.Instance.triagleTopRightPooler.GetPooledObject();
					pooledObject20.transform.position = this.posSpawnItem[j];
					pooledObject20.GetComponent<Item>().value = this.values[j];
					pooledObject20.GetComponent<Item>().stt = j;
					pooledObject20.SetActive(true);
							lsItem.Add(pooledObject20.GetComponent<Item>());
							break;
				}
				case 6:
				{
					GameObject pooledObject21 = ObjectPoolerManager.Instance.triagleTopLeftPooler.GetPooledObject();
					pooledObject21.transform.position = this.posSpawnItem[j];
					pooledObject21.GetComponent<Item>().value = this.values[j];
					pooledObject21.GetComponent<Item>().stt = j;
					pooledObject21.SetActive(true);
							lsItem.Add(pooledObject21.GetComponent<Item>());
							break;
				}
				case 7:
				{
					GameObject pooledObject22 = ObjectPoolerManager.Instance.squareHorizontalBomPooler.GetPooledObject();
					pooledObject22.transform.position = this.posSpawnItem[j];
					pooledObject22.GetComponent<Item>().value = this.values[j];
					pooledObject22.GetComponent<Item>().stt = j;
					pooledObject22.SetActive(true);
							lsItem.Add(pooledObject22.GetComponent<Item>());
							break;
				}
				case 8:
				{
					GameObject pooledObject23 = ObjectPoolerManager.Instance.squareVerticalBomPooler.GetPooledObject();
					pooledObject23.transform.position = this.posSpawnItem[j];
					pooledObject23.GetComponent<Item>().value = this.values[j];
					pooledObject23.GetComponent<Item>().stt = j;
					pooledObject23.SetActive(true);
							lsItem.Add(pooledObject23.GetComponent<Item>());
							break;
				}
				case 9:
				{
					GameObject pooledObject24 = ObjectPoolerManager.Instance.squareCrossBomPooler.GetPooledObject();
					pooledObject24.transform.position = this.posSpawnItem[j];
					pooledObject24.GetComponent<Item>().value = this.values[j];
					pooledObject24.GetComponent<Item>().stt = j;
					pooledObject24.SetActive(true);
							lsItem.Add(pooledObject24.GetComponent<Item>());
							break;
				}
				case 10:
				{
					GameObject pooledObject25 = ObjectPoolerManager.Instance.squareSquareBomPooler.GetPooledObject();
					pooledObject25.transform.position = this.posSpawnItem[j];
					pooledObject25.GetComponent<Item>().value = this.values[j];
					pooledObject25.GetComponent<Item>().stt = j;
					pooledObject25.SetActive(true);
							lsItem.Add(pooledObject25.GetComponent<Item>());
							break;
				}
				case 18:
				{
					GameObject pooledObject26 = ObjectPoolerManager.Instance.laserHorizontalPooler.GetPooledObject();
					pooledObject26.transform.position = this.posSpawnItem[j];
					pooledObject26.GetComponent<ItemLaser>().stt = j;
					pooledObject26.SetActive(true);
							lsItem.Add(pooledObject26.GetComponent<Item>());
							break;
				}
				case 19:
				{
					GameObject pooledObject27 = ObjectPoolerManager.Instance.laserVerticalPooler.GetPooledObject();
					pooledObject27.transform.position = this.posSpawnItem[j];
					pooledObject27.GetComponent<ItemLaser>().stt = j;
					pooledObject27.SetActive(true);
							lsItem.Add(pooledObject27.GetComponent<Item>());
							break;
				}
				case 20:
				{
					GameObject pooledObject28 = ObjectPoolerManager.Instance.laserCrossPooler.GetPooledObject();
					pooledObject28.transform.position = this.posSpawnItem[j];
					pooledObject28.GetComponent<ItemLaser>().stt = j;
					pooledObject28.SetActive(true);
							lsItem.Add(pooledObject28.GetComponent<Item>());
							break;
				}
				case 21:
				{
					GameObject pooledObject29 = ObjectPoolerManager.Instance.plusBallPooler.GetPooledObject();
					pooledObject29.transform.position = this.posSpawnItem[j];
					pooledObject29.GetComponent<ItemPlusBall>().stt = j;
					pooledObject29.SetActive(true);
							lsItem.Add(pooledObject29.GetComponent<Item>());
							break;
				}
				case 24:
				{
					GameObject pooledObject30 = ObjectPoolerManager.Instance.xoayPooler.GetPooledObject();
					pooledObject30.transform.position = this.posSpawnItem[j];
					pooledObject30.GetComponent<ItemXoay>().stt = j;
					pooledObject30.SetActive(true);
							lsItem.Add(pooledObject30.GetComponent<Item>());
							break;
				}
				}
			}
		}
	}

	public void EndTurn()
	{
		this.groupBallComeBack.SetActive(false);
		this.groupShootBall.SetActive(true);
		this.ballEnd = true;
		this.slider.value = 0.5f;
		base.StopAllCoroutines();
		base.StartCoroutine(this.EndTurnWait());
	}

	private void CheckKeys()
	{
		this.checkKey = false;
		for (int i = 0; i < GameControll.keysDim.Count; i++)
		{
			switch (GameControll.keysDim[i])
			{
			case 1:
				this.checkKey = true;
				break;
			case 2:
				this.checkKey = true;
				break;
			case 3:
				this.checkKey = true;
				break;
			case 4:
				this.checkKey = true;
				break;
			case 5:
				this.checkKey = true;
				break;
			case 6:
				this.checkKey = true;
				break;
			case 7:
				this.checkKey = true;
				break;
			case 8:
				this.checkKey = true;
				break;
			case 9:
				this.checkKey = true;
				break;
			case 10:
				this.checkKey = true;
				break;
			}
		}
	}

	public IEnumerator EndTurnWait()
	{
		this.hits = Physics2D.BoxCastAll(base.transform.position, this.boxCheckAll.size, 0f, Vector2.zero, 0f, 1024);
		if (this.hits.Length == 0)
		{
			this.CheckKeys();
			if (this.checkKey)
			{
				base.StartCoroutine(this.MoveNext());
			}
			else
			{
				if (GameControll.levelPlaying >= PlayerPrefs.GetInt("b"))
				{
					PlayerPrefs.SetInt("b", GameControll.levelPlaying + 1);
				}
				PlayerPrefs.SetInt("j", 0);
				ControlEndgame.win = true;
				BackDeviceGame.status = 10;

           
                yield return new WaitForSeconds(0.3f);
                this.panelEndgame.SetActive(true);

                //if (this.placementIntersAds == GameControll.PlacementIntersAds.BEFORE)
                //{
                //	SG_AdManager.ads.ShowIntertitial();
                //	yield return new WaitForSeconds(0.3f);
                //	this.panelEndgame.SetActive(true);
                //}
                //else
                //{
                //	this.panelEndgame.SetActive(true);
                //}
            }
		}
		else
		{
			base.StartCoroutine(this.MoveNext());
		}
		yield break;
	}

	private IEnumerator MoveNext()
	{
		//@TODO
		Vector2 target = this.ObjectPooling.position - (Vector3)this.vectorUnit;
		yield return new WaitForSeconds(0.3f);
		while (this.ObjectPooling.position != (Vector3)target)
		{
			this.ObjectPooling.position = Vector2.MoveTowards(this.ObjectPooling.position, target, 3f * Time.deltaTime);
			yield return null;
		}
		if (this.ObjectPooling.position == (Vector3)target)
		{
			this.slMoveNext++;
			this.endTurn = true;
			if (this.loaded < this.keys.Count)
			{
				int num = this.loaded + 9;
				if (num > this.keys.Count)
				{
					num = this.keys.Count;
				}
				int num2 = 72;
				for (int i = this.loaded; i < num; i++)
				{
					switch (this.keys[i])
					{
					case 1:
					{
						GameObject pooledObject = ObjectPoolerManager.Instance.squarePooler.GetPooledObject();
						pooledObject.transform.position = this.posSpawnItem[num2];
						pooledObject.GetComponent<Item>().value = this.values[i];
						pooledObject.GetComponent<Item>().stt = i;
						pooledObject.SetActive(true);
						break;
					}
					case 2:
					{
						GameObject pooledObject2 = ObjectPoolerManager.Instance.squarePooler.GetPooledObject();
						pooledObject2.transform.position = this.posSpawnItem[num2];
						pooledObject2.GetComponent<Item>().value = this.values[i] * 2;
						pooledObject2.GetComponent<Item>().stt = i;
						pooledObject2.SetActive(true);
						break;
					}
					case 3:
					{
						GameObject pooledObject3 = ObjectPoolerManager.Instance.triangleBottomLeftPooler.GetPooledObject();
						pooledObject3.transform.position = this.posSpawnItem[num2];
						pooledObject3.GetComponent<Item>().value = this.values[i];
						pooledObject3.GetComponent<Item>().stt = i;
						pooledObject3.SetActive(true);
						break;
					}
					case 4:
					{
						GameObject pooledObject4 = ObjectPoolerManager.Instance.triagleBottomRightPooler.GetPooledObject();
						pooledObject4.transform.position = this.posSpawnItem[num2];
						pooledObject4.GetComponent<Item>().value = this.values[i];
						pooledObject4.GetComponent<Item>().stt = i;
						pooledObject4.SetActive(true);
						break;
					}
					case 5:
					{
						GameObject pooledObject5 = ObjectPoolerManager.Instance.triagleTopRightPooler.GetPooledObject();
						pooledObject5.transform.position = this.posSpawnItem[num2];
						pooledObject5.GetComponent<Item>().value = this.values[i];
						pooledObject5.GetComponent<Item>().stt = i;
						pooledObject5.SetActive(true);
						break;
					}
					case 6:
					{
						GameObject pooledObject6 = ObjectPoolerManager.Instance.triagleTopLeftPooler.GetPooledObject();
						pooledObject6.transform.position = this.posSpawnItem[num2];
						pooledObject6.GetComponent<Item>().value = this.values[i];
						pooledObject6.GetComponent<Item>().stt = i;
						pooledObject6.SetActive(true);
						break;
					}
					case 7:
					{
						GameObject pooledObject7 = ObjectPoolerManager.Instance.squareHorizontalBomPooler.GetPooledObject();
						pooledObject7.transform.position = this.posSpawnItem[num2];
						pooledObject7.GetComponent<Item>().value = this.values[i];
						pooledObject7.GetComponent<Item>().stt = i;
						pooledObject7.SetActive(true);
						break;
					}
					case 8:
					{
						GameObject pooledObject8 = ObjectPoolerManager.Instance.squareVerticalBomPooler.GetPooledObject();
						pooledObject8.transform.position = this.posSpawnItem[num2];
						pooledObject8.GetComponent<Item>().value = this.values[i];
						pooledObject8.GetComponent<Item>().stt = i;
						pooledObject8.SetActive(true);
						break;
					}
					case 9:
					{
						GameObject pooledObject9 = ObjectPoolerManager.Instance.squareCrossBomPooler.GetPooledObject();
						pooledObject9.transform.position = this.posSpawnItem[num2];
						pooledObject9.GetComponent<Item>().value = this.values[i];
						pooledObject9.GetComponent<Item>().stt = i;
						pooledObject9.SetActive(true);
						break;
					}
					case 10:
					{
						GameObject pooledObject10 = ObjectPoolerManager.Instance.squareSquareBomPooler.GetPooledObject();
						pooledObject10.transform.position = this.posSpawnItem[num2];
						pooledObject10.GetComponent<Item>().value = this.values[i];
						pooledObject10.GetComponent<Item>().stt = i;
						pooledObject10.SetActive(true);
						break;
					}
					case 18:
					{
						GameObject pooledObject11 = ObjectPoolerManager.Instance.laserHorizontalPooler.GetPooledObject();
						pooledObject11.transform.position = this.posSpawnItem[num2];
						pooledObject11.GetComponent<ItemLaser>().stt = i;
						pooledObject11.SetActive(true);
						break;
					}
					case 19:
					{
						GameObject pooledObject12 = ObjectPoolerManager.Instance.laserVerticalPooler.GetPooledObject();
						pooledObject12.transform.position = this.posSpawnItem[num2];
						pooledObject12.GetComponent<ItemLaser>().stt = i;
						pooledObject12.SetActive(true);
						break;
					}
					case 20:
					{
						GameObject pooledObject13 = ObjectPoolerManager.Instance.laserCrossPooler.GetPooledObject();
						pooledObject13.transform.position = this.posSpawnItem[num2];
						pooledObject13.GetComponent<ItemLaser>().stt = i;
						pooledObject13.SetActive(true);
						break;
					}
					case 21:
					{
						GameObject pooledObject14 = ObjectPoolerManager.Instance.plusBallPooler.GetPooledObject();
						pooledObject14.transform.position = this.posSpawnItem[num2];
						pooledObject14.GetComponent<ItemPlusBall>().stt = i;
						pooledObject14.SetActive(true);
						break;
					}
					case 24:
					{
						GameObject pooledObject15 = ObjectPoolerManager.Instance.xoayPooler.GetPooledObject();
						pooledObject15.transform.position = this.posSpawnItem[num2];
						pooledObject15.GetComponent<ItemXoay>().stt = i;
						pooledObject15.SetActive(true);
						break;
					}
					}
					num2++;
				}
				this.loaded = num;
			}
			this.SaveGame();
			this.hits = Physics2D.BoxCastAll(base.transform.position, this.boxCheckAll.size, 0f, Vector2.zero, 0f, 1024);
			if (this.hits.Length == 0)
			{
				this.CheckKeys();
				if (this.checkKey)
				{
					base.StartCoroutine(this.MoveNext());
				}
				else
				{
					if (GameControll.levelPlaying >= PlayerPrefs.GetInt("b"))
					{
						PlayerPrefs.SetInt("b", GameControll.levelPlaying + 1);
					}
					PlayerPrefs.SetInt("j", 0);
					ControlEndgame.win = true;
					BackDeviceGame.status = 10;
					if (this.placementIntersAds == GameControll.PlacementIntersAds.BEFORE)
					{
						//SG_AdManager.ads.ShowIntertitial();
						yield return new WaitForSeconds(0.3f);
						this.panelEndgame.SetActive(true);
					}
					else
					{
						this.panelEndgame.SetActive(true);
					}
				}
			}
		}
		yield break;
	}

	public void ButtonPause()
	{
		
		ControlSound.instance.PlaySoundButton();
		BackDeviceGame.status = 2;
		this.hits = Physics2D.BoxCastAll(base.transform.position, this.boxCheckAll.size, 0f, Vector2.zero, 0f, 1024);
		if (this.hits.Length == 0)
		{
			this.CheckKeys();
			if (!this.checkKey)
			{
				if (GameControll.levelPlaying >= PlayerPrefs.GetInt("b"))
				{
					PlayerPrefs.SetInt("b", GameControll.levelPlaying + 1);
				}
				PlayerPrefs.SetInt("j", 0);
				ControlEndgame.SetEndGame();
			}
		}
		this.panelPause.SetActive(true);
		Time.timeScale = 0f;
	}

	public void ButtonBallComeBack()
	{
		ControlSound.instance.PlaySoundButton();
		this.shotBall = false;
		this.ballImageEnd.transform.position = BallControll.posEnd;
		this.ballImageEnd.SetActive(true);
		this.txtSllBallEnd.gameObject.SetActive(true);
		this.ballImageStart.SetActive(false);
		base.StopAllCoroutines();
		if (GameControll.eventBallComeBack != null)
		{
			GameControll.eventBallComeBack();
		}
		base.StartCoroutine(BallControll.CheckEndTurn());
	}

	public static GameControll instane;

	public GameControll.PlacementIntersAds placementIntersAds;

	public GameObject tutorial;

	public GameObject panelContinue;

	public GameObject ballDim;

	public GameObject x2;

	public GameObject dangreous;

	public Text txtScore;

	public PhysicsMaterial2D phyMaterial;

	public EffectStar effectStar1;

	public EffectStar effectStar2;

	public EffectStar effectStar3;

	public Image imgRunStar;

	public GameObject panelEndgame;

	public BoxCollider2D boxCheckAll;

	public Text txtStage;

	public GameObject groupShootBall;

	public GameObject groupBallComeBack;

	public GameObject panelPause;

	public float Xspace;

	public float Yspace;

	public float Xstart;

	public float Ystart;

	public GameObject item;

	public LineRenderer lineRenderer1;

	public LineRenderer lineRenderer2;

	public LayerMask layerWall;

	public GameObject ballImageStart;

	public GameObject ballImageEnd;

	public TextMesh txtSllBallStart;

	public TextMesh txtSllBallEnd;

	[HideInInspector]
	public Vector2 posBallFirst;

	public static int totalBall;

	[HideInInspector]
	public int totalBallNow;

	[HideInInspector]
	public bool endTurn;

	public Slider slider;

	public static int levelPlaying;

	public static List<int> startBalls = new List<int>();

	public static List<int> keysDim = new List<int>();

	public static List<int> valuesDim = new List<int>();

	private string[] valueData = new string[2];

	private List<int> keys = new List<int>();

	private List<int> values = new List<int>();

	private List<Vector2> posSpawnItem = new List<Vector2>();

	private Vector2 posHand;

	private Vector2 direction;

	private Vector2 directionOut;

	private Vector2 endLine;

	private Vector2 vectorUnit;

	private bool down;

	private int loaded;

	private bool shootBySlider;

	private Vector2 posSpawnBall;

	public Transform ObjectPooling;

	private int baseScore;

	[HideInInspector]
	public int score;

	private int maxScore;

	private int totalBricks;

	[HideInInspector]
	public int star;

	private float ratioScore;

	[HideInInspector]
	public bool ballEnd;

	[HideInInspector]
	public bool shotBall;

	[HideInInspector]
	public int ballShooted;

	private float previousTime;

	private RaycastHit2D pointDim;

	private static bool firstLoaded;

	public static bool finishAdsVideo;

	private RaycastHit2D[] hits;

	private bool checkKey;

	private int slMoveNext;

	private string strKey;

	private string strValue;

	private float setFillAmountOneStar;

	public enum PlacementIntersAds
	{
		BEFORE,
		AFTER
	}
}

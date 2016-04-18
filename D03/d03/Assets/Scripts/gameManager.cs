using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameManager : MonoBehaviour {

	public int delayBetweenWaves = 10;					//Temps entre les vagues
	public int nextWaveEnnemyHpUp = 20; 				//Augmentation de la vie des bots a chaque vague (en %)
	public int nextWaveEnnemyValueUp = 30; 		//Augmentation de l'energie donnee par les bots a chaque vague (en %)
	public int averageWavesLenght = 15;					//Taille moyenne d'une vague d'ennemis
	public int totalWavesNumber = 20;						// Nombre des vagues au total
	[HideInInspector]public bool lastWave = false;
	[HideInInspector]public int currentWave = 1;
	private float tmpTimeScale = 1;
	public GameObject panel;
	public bool pauseBool; //[pause
	public Texture2D textureMouse; // mouse
	public Text      scoreText;
	public Text      rangText;
	public int 		playerMaxHp = 20;
	private int 	_playerHp;
	
	
	public GameObject[] towerInfos = new GameObject[3];
	public towerScript[] towerPrefabs = new towerScript[3];
	public GameObject TextPrefab;
	public Text lifeText;
	public Text energyText;
	
	[HideInInspector]public int score = 0;
	
	
	public static gameManager gm;

	public int playerStartEnergy = 300;
	private int _playerEnergy;
	[HideInInspector]public int playerEnergy { 
		get { return _playerEnergy; } 
		set{ 
			_playerEnergy = value;
			energyText.text =  "Energy : " + playerEnergy.ToString ();
		}
	}
	
	[HideInInspector]public int playerHp { 
		get { return _playerHp; } 
		set{ 
			if (value < 0)
				value = 0;
			_playerHp = value;
			lifeText.text =  "Life : " + _playerHp.ToString ();
		}
	}

	public void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			pause (true);
			GameObject.Find("pause").GetComponent<CanvasGroup>().alpha = 1;
			GameObject.Find ("Panel").GetComponent<CanvasGroup> ().blocksRaycasts = false;
			GameObject.Find ("pause").GetComponent<CanvasGroup> ().blocksRaycasts = true;
		}
	}
	
	//Singleton basique  : Voir unity design patterns sur google.
	void Awake () {
		if (gm == null)
			gm = this;
	}
	
	public void Start() {
		GameObject.Find ("loadScene2").GetComponent<CanvasGroup> ().blocksRaycasts = false;
		GameObject.Find ("score").GetComponent<CanvasGroup> ().blocksRaycasts = false;
		Cursor.SetCursor (textureMouse, new Vector2 (0, 0), CursorMode.Auto);
		pauseBool = false;
		GameObject.Find ("confirm").GetComponent<CanvasGroup> ().blocksRaycasts = false;
		GameObject.Find ("pause").GetComponent<CanvasGroup> ().blocksRaycasts = false;
		for (int i = 0; i < towerPrefabs.Length; i++) {
			Text[] texts = new Text[4];
			for(int j = 0; j < texts.Length; j++){
				texts[j] = GameObject.Instantiate(TextPrefab).GetComponent<Text>();
				texts[j].transform.SetParent(towerInfos[i].transform, false);
			}
			texts[0].text = "Energy :    " + towerPrefabs[i].energy.ToString();
			texts[1].text = "Fire Rate : " + towerPrefabs[i].fireRate.ToString();
			texts[2].text = "Damage :  " + towerPrefabs[i].damage.ToString();
			texts[3].text = "Range :     " + towerPrefabs[i].range.ToString();
		}
		
		Time.timeScale = 1;
		playerHp = playerMaxHp;
		playerEnergy = playerStartEnergy;
		
	}
	
	//Pour mettre le jeu en pause
	public void pause(bool paused) {
		if (paused == true) {
			tmpTimeScale = Time.timeScale;
			Time.timeScale = 0;
		}
		else
			Time.timeScale = tmpTimeScale;
	}
	
	//Pour changer la vitesse de base du jeu
	public void changeSpeed(float speed) {
		Time.timeScale = speed;
	}
	
	//Le joueur perd de la vie
	public void damagePlayer(int damage) {
		playerHp -= damage;
		if (playerHp <= 0)
			gameOver();
		else
			Debug.Log ("Il reste au joueur " + playerHp + "hp");
		lifeText.text = "Life : " + playerHp.ToString ();
		
	}
	
	//On pause le jeu en cas de game over
	public void gameOver() {
		Time.timeScale = 0;
		endMenu ();
		Debug.Log ("Game Over");
	}

	public string findScore() {

		string final = "noob";
		int scoreDiff = (totalWavesNumber - currentWave) + (playerMaxHp - playerHp);
		if (scoreDiff < 1 && score > 12000) {
			final = "big boss";
		} else if (scoreDiff < 3 && score > 10000) {
			final = "rang S";
		} else if (scoreDiff < 5 && score > 6000) {
			final = "rand A";
		} else if (scoreDiff < 10 && score > 4000) {
			final = "rang B";
		} else if (scoreDiff < 20 && score > 2000) {
			final = "rang C";
		}

		return (final);
	}

	public void endMenu() {
		GameObject.Find ("score").GetComponent<CanvasGroup> ().alpha = 1;
		GameObject.Find ("score").GetComponent<CanvasGroup> ().blocksRaycasts = true;
		GameObject.Find ("Panel").GetComponent<CanvasGroup> ().blocksRaycasts = false;
		rangText.text = findScore();
		scoreText.text = score.ToString();


	}
}
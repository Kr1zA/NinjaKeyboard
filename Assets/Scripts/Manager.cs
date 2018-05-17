using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour
{
	public Camera c;
	public GameObject textForBinding;
	public GameObject lightOnKey;
	public GameObject floor;
	public GameObject charA;
	public GameObject charB;
	public GameObject charC;
	public GameObject charD;
	public GameObject charE;
	public GameObject charF;
	public GameObject charG;
	public GameObject charH;
	public GameObject charI;
	public GameObject charJ;
	public GameObject charK;
	public GameObject charL;
	public GameObject charM;
	public GameObject charN;
	public GameObject charO;
	public GameObject charP;
	public GameObject charQ;
	public GameObject charR;
	public GameObject charS;
	public GameObject charT;
	public GameObject charU;
	public GameObject charV;
	public GameObject charW;
	public GameObject charX;
	public GameObject charY;
	public GameObject charZ;
	public GameObject char0;
	public GameObject char1;
	public GameObject char2;
	public GameObject char3;
	public GameObject char4;
	public GameObject char5;
	public GameObject char6;
	public GameObject char7;
	public GameObject char8;
	public GameObject char9;
	public float AlphaInitialVelocity = 600f;
	public static Manager instance;

	
	public Camera GameCamera {
		get { return c; }
	}
	private GameObject text;
	private static int countOfChars = 36;
	private bool binded = false;
	private int counterChar = 0;
	//private float yOfFloor = 0;

	private System.Random rnd = new System.Random ();

	private KeyCode[] keyCodes = {
		KeyCode.Alpha1,
		KeyCode.Alpha2,
		KeyCode.Alpha3,
		KeyCode.Alpha4,
		KeyCode.Alpha5,
		KeyCode.Alpha6,
		KeyCode.Alpha7,
		KeyCode.Alpha8,
		KeyCode.Alpha9,
		KeyCode.Alpha0,
		KeyCode.Q,
		KeyCode.W,
		KeyCode.E,
		KeyCode.R,
		KeyCode.T,
		KeyCode.Y,
		KeyCode.U,
		KeyCode.I,
		KeyCode.O,
		KeyCode.P,
		KeyCode.A,
		KeyCode.S,
		KeyCode.D,
		KeyCode.F,
		KeyCode.G,
		KeyCode.H,
		KeyCode.J,
		KeyCode.K,
		KeyCode.L,
		KeyCode.Z,
		KeyCode.X,
		KeyCode.C,
		KeyCode.V,
		KeyCode.B,
		KeyCode.N,
		KeyCode.M
	};
	private GameObject[] gameObjects;
	private float[] xOfChars = new float[countOfChars];
	private float[] yOfChars = new float[countOfChars];
	private string[] Chars = {
		"1",
		"2",
		"3",
		"4",
		"5",
		"6",
		"7",
		"8",
		"9",
		"0",
		"q",
		"w",
		"e",
		"r",
		"t",
		"y",
		"u",
		"i",
		"o",
		"p",
		"a",
		"s",
		"d",
		"f",
		"g",
		"h",
		"j",
		"k",
		"l",
		"z",
		"x",
		"c",
		"v",
		"b",
		"n",
		"m" 
	};

	void Start ()
	{
		gameObjects = new GameObject[] {
			char1,
			char2,
			char3,
			char4,
			char5,
			char6,
			char7,
			char8,
			char9,
			char0,
			charQ,
			charW,
			charE,
			charR,
			charT,
			charY,
			charU,
			charI,
			charO,
			charP,
			charA,
			charS,
			charD,
			charF,
			charG,
			charH,
			charJ,
			charK,
			charL,
			charZ,
			charX,
			charC,
			charV,
			charB,
			charN,
			charM
		};
		if (instance != null) {
			Destroy (this.gameObject);
		}
		instance = this;
	}

	private void BindChars ()
	{
		if (counterChar < countOfChars) {
			if (Input.GetButtonDown ("Fire1")) {
				Vector3 mousePosition =	c.ScreenToWorldPoint (Input.mousePosition);
				xOfChars [counterChar] = mousePosition.x;
				yOfChars [counterChar] = mousePosition.y;
				//Debug.Log (mousePosition.x + " " + mousePosition.y);
				counterChar++;
				if (counterChar < countOfChars) {
					//Debug.Log (Chars [counterChar]);
					text.GetComponent<TextMesh> ().text = Chars [counterChar];
				} else {
					//Debug.Log ("Keyboard top");
					text.GetComponent<TextMesh> ().text = "Keyboard top";
				}
			}
		} else {
			if (counterChar == countOfChars) {
				if (Input.GetButtonDown ("Fire1")) {
					Vector3 mousePosition =	c.ScreenToWorldPoint (Input.mousePosition);
					//yOfFloor = mousePosition.y;
					floor.transform.position = new Vector2 (floor.transform.position.x, mousePosition.y);
					counterChar++;
				}
			} else {
				Debug.Log ("End binding");
				Destroy (text.gameObject);
				binded = false;
				counterChar = 0;
			}

		}

	}

	void Update ()
	{
		
		if (Input.anyKey) {

			for (int i = 0; i < gameObjects.Length; i++) {
				if (Input.GetKey (keyCodes [i])) {
					GameObject alpha = Instantiate (gameObjects [i], new Vector2 (xOfChars [i], floor.transform.position.y + 0.6F), transform.rotation) as GameObject;
					alpha.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (rnd.Next (-100, 100), AlphaInitialVelocity + rnd.Next (-100, 100)));
					GameObject light = Instantiate (lightOnKey, new Vector2 (xOfChars [i], yOfChars [i]), transform.rotation) as GameObject; 

				}
			}
		}
		if (Input.anyKeyDown) {
			if (Input.GetKey (KeyCode.LeftShift) && Input.GetKey (KeyCode.LeftControl) && Input.GetKey (KeyCode.LeftArrow))
				floor.transform.localScale += new Vector3 (0.01F, 0.01F, 0.01F);
			
			if (Input.GetKey (KeyCode.LeftShift) && Input.GetKey (KeyCode.LeftControl) && Input.GetKey (KeyCode.RightArrow))
				floor.transform.localScale -= new Vector3 (0.01F, 0.01F, 0.01F);

			if (Input.GetKey (KeyCode.LeftShift) && Input.GetKey (KeyCode.LeftControl) && Input.GetKey (KeyCode.UpArrow)) {
				floor.transform.position += new Vector3 (0, 0.05F, 0);
				//yOfFloor += 0.5F;
			}
			
			if (Input.GetKey (KeyCode.LeftShift) && Input.GetKey (KeyCode.LeftControl) && Input.GetKey (KeyCode.DownArrow)) {
				floor.transform.position -= new Vector3 (0, 0.05F, 0);
				//yOfFloor -= 0.05F;
			}
		}
		if (binded) {
			BindChars ();
		} else {
			if (Input.GetKey (KeyCode.RightShift) && Input.GetKey (KeyCode.End)) {
				Debug.Log ("Begin binding");
				text = Instantiate (textForBinding, new Vector2 (-5F, 4F), transform.rotation) as GameObject;
				text.GetComponent<TextMesh> ().text = "Begin binding";
				binded = true;

			}
		}
	}
}
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerShape : Shape {

    // Shouldn't be changed by code outside this class but is public to allow for setting default value
    public int currentShape;
    public Mesh[] availableShapes;
	public GameObject GameOverUI;
	public AudioSource HitAudio;
	public AudioSource PassAudio;
	public AudioSource shapeChangeSound;
	public Material sphereShape;
	public Material SquareShape;
	public Animator scoreAnim;
	public Text ShapeText;

    private void Start()
    {
		GetComponent<MeshFilter>().mesh = availableShapes[0];
		PlayerPrefs.SetInt ("Lives", 3);
		ShapeText.text = "BE SPHERE";
    }

	void Update ()
	{
		if (PlayerPrefs.GetInt ("Lives") <= 0) 
		{
			GameObject.Find ("Player 1").SetActive (false);
			GameObject.Find ("Player 2").SetActive (false);
			GameObject.Find ("WallSpawner").GetComponent<WallSpawner> ().enabled = false;
		}
	}

    public void nextShape(bool next)
    {
        if (next)
        {
            currentShape++;
        }
        else
        {
            currentShape--;
        }

        if (currentShape >= availableShapes.Length)
        {
            currentShape = 0;
        }
        else if (currentShape < 0)
        {
            currentShape = availableShapes.Length - 1;
        }

        GetComponent<MeshFilter>().mesh = availableShapes[currentShape];

		switch (availableShapes [currentShape].name) {
		case "PlayerCube":
			type = ShapeType.Rectangle;
			shapeChangeSound.Play ();
			GetComponent<MeshRenderer>().material = SquareShape;
			ShapeText.text = "BE SPHERE";
			break;
		case "PlayerSphere":
			type = ShapeType.Circle;
			shapeChangeSound.Play ();
			GetComponent<MeshRenderer>().material = sphereShape;			
			ShapeText.text = "BE CUBE";
			break;
		}
    }

	private bool PlayerInShape(GameObject player, GameObject wall)
	{
		return wall.GetComponent<WallComponent> ().TestOverlapping (player.GetComponent<Shape> ());
	}

	void OnTriggerEnter(Collider collider)
	{
		///
		///// Collision with Wall
		///
		if (collider.tag == "Wall")
		{
			if (!PlayerInShape(gameObject, collider.gameObject))
			{
				if (HitAudio.isPlaying == false)
				{
					HitAudio.Play ();
				}
				PlayerPrefs.SetInt ("Lives", PlayerPrefs.GetInt ("Lives") - 1);
				collider.GetComponent<BoxCollider> ().enabled = false;
				Destroy (collider.gameObject);
				// Reset game
				if (PlayerPrefs.GetInt ("Lives") <= 0) 
				{
					//PlayerPrefs.SetInt ("Lives", 3);
					//SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
					GameOverUI.SetActive (true);
					GameObject.Find ("Controls").SetActive (false);
				} 
				else // If still lives remaining
				{
					GameObject.FindGameObjectWithTag("ScreenShaker").GetComponent<Shake>().ShakeScreen (0.8f);

				}
			}
		}
	}

	void OnTriggerExit(Collider collider)
	{
		if (collider.tag == "Cutout")
		{
			PlayerPrefs.SetInt ("Scores", PlayerPrefs.GetInt("Scores") + 1);
			scoreAnim.Play ("ScoreAnim");
			PassAudio.Play ();
		}
	}
}
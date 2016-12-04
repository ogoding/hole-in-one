using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerShape : Shape {

    // Shouldn't be changed by code outside this class but is public to allow for setting default value
    public int currentShape;
    public PrimitiveType[] availableShapes;
	public GameObject GameOverUI;

    private void Start()
    {
        GetComponent<MeshFilter>().mesh = PrimitiveHelper.GetPrimitiveMesh(availableShapes[currentShape]);
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

        GetComponent<MeshFilter>().mesh = PrimitiveHelper.GetPrimitiveMesh(availableShapes[currentShape]);
		switch (availableShapes [currentShape]) {
		case PrimitiveType.Cube:
			type = ShapeType.Rectangle;
			break;
		case PrimitiveType.Sphere:
			type = ShapeType.Circle;
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
				PlayerPrefs.SetInt ("Lives", PlayerPrefs.GetInt ("Lives") - 1);
				// Reset game
				if (PlayerPrefs.GetInt ("Lives") <= 0) 
				{
					PlayerPrefs.SetInt ("Lives", 3);
					//SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
					GameOverUI.SetActive (true);
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
		}
	}
}
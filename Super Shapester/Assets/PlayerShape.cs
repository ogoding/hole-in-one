using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerShape : Shape {

    // Shouldn't be changed by code outside this class but is public to allow for setting default value
    public int currentShape;
    public PrimitiveType[] availableShapes;
	public static int score = 0;
	public static int lives = 3;

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
    }

	private bool PlayerInShape(GameObject player, GameObject wall)
	{
		return wall.GetComponent<WallComponent> ().TestOverlapping (player.GetComponent<Shape> ());
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Wall")
		{
			if (!PlayerInShape(gameObject, collider.gameObject))
			{
				lives--;
				// Reset game
				if (lives == 0)
				{
					lives = 3;
					SceneManager.LoadScene ("main");
				}					
			}
		}
	}

	void OnTriggerExit(Collider collider)
	{
		if (collider.tag == "Cutout")
		{
			score++;
		}
	}
}
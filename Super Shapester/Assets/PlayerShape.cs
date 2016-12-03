using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerShape : Shape {

    // Shouldn't be changed by code outside this class but is public to allow for setting default value
    public int currentShape;
    public PrimitiveType[] availableShapes;

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

	void OnTriggerStay(Collider collider)
	{
		if (collider.tag == "Wall")
		{
			if (!PlayerInShape(gameObject, collider.gameObject))
			{
				SceneManager.LoadScene ("main");
				Debug.Log ("You died!");
				// Code here to reset game.
			}
		}
	}

	void OnTriggerExit(Collider collider)
	{
		if (collider.tag == "Cutout")
		{
			Debug.Log ("You got a point!");
		}
	}
}

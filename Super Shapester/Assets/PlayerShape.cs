using UnityEngine;
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
}

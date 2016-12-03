using UnityEngine;
using System.Collections;

public class WallComponent : MonoBehaviour {
    public float xScale;
    public float yScale;
    public float zScale;

    public int cutoutCount;
    public GameObject[] cutouts;

    public GameObject[] cutoutShapes;

    private void Start()
    {
        // generate cutouts - randomise mesh/type
        // randomise position - ensure min distance between cutouts
        cutouts = new GameObject[cutoutCount];
        for (int i = 0; i < cutoutCount; i++)
        {
            // generate shapes
            cutouts[i] = (GameObject)Instantiate(cutoutShapes[Random.Range(0,cutoutShapes.Length)], this.transform.position, this.transform.rotation);

            Vector3 scale = cutouts[i].transform.localScale;
            scale.x = xScale + cutouts[i].GetComponent<Shape>().xScale;
            scale.y = yScale + cutouts[i].GetComponent<Shape>().yScale;
            scale.z = zScale + cutouts[i].GetComponent<Shape>().zScale;
            cutouts[i].transform.localScale = scale;
            
            cutouts[i].transform.parent = this.transform;
            
            cutouts[i].GetComponent<Renderer>().material.color = Color.red;
        }
    }

    public bool TestOverlapping(Shape shape)
    {
        foreach(GameObject cutout in cutouts)
        {
            if (shape.OverlapTest(cutout.GetComponent<Shape>()))
            {
                return true;
            }
        }
        return false;
    }
}

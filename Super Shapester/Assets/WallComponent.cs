using UnityEngine;
using System.Collections;

public class WallComponent : MonoBehaviour {
    public float xScale;
    public float yScale;
    public float zScale;

    static float padding = 0.5f;

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

            // TODO Test for cutouts being too close to other cutouts
            Vector3 position = cutouts[i].transform.localPosition;
            position.x = Random.Range(-1, 1) / Random.Range(0 + xScale, transform.localScale.x - xScale);
            position.y = Random.Range(-1, 1) / Random.Range(0 + yScale + padding, transform.localScale.y - yScale - padding);
            cutouts[i].transform.localPosition = position;

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

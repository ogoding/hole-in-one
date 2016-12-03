using UnityEngine;
using System.Collections;

public class WallComponent : MonoBehaviour {
    public float xScale;
    public float yScale;
    public float zScale;

    public static float padding = 2f;

    public int cutoutCount;
    public GameObject[] cutouts;

    public GameObject[] cutoutShapes;

    public float MIN_CUTOUT_DIST;

    private void Start()
    {
        cutouts = new GameObject[cutoutCount];
        for (int i = 0; i < cutoutCount; i++)
        {
            GameObject cutout = (GameObject)Instantiate(cutoutShapes[Random.Range(0,cutoutShapes.Length)], this.transform.position, this.transform.rotation);

            Vector3 scale = cutout.transform.localScale;
            scale.x = xScale + cutout.GetComponent<Shape>().xScale;
            scale.y = yScale + cutout.GetComponent<Shape>().yScale;
            scale.z = zScale + cutout.GetComponent<Shape>().zScale;
            cutout.transform.localScale = scale;

            cutout.transform.parent = this.transform;
            
            Vector3 position = cutout.transform.localPosition;
            do
            {
                position.x = GetRandomCutoutPosition(0 + xScale, transform.localScale.x - xScale, padding);
                position.y = GetRandomCutoutPosition(0 + yScale, transform.localScale.y - yScale, padding);
            } while (!TestValidCutoutPosition(position));

            cutout.transform.localPosition = position;

            cutout.GetComponent<Renderer>().material.color = Color.red;

            cutouts[i] = cutout;
        }
    }

    private float GetRandomCutoutPosition(float min, float max, float padding)
    {
        float randPos = Random.Range(min + padding, max - padding);
        // Shift pos so that 0 is the middle value and turn into a proportion of total range
        return (randPos - (max / 2)) / max;
    }

    private bool TestValidCutoutPosition(Vector3 position)
    {
        foreach(GameObject cutout in cutouts)
        {
            if (cutout != null && Vector3.Distance(position, cutout.transform.localPosition) < MIN_CUTOUT_DIST)
            {
                return false;
            }
        }
        
        return true;
    }

    public bool TestOverlapping(Shape shape)
    {
        if (shape == null)
        {
            Debug.LogError("SHAPE IS NULL");
        }
        foreach(GameObject cutout in cutouts)
        {
            if (cutout == null)
            {
                Debug.LogWarning("CUTOUT IS NULL");
            }
            if (shape.OverlapTest(cutout.GetComponent<Shape>()))
            {
                return true;
            }
        }
        return false;
    }
}

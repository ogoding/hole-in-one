using UnityEngine;
using System.Collections;

public class Shape : MonoBehaviour {
    public enum ShapeType
    {
        Rectangle,
        Circle
    }

    public ShapeType type;

    private float padding;  // TODO get this from somewhere
    
    public float xScale;
    public float yScale;
    public float zScale;

    public bool OverlapTest(Shape cutout)
    {
        if (cutout != null && cutout.type == type)
        {
            return Vector3.Distance(cutout.center, this.center) < 1 + cutout.padding;
        }

        return false;
    }

    public Vector3 center
    {
        get
        {
            return transform.position;
        }
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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

	public GameObject QSphere;
	public GameObject QSquare;
	public GameObject QTriangle;

	public GameObject ESphere;
	public GameObject ESquare;
	public GameObject ETriangle;

	void Update ()
	{
		if (type == ShapeType.Circle) 
		{
			QSquare.SetActive (true);
			QSphere.SetActive (false);
			QTriangle.SetActive (false);

			ESquare.SetActive (false);
			ESphere.SetActive (false);
			ETriangle.SetActive (true);
		}

		if (type == ShapeType.Rectangle) 
		{
			QSphere.SetActive (false);
			QSquare.SetActive (false);
			QTriangle.SetActive (true);

			ESquare.SetActive (false);
			ESphere.SetActive (true);
			ETriangle.SetActive (false);
		}

		/*
		if (type == ShapeType.Triangle) 
		{
			QSquare.SetActive (false);
			QSphere.SetActive (true);
			QTriangle.SetActive (false);

			ESphere.SetActive (false);
			ESquare.SetActive (true);
			ETriangle.SetActive (false);
		}
		*/
	}

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

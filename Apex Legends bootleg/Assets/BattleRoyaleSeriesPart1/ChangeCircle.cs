using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class ChangeCircle : MonoBehaviour
{
	[Range(0, 360)]
	public int Segments;
	[Range(0,5000)]
	public float XRadius;
	[Range(0,5000)]
	public float YRadius;
	public GameObject ZoneWall;
	public bool Shrinking=false;
	public float dist;
	public GameObject Player;
	#region Private Members
	private WorldCircle circle;
	private LineRenderer renderer;
	private float [] radii = new float[2];
	private bool outside=false;
	public GameObject outsideUI;



	#endregion

	void Start ()
	{
		renderer = gameObject.GetComponent<LineRenderer>();
		radii[0] = XRadius;  radii[1] = YRadius;
		circle = new WorldCircle(ref renderer, Segments, radii);
		//ZoneWall = GameObject.FindGameObjectWithTag ("ZoneWall");	
		StartCoroutine(shrinktimer());
		outsideUI.SetActive(false);



	}

	// Update is called once per frame
	void Update ()
	{
		dist = Vector3.Distance(Player.transform.position, ZoneWall.transform.position);

        


		if (dist < XRadius)
		{
			outside = false;
			outsideUI.SetActive(false);
            // the player inside circle
        }
        else
        {

            if (!outside)
            {
				outsideUI.SetActive(true);
				outside = true;
				StartCoroutine(zonedamage());
            }


			//player outside circle
		}

		if (Shrinking)
		{
			XRadius = Mathf.Lerp(XRadius, ShrinkCircle(XRadius)[0], Time.deltaTime * 0.1f);
			circle.Draw(Segments, XRadius, XRadius);
		}
		ZoneWall.transform.localScale = new Vector3 ((XRadius * 0.01f), 1, (XRadius * 0.01f));
		//Debug.Log (XRadius);
	}

	private float[] ShrinkCircle(float amount)
	{
		float newXR = circle.radii[0] - amount;
		float newYR = circle.radii[1] - amount;
		float [] retVal = new float[2];
		retVal[0] = newXR;
		retVal[1] = newYR;
		return retVal;
	}
	IEnumerator shrinktimer()
    {
		yield return new WaitForSeconds(30f);
		Shrinking = true;
		yield return new WaitForSeconds(5f);
		Shrinking = false;

		StartCoroutine(shrinktimer());

	}
	IEnumerator zonedamage()
    {
		Player.GetComponent<Player>().TakeDamage(10);
		yield return new WaitForSeconds(10f);
		if (outside)
			StartCoroutine(zonedamage());

	}
}
using UnityEngine;
using System.Collections;
using Leap;

public class HandController : MonoBehaviour {
  public GameObject[] fingers;
  public GameObject[] colliders;
  public GameObject[] lines;

  private LeapManager _leapManager;
  // Use this for initialization
  void Start () {
    _leapManager = (GameObject.Find("LeapManager")as GameObject).GetComponent(typeof(LeapManager)) as LeapManager;
  }
	
  // Update is called once per frame
  void Update () {
    Hand primeHand = _leapManager.frontmostHand();

    if(primeHand.IsValid)
      {
	Vector3[] fingerPositions = _leapManager.getWorldFingerPositions(primeHand);
	gameObject.transform.position = primeHand.PalmPosition.ToUnityTranslated();
	if(gameObject.renderer.enabled != true) { gameObject.renderer.enabled = true; }
	
	for(int i=0;i<fingers.GetLength(0);i++)
	  {
	    if(i < fingerPositions.GetLength(0))
	      {
		fingers[i].transform.position = fingerPositions[i];
		if(fingers[i].renderer.enabled == false) { fingers[i].renderer.enabled = true; }
		if(lines[i].renderer.enabled == false) { lines[i].renderer.enabled = true; }
		
		if(colliders != null && i < colliders.GetLength(0))
		  {
		    (colliders[i].GetComponent(typeof(SphereCollider)) as SphereCollider).enabled = true;
		  }
	      }
	    else
	      {
		fingers[i].renderer.enabled = false;
		lines[i].renderer.enabled = false;
		if(colliders != null && i < colliders.GetLength(0))
		  {
		    (colliders[i].GetComponent(typeof(SphereCollider)) as SphereCollider).enabled = false;
		  }
	      }
	  }
      }
    else
      {
	gameObject.renderer.enabled = false;
	
	foreach(GameObject finger in fingers)
	  {
	    if(finger.renderer.enabled == true) { finger.renderer.enabled = false; }
	  }
	foreach(GameObject line in lines)
	  {
	    if(line.renderer.enabled == true) { line.renderer.enabled = false; }
	  }
      }
    
  }
}





using UnityEngine;
using System.Collections;

public class DrawLine : MonoBehaviour {
  LineRenderer line;
  public Transform origin;
  public Transform destination;

  // Use this for initialization
  void Start () {
    line=GetComponent<LineRenderer>();
  }
	
  // Update is called once per frame
  void Update () {
//    line.SetPosition(0, new Vector3(0, 0, 0));
//    line.SetPosition(1, new Vector3(10, 10 ,10));
    line.SetPosition(0, origin.position);
    line.SetPosition(1, destination.position);
  }
}

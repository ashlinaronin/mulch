using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTreadmill : MonoBehaviour {

	private Renderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 newOffset = new Vector2(0, rend.materials[0].GetTextureOffset("_MainTex").y + Time.deltaTime);
		rend.materials[0].SetTextureOffset("_MainTex", newOffset);
	}
}

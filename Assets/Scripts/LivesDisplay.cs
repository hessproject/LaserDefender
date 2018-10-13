using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour {

    Text livesText;
	// Use this for initialization
	void Start () {
        livesText = GetComponent<Text>();
	}
	
}

using UnityEngine;
using System.Collections;

public class Load_string_level : MonoBehaviour {

    public string Scene_name;
	// Use this for initialization

    public void load(string scene_name)
    {
        Application.LoadLevel(scene_name);
    }
}

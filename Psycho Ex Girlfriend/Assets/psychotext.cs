using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class psychotext : MonoBehaviour {

	public string currentRoom;
	public AudioSource sfxSound;

	private string room_up;
	private string room_down;
	private string room_left;
	private string room_right;

	public string textBuffer;

	private bool hasKey = false;
	private bool hasRope = false; 

	void Start () {
		// GetComponent<Text>().text = "Hey, we ran the project.";
		// the above line would set our text immediately to a default value, but we actually don't need this, so I have commented it out with "//"

		// here I have "initialized" our currentRoom variable.
		currentRoom = "main entrance";

		// I'm also initializing our room variables to nil.
		room_down = "nil";
		room_up = "nil";
		room_left = "nil";
		room_right = "nil";

	}

	// Update is called once per frame
	void Update () {

		// here we reset our room variables to "nil" so that we don't accidentally create unwanted connections. 
		// Since code is read top to bottom, this'll be overwritten by the if statement below.
		room_down = "nil";
		room_up = "nil";
		room_left = "nil";
		room_right = "nil";


		if (currentRoom == "main entrance") {

			room_up = "hallway";
			room_right = "kitchen";
			room_left = "living room"; 


			textBuffer = "You are currently in the main entrance.\n";
			textBuffer += "This house has a creepy vibe.";

		} else if (currentRoom == "hallway") {

			textBuffer = "You are now in the hallway.\n";
			textBuffer += "OMG ITS THE PSYCHO EX GIRLFRIEND!!!!!\n";

			if (hasRope) { 
				textBuffer += " You yell: 'Fear me bitch.' and tie up the psycho ex-girlfriend. \n";
				room_up = "master bedroom";
				room_down = "main entrance";

			} else {
				textBuffer += "The psycho ex-girlfriend attacks you, but you manage to get away with only a bruise.\n";
				room_down = "main entrance"; 
			}

		} else if (currentRoom == "master bedroom") {

			textBuffer = "You reached the master bedroom.\n";

			if (hasKey) {
				textBuffer += " Congrats! You unlocked the door and saved your boyfriend. \n";
			} else { 
				textBuffer += "Damn it. It's locked but you hear someone yelling help. \n";
				room_down = "hallway";			
			}		
		 
		} else if (currentRoom == "kitchen") {
			room_left = "main entrance";
			room_down = "basement";

			textBuffer = "You are now in the kitchen.\n";

		} else if (currentRoom == "basement") {
			room_up = "kitchen";
			room_left = "wine cellar"; 

			textBuffer = "You are in the basement..spooky. \n";

		} else if (currentRoom == "wine cellar") {
			room_right = "basement";

			textBuffer = "You are in the wine cellar. \n";

		} else if (currentRoom == "living room") {
			room_right = "main entrance";
			room_up = "workout room";
			room_down = "toy room";

			textBuffer = "You are in the living room. \n";

		} else if (currentRoom == "toy room") {
			room_up = "living room"; 

			textBuffer = "You are in the toy room. \n";
			textBuffer = "You find a pile of rope and pick it up. This could be helpful to tie up the pshyco ex girlfriend. \n";

			hasRope = true;

		} else if (currentRoom == "workout room") {
			room_up = "backyard";
			room_down = "living room"; 
			room_right = "sauna";

			textBuffer = "You are in workout room. \n";
		
		} else if (currentRoom == "backyard") {
			room_down = "workout room"; 

			textBuffer = "You are in the backyard. \n";
			textBuffer += " You found a key and picked it up \n";

			hasKey = true; 

		} else if (currentRoom == "sauna") {
			room_left = "workout room"; 

			textBuffer = "You are in the sauna. \n";

		}
		textBuffer += "\n\n";

		if (room_up != "nil")
		{
			textBuffer += "Press Up to go to the " + room_up + "\n";

			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				currentRoom = room_up;
			}
		}
		if (room_down != "nil")
		{
			textBuffer += "Press Down to go to the " + room_down + "\n";

			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				currentRoom = room_down;
			}
		}
		if (room_left != "nil")
		{
			textBuffer += "Press Left to go to the " + room_left + "\n";

			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				currentRoom = room_left;
			}
		}
		if (room_right != "nil")
		{
			textBuffer += "Press Right to go to the " + room_right + "\n";

			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				currentRoom = room_right;
			}
		}


		GetComponent<Text>().text = textBuffer;
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WorldPanelController : MonoBehaviour {

	public Button L1W1;
	public Button L2W1;
	public Button L3W1;
	public Button L1W2;
	public Button L2W2;
	public Button L3W2;
	public Button L1W3;
	public Button L2W3;
	public Button L3W3;


	public Color Open;
	public Color Beat;




	public int levelReached;
	// Use this for initialization
	void Start () {


		Open = new  Color(119,211,255,90);
		//Beat = new Color(255,255,0,90);
		Beat = Color.green;
		L2W1.GetComponent<Image>().color = Color.clear;
		L3W1.GetComponent<Image>().color = Color.clear;

		L1W2.GetComponent<Image>().color = Color.clear;
		L2W2.GetComponent<Image>().color = Color.clear;
		L3W2.GetComponent<Image>().color = Color.clear;

		L1W3.GetComponent<Image>().color = Color.clear;
		L2W3.GetComponent<Image>().color = Color.clear;
		L3W3.GetComponent<Image>().color = Color.clear;

		L2W1.GetComponent<Button>().interactable = false;
		L3W1.GetComponent<Button>().interactable = false;
		L1W2.GetComponent<Button>().interactable = false;
		L2W2.GetComponent<Button>().interactable = false;
		L3W2.GetComponent<Button>().interactable = false;
		L1W3.GetComponent<Button>().interactable = false;
		L2W3.GetComponent<Button>().interactable = false;
		L3W3.GetComponent<Button>().interactable = false;


		levelReached = PlayerData.playerData.levelReached;
		UnBlockLevels ();

	}
	public void UnBlockLevels(){
		if (levelReached == 0) {
			L1W1.GetComponent<Image> ().color = Open;
			L1W1.GetComponent<Button> ().interactable = true;
		} else if (levelReached > 0) {
			L1W1.GetComponent<Image> ().color = Beat;
			L1W1.GetComponent<Button> ().interactable = true;
		}
		if (levelReached == 1) {
			L2W1.GetComponent<Image>().color = Open;
			L2W1.GetComponent<Button>().interactable = true;
		}else if (levelReached > 1) {
			L2W1.GetComponent<Image> ().color = Beat;
			L2W1.GetComponent<Button> ().interactable = true;
		}
		if (levelReached == 2) {
			L3W1.GetComponent<Image>().color = Open;
			L3W1.GetComponent<Button>().interactable = true;
		}else if (levelReached > 2) {
			L3W1.GetComponent<Image> ().color = Beat;
			L3W1.GetComponent<Button> ().interactable = true;
		}
		if (levelReached == 3) {
			L3W1.GetComponent<Image>().color = Open;
			L3W1.GetComponent<Button>().interactable = true;
		}else if (levelReached > 3) {
			L3W1.GetComponent<Image> ().color = Beat;
			L3W1.GetComponent<Button> ().interactable = true;
		}


		if (levelReached == 4) {
			L1W2.GetComponent<Image>().color = Open;
			L1W2.GetComponent<Button>().interactable = true;
		}else if (levelReached > 4) {
			L1W2.GetComponent<Image> ().color = Beat;
			L1W2.GetComponent<Button> ().interactable = true;
		}
		if (levelReached == 5) {
			L2W2.GetComponent<Image>().color = Open;
			L2W2.GetComponent<Button>().interactable = true;
		}else if (levelReached > 5) {
			L2W2.GetComponent<Image> ().color = Beat;
			L2W2.GetComponent<Button> ().interactable = true;
		}
		if (levelReached == 6) {
			L3W2.GetComponent<Image>().color = Open;
			L3W2.GetComponent<Button>().interactable = true;
		}else if (levelReached > 6) {
			L3W2.GetComponent<Image> ().color = Beat;
			L3W2.GetComponent<Button> ().interactable = true;
		}


		if (levelReached == 7) {
			L1W3.GetComponent<Image>().color = Open;
			L1W3.GetComponent<Button>().interactable = true;
		}else if (levelReached > 7) {
			L1W3.GetComponent<Image> ().color = Beat;
			L1W3.GetComponent<Button> ().interactable = true;
		}
		if (levelReached == 8) {
			L2W3.GetComponent<Image>().color = Open;
			L2W3.GetComponent<Button>().interactable = true;
		}else if (levelReached > 8) {
			L2W3.GetComponent<Image> ().color = Beat;
			L2W3.GetComponent<Button> ().interactable = true;
		}
		if (levelReached == 9) {
			L3W3.GetComponent<Image>().color = Open;
			L3W3.GetComponent<Button>().interactable = true;
		}else if (levelReached > 9) {
			L3W3.GetComponent<Image> ().color = Beat;
			L3W3.GetComponent<Button> ().interactable = true;
		}



	}

}

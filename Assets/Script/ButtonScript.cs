namespace VRTK
{
	using UnityEngine;
	using System.Collections;
	using UnityEngine.UI;

	public class ButtonScript : VRTK_InteractableObject {

		[SerializeField]
		GameObject gameManager;

		void Start() {

			base.Start();
		}

		public override void StartTouching(GameObject currentTouchingObject) {
			base.StartTouching (currentTouchingObject);

			GetComponent<Image> ().color = new Color(0,234,255);
		}

		public override void StopTouching(GameObject previousTouchingObject) {
			base.StopTouching (previousTouchingObject);

			GetComponent<Image> ().color = Color.white;
		}
		
		public override void StartUsing(GameObject usingObject)
		{
			base.StartUsing(usingObject);
			gameManager.GetComponent<SceneLoad> ().Change (0);
		}
	}
}

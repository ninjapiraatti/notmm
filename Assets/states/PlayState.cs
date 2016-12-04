using UnityEngine;
using Assets.interfaces;

namespace Assets.states {

	public class PlayState : IStateBase {

		private StateManager manager;
		public PlayState (StateManager managerRef) {

			manager = managerRef;
			//Debug.Log("Constructing playstate");
		}
		public void StateUpdate() {
			if (GameObject.Find("Character") == null) {
				manager.SwitchState (new LostState (manager));
				Debug.Log("sdfsd");
			}
		}
		public void ShowIt() {

		}
	}
}

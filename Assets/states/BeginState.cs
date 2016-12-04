using UnityEngine;
using Assets.interfaces;

namespace Assets.states {

	public class BeginState : IStateBase {

		private StateManager manager;

		public BeginState (StateManager managerRef) {

			manager = managerRef;
			//Debug.Log("Constructing beginstate");
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

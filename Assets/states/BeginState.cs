using UnityEngine;
using Assets.interfaces;

namespace Assets.states {

	public class BeginState : IStateBase {

		private StateManager manager;
		
		public BeginState (StateManager managerRef) {

			manager = managerRef;
			Debug.Log("Constructing beginstate");
		}
		public void StateUpdate() {
			if (Input.GetKeyUp (KeyCode.Space)) {
				manager.SwitchState (new PlayState (manager));
			}
		}
		public void ShowIt() {

		}
	}
}

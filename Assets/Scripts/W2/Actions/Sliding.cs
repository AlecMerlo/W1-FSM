using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class Sliding : ActionTask {
        public BBParameter<GameObject> otherFSM;
		public BBParameter<int> loc;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            Blackboard oFSM = otherFSM.value.GetComponent<Blackboard>();
			if (oFSM.GetVariableValue<int>("location") == loc.value) {
				oFSM.SetVariableValue("friendship", oFSM.GetVariableValue<float>("friendship") + Time.deltaTime);
			}
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}
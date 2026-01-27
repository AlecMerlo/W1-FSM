using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class WaitForSecondsCondition : ConditionTask {
		private float waitTime;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			waitTime = 0.0f;
		}

		protected override bool OnCheck() {
			waitTime += Time.deltaTime;
			return waitTime > 14.0f;
		}
	}
}
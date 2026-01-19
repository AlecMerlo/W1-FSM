using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class ChoiceToFollowFriend : ConditionTask {
		private float timer = 0;
        public BBParameter<GameObject> otherFSM;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			timer = 0;
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			timer += Time.deltaTime;
            Blackboard oFSM = otherFSM.value.GetComponent<Blackboard>();
            if (timer > 6)
			{
				if(Random.Range(0, 100) <= oFSM.GetVariableValue<float>("friendship"))
				{
                    return true;
                }
				timer = 0;
			}
			return false;
		}
	}
}
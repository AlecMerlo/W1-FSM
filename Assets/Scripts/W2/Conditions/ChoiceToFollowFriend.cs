using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class ChoiceToFollowFriend : ConditionTask {
        public BBParameter<GameObject> otherFSM;
		private bool tried;

        protected override string OnInit(){
			return null;
		}
		protected override void OnEnable() {
			tried = false;
		}

		protected override bool OnCheck() {
            Blackboard oFSM = otherFSM.value.GetComponent<Blackboard>();

			if(Random.Range(0, 100) < oFSM.GetVariableValue<float>("friendship") && !tried)
                return true;
			else
				tried = true;
				return false;
		}
	}
}
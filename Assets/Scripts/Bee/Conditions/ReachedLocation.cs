using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Conditions {

	public class ReachedLocation : ConditionTask {
        public BBParameter<NavMeshAgent> nav;
        public float timeToWaitAfter = 0;
        private float timer;
        
        protected override string OnInit(){
			return null;
		}

        protected override void OnEnable()
        {
            timer = 0;
        }

		protected override bool OnCheck() {

            if (!nav.value.hasPath)
            {
                timer += Time.deltaTime;
            }
			return (timer > timeToWaitAfter && !nav.value.hasPath);
		}
	}
}
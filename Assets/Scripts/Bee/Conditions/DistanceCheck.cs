using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class DistanceCheck : ConditionTask {
		public Transform pos1, pos2;
		public int desiredDistance;
		public float timeToWait = 0;
		public bool lessThan;
		private float timer;

        protected override void OnEnable()
        {
			timer = 0;
        }
		protected override bool OnCheck() {
			if (timer > timeToWait)
			{
				if (lessThan) return (Vector3.Distance(pos1.position, pos2.position) < desiredDistance);
				else return (Vector3.Distance(pos1.position, pos2.position) > desiredDistance);
			}
			else
			{
				timer += Time.deltaTime;
			}
			return false;
		}
	}
}
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Numerics;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class DistanceCheck : ConditionTask {
		Transform pos1, pos2;
		public int desiredDistance;
		public bool lessThan;

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		//protected override bool OnCheck() {
			//if(lessThan)
			//return (Vector3.Distance() < desiredDistance);
			//else return (Vector3.Distance() > desiredDistance);
		//}
	}
}
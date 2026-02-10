using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class CollectPollen : ActionTask {
        public BBParameter<float> pollen;
        public int dir;

        protected override void OnUpdate()
        {
            pollen.value += Time.deltaTime * dir;
        }
    }
}
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class SetBeeHeight : ActionTask {
		public float desiredHeight;
		private float desiredHeightOffset = 0;
		private int offsetMult = 1;
		public bool flyingAbout = false;
        public BBParameter<GameObject> parent;

        protected override void OnExecute()
        {
			desiredHeightOffset = 0;
			offsetMult = 1;
        }

		protected override void OnUpdate() {

			if (parent.value.transform.localPosition.y < (desiredHeight + desiredHeightOffset) - 0.1f)
			{
                parent.value.transform.localPosition += Vector3.up * Time.deltaTime * 6;
			}
			else if (parent.value.transform.localPosition.y > (desiredHeight + desiredHeightOffset) + 0.1f)
			{
                parent.value.transform.localPosition -= Vector3.up * Time.deltaTime * 6;
            }
			else if (!flyingAbout)
			{
				EndAction(true);
			}

			if (flyingAbout)
			{
				if (desiredHeightOffset > 3)
				{
					offsetMult = -1;
				}
				else if (desiredHeightOffset < 0)
				{
					offsetMult = 1;
				}

				desiredHeightOffset += Time.deltaTime * 2 * offsetMult;
			}
		}

    }
}
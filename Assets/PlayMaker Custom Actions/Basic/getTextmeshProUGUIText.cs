// (c) Eric Vander Wal, 2017 All rights reserved.
// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using TMPro;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("TextMesh Pro UGUI Basic")]
	[Tooltip("Get Text Mesh Pro Text UGUI.")]

	public class  getTextmeshProUGUIText : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(TextMeshProUGUI))]
		[Tooltip("Textmesh Pro component is required.")]
		public FsmOwnerDefault gameObject;

		[UIHint(UIHint.TextArea)]
		[TitleAttribute("Textmesh Pro Text")]
		[Tooltip("The text for Textmesh Pro.")]
		public FsmString textString;

		[Tooltip("Check this box to preform this action every frame.")]
		public FsmBool everyFrame;

		TextMeshProUGUI meshproScript;

		public override void Reset()
		{

			gameObject = null;
			textString = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);


			meshproScript = go.GetComponent<TextMeshProUGUI>();

			if (!everyFrame.Value)
			{
				DoMeshChange();
				Finish();
			}

		}

		public override void OnUpdate()
		{
			if (everyFrame.Value)
			{
				DoMeshChange();
			}
		}

		void DoMeshChange()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null)
			{
				return;
			}

			textString.Value = meshproScript.text;
		}

	}
}
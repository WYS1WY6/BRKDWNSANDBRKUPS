// (c) Eric Vander Wal, 2017 All rights reserved.
// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using TMPro;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("TextMesh Pro UGUI Advanced")]
	[Tooltip("Enable Text Mesh Pro auto size UGUI text.")]

	public class  enableTextmeshProUGUIAutoSizeText : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(TextMeshProUGUI))]
		[Tooltip("Textmesh Pro component is required.")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[TitleAttribute("Enable Size Text")]
		[Tooltip("Enable Auto Size Text.")]
		public FsmBool autoSizeText;

		[Tooltip("Max font size.")]
		public FsmFloat fontSizeMax;

		[Tooltip("Min font size.")]
		public FsmFloat fontSizeMin;

		[Tooltip("Line Spacing.")]
		public FsmFloat lineSpacing;

		[Tooltip("Width Adjustment.")]
		public FsmFloat widthAdjustment;

		[Tooltip("Check this box to preform this action every frame.")]
		public FsmBool everyFrame;

		TextMeshProUGUI meshproScript;

		public override void Reset()
		{

			gameObject = null;
			autoSizeText = false;
			fontSizeMax = null;
			fontSizeMin = null;
			everyFrame = false;
			lineSpacing = null;
			widthAdjustment = null;
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

			meshproScript.enableAutoSizing = autoSizeText.Value;
			meshproScript.fontSizeMax = fontSizeMax.Value;
			meshproScript.fontSizeMin = fontSizeMin.Value;
			meshproScript.lineSpacingAdjustment = lineSpacing.Value;
			meshproScript.characterWidthAdjustment = widthAdjustment.Value;

		}

	}
}
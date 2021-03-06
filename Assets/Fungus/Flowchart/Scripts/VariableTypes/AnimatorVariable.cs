using UnityEngine;
using System.Collections;

namespace Fungus
{
	[VariableInfo("Other", "Animator")]
	[AddComponentMenu("")]
	public class AnimatorVariable : VariableBase<Animator>
	{}

	[System.Serializable]
	public struct AnimatorData
	{
		[SerializeField]
		[VariableProperty("<Value>", typeof(AnimatorVariable))]
		public AnimatorVariable animatorRef;
		
		[SerializeField]
		public Animator animatorVal;

		public AnimatorData(Animator v)
		{
			animatorVal = v;
			animatorRef = null;
		}
		
		public static implicit operator Animator(AnimatorData animatorData)
		{
			return animatorData.Value;
		}

		public Animator Value
		{
			get { return (animatorRef == null) ? animatorVal : animatorRef.value; }
			set { if (animatorRef == null) { animatorVal = value; } else { animatorRef.value = value; } }
		}

		public string GetDescription()
		{
			if (animatorRef == null)
			{
				return animatorVal.ToString();
			}
			else
			{
				return animatorRef.key;
			}
		}
	}

}
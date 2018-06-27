using UnityEditor;
namespace Wokarol {
	[CustomPropertyDrawer(typeof(FloatVariableReference))]
	[CustomPropertyDrawer(typeof(StringVariableReference))]
	public class ReferenceDrawer : GenericReferenceDrawer { }
}
using UnityEditor;
namespace Wokarol {
	[CustomPropertyDrawer(typeof(FloatVariableReference))]
	[CustomPropertyDrawer(typeof(StringVariableReference))]
	[CustomPropertyDrawer(typeof(IntVariableReference))]
	public class ReferenceDrawer : GenericReferenceDrawer { }
}
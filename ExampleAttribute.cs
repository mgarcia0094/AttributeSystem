/*
	An example of attribute with AttributesSystem
*/

namespace AttributesSystem.attributes {
	[System.Serializable]
	public class ExampleAttribute : Attribute {
		#region constructor
		public ExampleAttribute() {}

		public override Attribute Clone() {
			return new ExampleAttribute(this);
		}

		public ExampleAttribute(ExampleAttribute attribute) {
			Init(attribute.Value, attribute.MinValue, attribute.MaxValue, attribute.IncreaseStep, attribute.Modifier);
		}
		#endregion
	}
}

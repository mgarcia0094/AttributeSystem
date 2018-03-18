namespace AttributesSystem.attributes {
	[System.Serializable]
	public abstract class Attribute {
		public float Value {get; private set;}
		public float MinValue {get; private set;}
		public float MaxValue {get; private set;}
		public float IncreaseStep {get; private set;}
		public GameEnums.Modifier Modifier {get; private set;}

		public string Name {get {return GetType().Name;}}

		public void Init(float value, float minvalue, float maxvalue, float increasestep, GameEnums.Modifier modifier) {
			Value = value;
			MinValue = minvalue;
			MaxValue = maxvalue;
			IncreaseStep = increasestep;
			Modifier = modifier;
		}

		#region constructor
		
		public Attribute() {}

		public virtual Attribute Clone() {
			return null;
		}

		public Attribute(Attribute attribute) {
			Value = attribute.Value;
			MinValue = attribute.MinValue;
			MaxValue = attribute.MaxValue;
			IncreaseStep = attribute.IncreaseStep;
			Modifier = attribute.Modifier;
		}

		#endregion
	}
}

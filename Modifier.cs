using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AttributesSystem.attributes {
	[System.Serializable]
	public class Modifier {

		public uint Id {private set; get;} //try to a unique id, that way same modifier cant be added twice
		public GameEnums.Modifier ModifierType {private set; get;} //3 basic formulas "percent", "addition" and "critics"
		public Attribute Attribute {private set; get;} //what is the attribute for tus modifier?

		#region constructor
		public Modifier(){}

		//constructor
		public Modifier(uint _id, GameEnums.Modifier _formula, Attribute _attribute) {
			Id = _id;
			ModifierType = _formula;
			Attribute = _attribute;
		}

		public Modifier(Modifier modifier) {
			Id = modifier.Id;
			ModifierType = modifier.ModifierType;
			Attribute = modifier.Attribute;
		}

		public Modifier Clone() {
			return new Modifier(this);
		}
		#endregion

		//clear the attribute
		public void Destroy() {
			Attribute = null;
		}
	}
}

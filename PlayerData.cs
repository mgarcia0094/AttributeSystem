using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AttributesSystem.attributes {
	[System.Serializable]
	public class PlayerData {

		public uint CharacterId {get; private set;}
		public string id;
		public string name;

		List<AttributesSystem.attributes.Attribute> _attributes = new List<AttributesSystem.attributes.Attribute>();
		List<AttributesSystem.attributes.Modifier> _modifiers = new List<AttributesSystem.attributes.Modifier>();

		public void Init(uint charid, List<AttributesSystem.attributes.Attribute> attributes) {
			CharacterId = charid;
			_attributes = attributes;
		}

		public void Destroy() {
			int total = _modifiers.Count - 1;
			//Deep destroy
			for (int i = total; i > -1; i--) {
				_modifiers[i].Destroy();
			}

			_modifiers.Clear();
			_modifiers = null;
		}

		#region attributes
		public Attribute GetAttribute<T>() {
			  for(int i=0; i < _attributes.Count; i++) {
				  if(_attributes[i] is T) {
					  return _attributes[i];
				  }
			  }
			  return null;
		}

		public Attribute GetAttribute(string name) {
			for(int i=0; i < _attributes.Count; i++) {
				  if(_attributes[i].Name == name) {
					  return _attributes[i];
				  }
			  }
			  return null;
		}

		public void RemoveAttribute<T>() {
			for(int i = 0; i < _attributes.Count; i++) {
				if(_attributes[i] is T) {
					_attributes.RemoveAt(i);
					break;
				}
			}
		}

		public void RemoveAttribute(string name) {
			for(int i=0; i < _attributes.Count; i++) {
				if(_attributes[i].Name == name) {
					_attributes.RemoveAt(i);
					break;
				}
			}
		}

		public float GetAttributeDefaultValue<T>() {
			Attribute attr = GetAttribute<T>();
			return attr == null ? 0f : attr.Value;
		}

		public float GetAttributeDefaultValue(string name) {
			Attribute attr = GetAttribute(name);
			return attr == null ? 0f : attr.Value;
		}

		public float GetAttributeTotalValue<T>() {
			List<Modifier> existingModifiers = new List<Modifier>();

			//loop and search  if a modifier exists
			for(int i = 0; i < _modifiers.Count; i++) {
				if(_modifiers[i].Attribute is T) {
					existingModifiers.Add(_modifiers[i]);
				}
			}

			if(existingModifiers.Count == 0) {
				return GetAttributeDefaultValue<T>();
			}

			float finalValue = 0f;
			float additionValue = 0f;
			float multValue = 0f;

			for(int i=0; i < existingModifiers.Count; i++) {
				if(existingModifiers[i].ModifierType == GameEnums.Modifier.ADDITION) {
					additionValue += existingModifiers[i].Attribute.Value;
				}
			}

			for(int i=0; i < existingModifiers.Count; i++) {
				if(existingModifiers[i].ModifierType == GameEnums.Modifier.PERCENTAGE) {
					multValue += existingModifiers[i].Attribute.Value;
				}
			}

			float aux = GetAttributeDefaultValue<T>() + additionValue;
			finalValue = aux + (aux*multValue);

			return finalValue;
		}
		#endregion

		#region add and get modifiers
		public void AddModifier(Modifier modifier) {
			bool canAdd = true;
			int positionId = 0;
			for(int i = 0; i < _modifiers.Count; i++) {
				if(modifier.Attribute.Name.Equals(_modifiers[i].Attribute.Name)) {
					if(modifier.ModifierType == _modifiers[i].ModifierType) {
						positionId = i;
						canAdd = false;
						break;
					}
				}
			}

			if (canAdd) {
				_modifiers.Add(modifier);
			} else {
				Modifier tmpmodifier = _modifiers[positionId];
				Attribute attr = modifier.Attribute.Clone();

				float value = tmpmodifier.Attribute.Value; //get our original value
				value += modifier.Attribute.Value; //add the new value, as went to overwrite the existing value

				attr.Init(value, tmpmodifier.Attribute.MinValue, tmpmodifier.Attribute.MaxValue, tmpmodifier.Attribute.IncreaseStep, tmpmodifier.ModifierType);
				Modifier mod = new Modifier(tmpmodifier.Id, tmpmodifier.ModifierType, attr);
				_modifiers[positionId] = mod;
			}
		}

		public Modifier GetModifier<T>() {
			for(int i = 0; i < _modifiers.Count; i++) {
				if(_modifiers[i].Attribute is T) {
					return _modifiers[i];
				}
			}
			return null;
		}
		#endregion

		#region remove modifiers
		public void RemoveModifier(Modifier aModifier) {
			for(int i=_modifiers.Count - 1; i > -1; i--) {
				if(_modifiers[i]== aModifier) {
					_modifiers.RemoveAt(i);
					break;
				}
			}
		}

		public void RemoveModifier(uint id) {
			for(int i=_modifiers.Count - 1; i > -1; i--) {
				if(_modifiers[i].Id== id) {
					_modifiers.RemoveAt(i);
					break;
				}
			}
		}
		#endregion


	}
}

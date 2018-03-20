using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttributesSystem.attributes;

public class Player : MonoBehaviour {

	public float _ExampleAttribute = 0f;
	// Use this for initialization
	void Start () {
		List<AttributesSystem.attributes.Attribute> attributes = new List<AttributesSystem.attributes.Attribute>();
		PlayerData pData = new PlayerData();
		
		ExampleAttribute atex = new ExampleAttribute();
		atex.Init(1, 1, 100, 1, GameEnums.Modifier.ADDITION);
		attributes.Add(atex);
		
		pData.Init(1, attributes);

		ExampleAttribute atexModifier = new ExampleAttribute();
		atexModifier.Init(2, 2, 2, 1, GameEnums.Modifier.ADDITION);

		Modifier _m = new Modifier(1, GameEnums.Modifier.ADDITION, atexModifier);
		pData.AddModifier(_m);

		_ExampleAttribute = pData.GetAttributeTotalValue<ExampleAttribute>();
	}
}

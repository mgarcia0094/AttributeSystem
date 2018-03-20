using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttributesSystem.attributes;

public class Player : MonoBehaviour {

	public float _ExampleAttribute = 0f;
	// Use this for initialization
	void Start () {
		List<AttributesSystem.attributes.Attribute> attributes = new List<AttributesSystem.attributes.Attribute>();
		List<AttributesSystem.attributes.Modifier> modifiers = new List<AttributesSystem.attributes.Modifier>();

		PlayerData pData = new PlayerData();
		ExampleAttribute atex = new ExampleAttribute();
		atex.Init(1, 1, 100, 1, GameEnums.Modifier.ADDITION);
		
		ExampleAttribute atexModifier = new ExampleAttribute();
		atexModifier.Init(2, 2, 2, 1, GameEnums.Modifier.ADDITION);

		Modifier _m = new Modifier(1, GameEnums.Modifier.ADDITION, atexModifier);

		attributes.Add(atex);
		modifiers.Add(_m);
		pData.Init(1, attributes);
		pData.AddModifier(_m);

		_ExampleAttribute = pData.GetAttribute<ExampleAttribute>(ref modifiers);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

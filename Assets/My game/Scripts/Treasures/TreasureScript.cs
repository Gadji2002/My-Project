using System.Collections;
using System.Collections.Generic;
using UnityEngine;

delegate void TreasureAction(GameObject ship);

public class TreasureScript : MonoBehaviour
{

	public static TreasureScript instance;

	public enum TreasureStates { Heal, Bomb }

	public TreasureStates treasureState = TreasureStates.Heal;

    public Color[] stateColors;

	private TreasureAction[] allActions = { Heal, Bomb };

    void Awake()
    {
        instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ship"))
        {
			allActions[(int)treasureState](other.gameObject);
            //gameObject.GetComponent<MeshRenderer>().enabled = false;
            //gameObject.GetComponent<BoxCollider>().enabled = false;
			Destroy (gameObject);
        }
		if (other.gameObject.CompareTag("Treasure"))
        {
           Destroy(other.gameObject);
        }

		if (other.gameObject.CompareTag("Map"))
		{
			Destroy(other.gameObject);
		}
    }

    private static void Heal(GameObject ship)
    {
        ChangeHealth(ship, true);
    }


    private static void Bomb(GameObject ship)
    {
        ChangeHealth(ship, false);
    }

    private static void ChangeHealth(GameObject ship, bool positive)
    {
        ShipHealth shipHealth = ship.GetComponent<ShipHealth>();
        if (shipHealth != null)
        {
            float halfHealth = shipHealth.startingHealth / 2;
            if (positive)
                halfHealth = -halfHealth;
            shipHealth.TakeDamage(halfHealth);

        } 
    }

    public void ChooseRandomState()
    {
        int stateNumber = Random.Range(0,
			System.Enum.GetNames(typeof(TreasureStates)).Length);
		treasureState = (TreasureStates)stateNumber;
        ChooseColor(); 
    }

    public void ChooseColor()
    {
		Color treasureColor = stateColors[(int)treasureState];
		Material treasureMaterial = GetComponent<Renderer>().material;
		treasureMaterial.color = treasureColor;
		treasureMaterial.SetColor("_EmissionColor", treasureColor);
    }


}

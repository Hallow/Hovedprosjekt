using UnityEngine;
using System.Collections;


/// <summary>
/// Unit script.
/// </summary>



public class UnitScript : MonoBehaviour
{
    public int Health { get; set; }		// The health of the unit.
    public float Speed; // The movement speed of the unit.
    public float Damage { get; set; }  // The damage the unit can afflict upon buildings.
    public bool IsAlive; // Keeps track of the unit's life status.

    public float AttackSpeed { get; set; }  // The attack speed of the unit.

    public int Type; // Keeps track of the unit's type.

    public bool IsSlowed;	// Is true if the unit have been hit by a slowing tower.
    public float slowedTime = 10.0f;	// The time the unit is slowed down.

    public int Path { get; set; }   // The path for the unit to walk.

    private float timeSinceLastHit;
    private RadiusScript radius;

    public int owner;

    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<Waypoint2Script>().speed = Speed;	// Sets the speed of unit in waypoint.
        IsAlive = true;
        radius = gameObject.GetComponentInChildren<RadiusScript>();
    }

    // Update is called once per frame	
    void Update()
    {
        timeSinceLastHit += Time.deltaTime;
        /* //Removed this section because the radius script for units havent been created yet.
        if (radius.killList.Count > 0 && timeSinceLastHit > 1)
        {
            if (radius.killList[0])
            {
                GameObject toKill = radius.killList[0];
                BuildingScript building = toKill.GetComponent<BuildingScript>();

                timeSinceLastHit = 0;

                building.Hurt(this.Damage);
            }
        }
        */
        if (IsSlowed)
        {
            gameObject.GetComponent<Waypoint2Script>().SetUnitSpeed(this.Speed);	// Letting the waypoint know the speed of the unit.

            if (slowedTime < 0)
            {	// The timer runs out.
                IsSlowed = false;
                SetSpeed(this.Speed * 10.0f);
            }
            slowedTime -= (float)Time.deltaTime;
        }
    }

    public void Initialize(int health, float speed, float damage, int type, int owner, float attackSpeed)
    {
        this.Health = health;
        this.Speed = speed;
        this.Damage = damage;
        this.Type = type;
        this.owner = owner;
        this.AttackSpeed = attackSpeed;
    }

    public void SetPath(int path)
    {
        gameObject.GetComponent<Waypoint2Script>().Path = path;
    }

    // Sets the speed of the unit.
    public void SetSpeed(float speed)
    {
        this.Speed = speed;
    }

    // Returns the current health of the unit.
    public int GetHealth()
    {
        return Health;
    }

    // Returns the speed of the unit.
    public float GetSpeed()
    {
        return Speed;
    }

    // Returns true/false to determine if the unit is alive.
    public bool GetAlive()
    {
        return IsAlive;
    }

    // Attacks other unit/building.
    public void Attack()
    {
        // TODO: Write code for attacking other units/buildings.
    }

    // Slows down the speed
    public void SlowDown()
    {
        if (!IsSlowed)
        {
            SetSpeed(this.Speed / 10.0f);
            gameObject.GetComponent<Waypoint2Script>().SetUnitSpeed(this.Speed);

            this.IsSlowed = true;
        }
        this.IsSlowed = true;
        this.slowedTime = 5.0f;
    }

    // Hurts the unit (Called from projectile).
    public void Hurt(float damage)
    {
        Health -= (int)damage;

        if (Health <= 0)
        {
            this.IsAlive = false;
            Destroy(gameObject);
        }
    }

    // For collision with particles.
    void OnParticleCollision()
    {
        Hurt(2.0f);
    }
}

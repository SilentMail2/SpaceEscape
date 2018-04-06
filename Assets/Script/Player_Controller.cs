using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;
public class Player_Controller : MonoBehaviour {
    public float player_Speed = 10f;
    public float yRotation = 45.0f;
    public float health = 100f;
    public float fuel = 200f;
    public float MaxHealth;
    public float MaxFuel;
    public Slider healthBar;
    public Slider fuelBar;
    public Text score;
    public GameObject Add;
    public Text highscoreText;
    public float Score = 0;
    public float highscore = 0;
    //public Component Monster = GetComponent<Enemy_Controller>();
    Rigidbody PlayerBody;
    public float movementDir;
    public GameObject player;
    public GameObject gun;
    public GameObject projectile;
    public GameObject highscoreObject;
    public bool boostMode = false;
    public float boosttime;
    // Use this for initialization
    void Start() {
        gun = GameObject.FindGameObjectWithTag("Player Gun");
        PlayerBody = GetComponent<Rigidbody>();
        MaxHealth = health;
        MaxFuel = fuel;
        healthBar.value = CalculateHealth();
        score.text = Score.ToString();
        highscoreObject.SetActive(false);
    }
    // Update is called once per frame
    void Update() {
        //movementDir = CrossPlatformInputManager.GetAxis ("Vertical");
        PlayerBody.velocity = new Vector3(0, movementDir * player_Speed, 0);
        //var y = movementDir * Time.deltaTime * player_Speed;
        /*if (y < 0) {
			transform.eulerAngles = new Vector3 (0, 180, yRotation);
		}
		if (y == 0) {
			transform.eulerAngles = new Vector3 (0, 180, 0);
		}
		if (y > 0) {
			transform.eulerAngles = new Vector3 (0, 180, -yRotation);
		}*/
        if (boostMode) {
            Score = Score + 8 * Time.deltaTime;
            boosttime = boosttime + Time.deltaTime - 0.1f;
            if (boosttime <= 0) {
                boostMode = false;
                boosttime = 20;
            }
        }
        if (!boostMode) {
            Score = Score + 3 * Time.deltaTime;
        }
        score.text = Score.ToString("F0");
        //		transform.Translate (0, y, 0);
        if (Input.GetKeyDown("a")) {
            FireLaser();
        }
        fuel = (fuel - (1 / (health / 100)));
        fuelBar.value = CalculateFuel();
        healthBar.value = CalculateHealth();
        if (fuel <= 0) {
            TakeDamage(99999);
        }
        if (health <= 0) {
            Add.SetActive(true);
            highscoreObject.SetActive(true);
            if (Score > highscore)
            {
                highscore = Score;
                highscoreText.text = highscore.ToString("F0");
            }
            Destroy(this.gameObject);
            Debug.Log("Game Over");
        }
    }
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy") {
            TakeDamage(10);
        }
        if (other.gameObject.tag == "Health") {
            TakeDamage(-5);
        }
        if (other.gameObject.tag == "Fuel") {
            GiveFuel(50);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boost") {
            //MonsterControl.BoostMode = true;
            boostMode = true;
        }
    }
    public void FireLaser()
    {
        Instantiate(projectile, gun.transform.position, gun.transform.rotation);
    }
    public void OnPointerDownUp()
    {
        movementDir = 1;
    }
    public void OnPointerDownDown()
    {
        movementDir = -1;
    }
    public void OnPointerUp()
    {
        movementDir = 0;
    }
    public void TakeDamage(float DamageValue)
    {
        if (!boostMode) {
            health = health - DamageValue;
        }
    }
    public void GiveFuel(float FuelGained)
    {
        fuel = fuel + FuelGained;
    }
    float CalculateHealth()
    {
        return health / MaxHealth;
    }
    float CalculateFuel()
    {
        return fuel / MaxFuel;
    }
    public void DieScript()
    {
        Add.SetActive(true);
        highscoreObject.SetActive(true);
        if (Score > highscore)
        {
            highscore = Score;
            highscoreText.text = highscore.ToString("F0");
        }
        Destroy(this.gameObject);
        Debug.Log("Game Over");
    }
}
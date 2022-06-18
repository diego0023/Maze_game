using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int keys = 0;
    static public float speed = 5.0f;
    public GameObject door;
    public AudioSource Recogito;
    public Text KeyAmount;
    public Text YouWin;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate( -speed * Time.deltaTime, 0 ,0 );
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate( speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate( 0 , speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate( 0, -speed * Time.deltaTime, 0);
        }

        if ( keys == 3)
        {
            Destroy(door);
        } 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Coleccionables
        if (collision.gameObject.tag == "Keys")
        {
            // elimina el objeto con el que coliciono
            keys++;
            KeyAmount.text = "Keys: " + keys;
            Recogito.Play();
            Destroy(collision.gameObject);
        }
        // Cofre
        if (collision.gameObject.tag == "Chest" )
        {
            // elimina el objeto con el que coliciono
            

            StartCoroutine(ShowMessage(2));

            
        }
        // enemigos
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        // Limites (paredes)
        if ( collision.gameObject.tag == "Walls")
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(0, -speed * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(0, speed * Time.deltaTime, 0);
            }
        } 
    }

    IEnumerator ShowMessage(float delay)
    {
        YouWin.text = "!!GANASTE!!";
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("mainMenu");
    }

}



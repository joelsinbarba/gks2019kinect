using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
	
	protected bool letPlay = true;
    protected int i = 0;
	
	public float moveSpeed;
	public ParticleSystem  testParticulas; 
	public List<ParticleSystem> listaParticulas;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 10f;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
		transform.Translate(moveSpeed*Input.GetAxis("Horizontal")*Time.deltaTime,0f,moveSpeed*Input.GetAxis("Vertical")*Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
        }
        cambiarEmisor();
        /*
		if(Input.GetKeyDown(KeyCode.E))
        {
            letPlay = !letPlay;
        }
		if(letPlay)
        {
            if(!testParticulas.GetComponent<ParticleSystem>().isPlaying)
            {
                testParticulas.Play();
            }
			else{
				if(testParticulas.GetComponent<ParticleSystem>().isPlaying)
				{
					testParticulas.Stop();
				}
			}
        } */
    }

    void cambiarEmisor()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // letPlay = !letPlay;
            listaParticulas[i].Stop();
            i++;
            if (i == listaParticulas.Count)
            {
                i = 0;
            }
            listaParticulas[i].Play();
        }
        if (letPlay)
        {
            
        }
    }
}


using UnityEngine;
using UnityEngine.UI;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine.Events;

public class script1 : MonoBehaviour,  IMixedRealityFocusHandler, IMixedRealityPointerHandler, IMixedRealityBaseInputHandler
{

    //USIAMO i come CONTATORE CHE SEGNA IL TEMPO ...
    int i = 0;
    int n_cubi = 2;
    // offset motori millennium per luce
    int mm_offset_x = - 50;
    int mm_offset_y = -15;
    int mm_offset_z = 20;
    public float zoom_avanti, zoom_indietro;
    public float camera_des_sin, camera_su_giu, zoom;

    public float lim_sin, lim_des, lim_avanti, lim_indietro;
    public Vector2 startPos;
    public Vector2 endPos;
    public Vector3 movmil, moventerp, movrob, offset, mov_mot_mil;
    public Text istruzioni,  testo;  //contatore;
    public AudioSource suono;

    public GameObject cubetto1, cubetto2, vittoria, millennium, enterprise, sole, robotic_arm, terrazza1, motori_millennium;
    public GameObject turbina1, turbina2;
    public bool c1, c2, finito = false;

    public bool fingerHold = false;


    void IMixedRealityFocusHandler.OnFocusEnter(FocusEventData eventData)
    {
        Debug.Log("-------------------- OnFocusEnter -------------------");
        //eventData.NewFocusedObject.transform.Rotate(Vector3.up * Time.deltaTime * 100.0f);
       // transform.Rotate(Vector3.up * Time.deltaTime * 45.0f);

    }

    void IMixedRealityFocusHandler.OnFocusExit(FocusEventData eventData)
    {
        Debug.Log("-------------------- OnFocusExit -------------------");
    }

    void IMixedRealityPointerHandler.OnPointerDown(MixedRealityPointerEventData eventData)
    {

 
        Debug.Log("-------------------- OnPointerDown -------------------");


    }

    void IMixedRealityPointerHandler.OnPointerDragged(MixedRealityPointerEventData eventData)
    {
        Debug.Log("-------------------- OnPointerDragged -------------------");
        transform.Rotate(Vector3.up * Time.deltaTime * 45.0f);


    }

    void IMixedRealityPointerHandler.OnPointerClicked(MixedRealityPointerEventData eventData)
    {

    }

    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {
        if (eventData.Equals(terrazza1))
        {
            Debug.Log("-------------------- terrazza1 cliccata -------------------");
            terrazza1.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
        }
    }



    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {

    }

    void OnCollisionEnter()  //Plays Sound Whenever collision detected
    {
        GetComponent<AudioSource>().Play();
    }



    void Segui_Millennium()
    {
        
        mov_mot_mil.x = movmil.x + mm_offset_x;
        mov_mot_mil.y = movmil.y + mm_offset_y;
        mov_mot_mil.z = movmil.z + mm_offset_z;
        motori_millennium.transform.position = mov_mot_mil;
        
    }

    void Start () {
        //Camera.main.transform.position = new Vector3(5.66f, 5.89f, -12.04f);
        zoom_avanti = -12.04f;
        zoom_indietro = -12.04f;
        zoom = -12.0f;
        camera_su_giu = 5.0f;
        camera_des_sin = 5.0f;
        lim_sin = -10;      //coord x in vector3
        lim_des = 200;      //coord x
        lim_avanti = 500;   //coord z
        lim_indietro = -200;//coord z
        c1 = true;
        c2 = true;
        vittoria.SetActive(false);
        //millennium.SetActive(true);
        //enterprise.SetActive(true);
        movmil.x = millennium.transform.position.x;
        movmil.y = millennium.transform.position.y;
        movmil.z = millennium.transform.position.z;
        moventerp.x = enterprise.transform.position.x;
        moventerp.y = enterprise.transform.position.y;
        moventerp.z = enterprise.transform.position.z;
        movrob.x = robotic_arm.transform.position.x;
        movrob.y = robotic_arm.transform.position.y;
        movrob.z = robotic_arm.transform.position.z;
        motori_millennium.SetActive(false);
        //Segui_Millennium();
        suono = GameObject.FindObjectOfType<AudioSource>();    
    }
	


	// Update is called once per frame
	void Update () {
       // if (!finito)
        {

           // i = i + (int)Time.deltaTime * 60;
            i++;
            // contatore.text = i / 10 + " ";
        }
        //ROTAZIONE Sole
        sole.transform.Rotate(Vector3.down * Time.deltaTime * 20.0f);

        //MOVIMENTO e ROTAZIONE Millennium
        if (i < 200)
        {
            millennium.transform.RotateAround(Vector3.zero, new Vector3(0, 1, 0), 25 * Time.deltaTime);
          //  motori_millennium.transform.RotateAround(Vector3.zero, new Vector3(0, 1, 0), 25 * Time.deltaTime);
            movmil.z += 5f * Time.deltaTime;
            movmil.x -= 15f * Time.deltaTime;
            movmil.y += 3f * Time.deltaTime;
            millennium.transform.position = movmil;
         //   Segui_Millennium();


        }
        if (i > 199 && i<300)
        {
            millennium.transform.RotateAround(GameObject.Find("millennium").transform.position, new Vector3(0, 0, 1), -10 * Time.deltaTime);
            millennium.transform.RotateAround(GameObject.Find("millennium").transform.position, new Vector3(1, 0, 0), -10 * Time.deltaTime);
          //  motori_millennium.transform.RotateAround(GameObject.Find("motori_millennium").transform.position, new Vector3(0, 1, 0), 10 * Time.deltaTime);
          //  motori_millennium.transform.RotateAround(GameObject.Find("motori_millennium").transform.position, new Vector3(1, 0, 0), -10 * Time.deltaTime);
           
        }
        if (i > 299 && i<450)
        {
            movmil.z -= 5f * Time.deltaTime;
            movmil.x -= 5f * Time.deltaTime;
            movmil.y += 3f * Time.deltaTime;
            millennium.transform.position = movmil;
          //  Segui_Millennium();
            
        }

        if (i > 449 && i < 950)
        {
            millennium.transform.RotateAround(GameObject.Find("millennium").transform.position, new Vector3(0, 1, 0), -10 * Time.deltaTime);
            //millennium.transform.RotateAround(GameObject.Find("millennium").transform.position, new Vector3(0, 0, 1), -10 * Time.deltaTime);

            // motori_millennium.transform.RotateAround(GameObject.Find("motori_millennium").transform.position, new Vector3(1, 0, 0), -10 * Time.deltaTime);
        }

        if (i > 949)
        {

            movmil.z -= 20f * Time.deltaTime;
            movmil.x += 2f * Time.deltaTime;
            movmil.y += 1f * Time.deltaTime;
            millennium.transform.position = movmil;
            motori_millennium.SetActive(true);
            Segui_Millennium();
        }


        //MOVIMENTO e ROTAZIONE Enterprise
        if (i < 120)
        {
            //enterprise.transform.RotateAround(Vector3.zero, Vector3.up, -15 * Time.deltaTime);
            enterprise.transform.RotateAround(Vector3.zero, new Vector3(1, 0, 0), 15 * Time.deltaTime);
            moventerp.z -= 30f * Time.deltaTime * Time.deltaTime - 10 * Time.deltaTime;
            moventerp.x += 10f * Time.deltaTime;
            moventerp.y += 2f * Time.deltaTime;
        }

        if (i > 119 && i<300)
        {
            enterprise.transform.RotateAround(Vector3.zero, new Vector3(0, 1, 0), 20 * Time.deltaTime);
            //moventerp.z -= 2f * Time.deltaTime;
            moventerp.x += 40f * Time.deltaTime;
            //moventerp.y += 1f * Time.deltaTime;
        }
        if (i > 299)
        {
            moventerp.z -= 10f * Time.deltaTime*i/150;
            moventerp.x += 62f * Time.deltaTime;
            moventerp.y += 1f * Time.deltaTime;
            enterprise.transform.RotateAround(Vector3.zero, new Vector3(0, 1, 0), 2 * Time.deltaTime);
        }


        enterprise.transform.position = moventerp;

        if (i>2000)
        {
            movrob.z -= 25f * Time.deltaTime;
            robotic_arm.transform.position = movrob;
        }

        //ROTAZIONE Turbina1
        turbina1.transform.Rotate(Vector3.down * Time.deltaTime * 40f);
        //ROTAZIONE Turbina2
        turbina2.transform.Rotate(Vector3.down * Time.deltaTime * 40f);

        // VISUALIZZAZIONE testo istruzioni
        if (movmil.x < -250.0f)
        {
            istruzioni.text = "";

        }

        if (c1 && cubetto1.transform.position.x<lim_sin)
		{ 
			Debug.Log("Cubo1 caduto");
			n_cubi--;
			c1=false;
		}
		if (c2 && cubetto2.transform.position.x<lim_sin)
		{ 
			Debug.Log("Cubo2 caduto");
			n_cubi--;
			c2=false;
		}

		i++;

        /*
		if (Input.GetKey(KeyCode.UpArrow) && transform.position.z < lim_avanti)
		{ 
			//Debug.Log("avanti; z=");
			//Debug.Log(transform.position.z);
			transform.Translate(Vector3.back * Time.deltaTime * 10); 
		}

		if (Input.GetKey(KeyCode.DownArrow)&& transform.position.z > lim_indietro)
		{ transform.Translate(Vector3.forward * Time.deltaTime * 10); }

		if (Input.GetKey(KeyCode.LeftArrow)&& transform.position.x > lim_sin)
		{ 
			Debug.Log("left");
			transform.Translate(Vector3.right * Time.deltaTime * 10); 
		}

		if (Input.GetKey(KeyCode.RightArrow)&& transform.position.x < lim_des)
		{ 
			Debug.Log("right");
			transform.Translate(Vector3.left * Time.deltaTime * 10); 
		}
		
		// **************** ZOOM INDIETRO *********************
		if (Input.GetKey(KeyCode.DownArrow)&& transform.position.z < 1.0f)
		{ 
			// zoom
			Debug.Log("zOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOm");
			zoom_indietro=zoom_indietro-0.2f;
			Camera.main.transform.position = new Vector3(5.66f, 5.89f, zoom_indietro);
		}	
				// **************** ZOOM AVANTI *********************
		if (Input.GetKey(KeyCode.UpArrow)&& transform.position.z > 49.0f)
		{ 
			// zoom
			Debug.Log("zOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOm");
			zoom_avanti=zoom_avanti+0.2f;
			Camera.main.transform.position = new Vector3(5.66f, 5.89f, zoom_avanti);
		}

		if(Input.touchCount > 0){                      
			Touch touch = Input.GetTouch(0);
			if(touch.phase == TouchPhase.Began){       
				startPos = touch.position;             
				fingerHold = true;
			}
			else if(touch.phase == TouchPhase.Moved){  
				endPos = touch.position;               
			}
			else if(touch.phase == TouchPhase.Ended){  
				fingerHold = false;                    
			}
		}

		if(fingerHold){
			float deltaX = endPos.x - startPos.x; 
//************ deltaY nel piano cartesiano normale: qui sarebbe deltaZ *********			
			float deltaY = endPos.y - startPos.y; 
			
			bool horizontal = false;

			if(Mathf.Abs (deltaX) > Mathf.Abs (deltaY)) 
				horizontal = true;                      

			if(horizontal)
			{ // destra-sinistra
				if(deltaX < 0 && transform.position.x > lim_sin)
					transform.Translate(Vector3.right * Time.deltaTime * 10);
				else if(deltaX > 0 && transform.position.x < lim_des)
					transform.Translate(Vector3.left * Time.deltaTime * 10);
			}
			else
			{    // avanti-indietro
				if(deltaY < 0 && transform.position.z > lim_indietro)
					transform.Translate(Vector3.forward * Time.deltaTime * 10);
				else if(deltaY > 0 && transform.position.z < lim_avanti)
					transform.Translate(Vector3.back * Time.deltaTime * 10);
					// **************** ZOOM INDIETRO *********************
				if (deltaY < 0 && transform.position.z <  1.0f)
				{ 
					// zoom
					Debug.Log("zOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOm");
					zoom_indietro=zoom_indietro-0.2f;
					Camera.main.transform.position = new Vector3(5.66f, 5.89f, zoom_indietro);
				}	
				// **************** ZOOM AVANTI *********************
				if (deltaY > 0 && transform.position.z  > 49.0f)
				{ 
					// zoom
					Debug.Log("zOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOm");
					zoom_avanti=zoom_avanti+0.2f;
					Camera.main.transform.position = new Vector3(5.66f, 5.89f, zoom_avanti);
				}
			}
		}
        */
			
		if (n_cubi==0)
		{
			//vinto
			vittoria.SetActive(true);
		}
        if (movmil.x < -100.0f)
            testo.text = "";

    }


}

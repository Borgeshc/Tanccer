using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class ArduinoSerial : MonoBehaviour {
    public GameObject player1Tank;
    public GameObject player2Tank;
    public GameObject gunBarrelp1;
    public GameObject gunBarrelp2;

    public int sliderMin = 30;
    public int sliderMax = 980;

    Movement movementp1;
    Movement movementp2;
    Shooting shootingp1;
    Shooting shootingp2;
    public string comPort;
    SerialPort stream;
    string serialString;

    int p1OldShoot = 0;
    int p2OldShoot = 0;

	void Start () {
        movementp1 = player1Tank.GetComponent<Movement>();
        movementp2 = player2Tank.GetComponent<Movement>();
        shootingp1 = gunBarrelp1.GetComponent<Shooting>();
        shootingp2 = gunBarrelp2.GetComponent<Shooting>();

        comPort = "COM" + comPort;
        try
        {
            stream = new SerialPort(comPort, 9600);
            stream.Open();
            Debug.Log("Stream Open on " + comPort);
        }
        catch
        {
            Debug.Log("No Microcontroller on " + comPort);
        }
    }
    void Update() {
	    UpdateCurrentValues();
    }
    void OnDestroy() {

    }
    void UpdateCurrentValues() {
        if (stream.IsOpen)
        {
            serialString = "";
            bool stringNotComplete = true;
            while (stringNotComplete)
            {
                char inChar = (char)stream.ReadByte();
                if (inChar == '\n')
                {
                    stringNotComplete = false;
                    MessageParse();
                }
                serialString += inChar;

            }
        }
    }
    public void MessageParse(){  //Do stuff with message here. 
                                 //print(serialString +"   " +serialString.Length );
        if (serialString.Length > 1)
        {
            string[] input = serialString.Split(',');
            //------player 1 position value-----
            float p1SliderValue = float.Parse(input[0]);
            p1SliderValue = Mathf.Clamp(p1SliderValue, sliderMin, sliderMax);
            p1SliderValue -= sliderMin;
            p1SliderValue = p1SliderValue / (sliderMax - sliderMin);
            movementp1.positionValue = (p1SliderValue * Screen.height);

            //------player 1 shooting------------
            int p1ButtonValue = int.Parse(input[1]);
            if (p1OldShoot != p1ButtonValue)
            {
                if(p1ButtonValue == 1)
                    shootingp1.Shoot(); 
                p1OldShoot = p1ButtonValue;
            }
            
                

            //------player 2 position value------
            float p2SliderValue = float.Parse(input[2]);
            p2SliderValue = Mathf.Clamp(p2SliderValue, sliderMin, sliderMax);
            p2SliderValue -= sliderMin;
            p2SliderValue = p2SliderValue / (sliderMax - sliderMin);
            movementp2.positionValue = (p2SliderValue * Screen.height);

            //------player 2 shooting------------
            int p2ButtonValue = int.Parse(input[3]);
            if (p2OldShoot != p2ButtonValue)
            {
                if (p2ButtonValue == 1)
                    shootingp2.Shoot();
                p2OldShoot = p2ButtonValue;
            }

            //loop through array, switch statement to determine who shoots
            //if(serialString[0] == '1')

        }
    }

    // This is for communication back to the arduino. Known as ack.
    /*  public void PinOn(int pin) {
           if (stream.IsOpen) {
               switch (pin) {
                   case 23: //$5
                       stream.Write("A");
                       break;
                   case 22: //$10
                       stream.Write("B");
                       break;
                   case 21: //$20
                       stream.Write("C");
                       break;
                   case 20: //$Card
                       stream.Write("D");
                       break;
               }
           }
       } 
       public void PinOff() {
           if (stream != null) { 
           if (stream.IsOpen) {
               stream.Write("E");
           }}
       }
       */
}

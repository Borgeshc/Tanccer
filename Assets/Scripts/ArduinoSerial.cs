using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class ArduinoSerial : MonoBehaviour {
    public GameObject gunBarrel;
    Shooting shooting;
    public string comPort;
    SerialPort stream;
    string serialString;

	void Start () {

        shooting = gunBarrel.GetComponent<Shooting>();

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
         print(serialString +"   " +serialString.Length );
        if (serialString.Length > 1)
        {
            //loop through array, switch statement to determine who shoots
            if(serialString[0] == '1')
            shooting.Shoot();
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

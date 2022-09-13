using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
	int a=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	a++;
		Transform myTransform = this.transform;
		Vector3 pos = myTransform.position;
		if(a%120<60){pos.x=-2f+(a%120)/15f;}
		if(a%120>=60){pos.x=6f-(a%120)/15f;}
//		Debug.Log(pos);
		myTransform.position=pos;
    }
}

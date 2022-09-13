using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud : MonoBehaviour
{
	int itemp1=0;
	public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		Transform myTransform = this.transform;
		Vector3 pos = myTransform.position;
		if(pos.z<-10f){itemp1++;}
		else{itemp1=0;}
		Transform PlayerTrans = player.transform;
		Vector3 PlayerPos = PlayerTrans.position;
		if(itemp1>=360&&(PlayerPos.x<pos.x-0.75f||PlayerPos.x>pos.x+0.75f||PlayerPos.y<pos.y-0.75f||PlayerPos.y>pos.y+0.75f)){
			pos.z=0;
		}
		myTransform.position=pos;
    }
}

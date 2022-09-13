using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
	public GameObject player;
	public GameObject death;
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		Transform myTransform = this.transform;
		Vector3 pos = myTransform.position;
		Transform PlayerTrans = player.transform;
		Vector3 PlayerPos = PlayerTrans.position;
//		Transform deathTrans = death.transform;
//		Vector3 deathPos = deathTrans.position;
		if(PlayerPos.y<-8f){pos.y=-8f;}
		else if(PlayerPos.y>16f){pos.y=16f;}
		else{pos.y=PlayerPos.y;}
//		deathPos.x=pos.x;
//		deathPos.y=pos.y+8.0f;
		myTransform.position=pos;
//		deathTrans.position=deathPos;
	}
}

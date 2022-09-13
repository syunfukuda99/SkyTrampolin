using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	float ftemp1;
	public GameObject camera;
	public GameObject dance;
	public GameObject clear;
	public GameObject death;
	int stage=0;
	int flag=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		Transform myTransform = this.transform;
		Vector3 pos = myTransform.position;
		Rigidbody rigid = this.GetComponent<Rigidbody>();
		Vector3 vel = rigid.velocity;
		if(flag>0){flag++;}
		if(flag>=120){
			flag=0;
			stage++;
			Transform danceTrans = dance.transform;
			Vector3 dancePos = danceTrans.position;
			dancePos.z=2;
			Transform cameraTrans = camera.transform;
			Vector3 cameraPos = cameraTrans.position;
			pos.x=stage*10f-2;
			pos.y=-8f;
			pos.z=0;
			vel.x=0;
			vel.y=0;
			cameraPos.x=stage*10f;
			cameraPos.y=-8f;
			myTransform.position=pos;
			cameraTrans.position=cameraPos;
			rigid.velocity=vel;
		}
		if(flag<0){
			flag--;
			Transform deathTrans = death.transform;
			Vector3 deathPos = deathTrans.position;
			deathPos.x=pos.x;
			deathPos.y=pos.y+1f;
			deathPos.z=pos.z;
			deathTrans.position=deathPos;
		}
		if(flag<=-60){
			flag=0;
			Transform cameraTrans = camera.transform;
			Vector3 cameraPos = cameraTrans.position;
			pos.x=stage*10f-2;
			pos.y=-8f;
			vel.x=0;
			vel.y=0;
			cameraPos.x=stage*10f;
			cameraPos.y=-8f;
			myTransform.position=pos;
			cameraTrans.position=cameraPos;
			rigid.velocity=vel;
			death.SetActive (false);
		}
	}
	void OnCollisionStay(Collision col)
	{
		Rigidbody rigid = this.GetComponent<Rigidbody>();
		Vector3 vel = rigid.velocity;
		Transform myTransform = this.transform;
		Vector3 pos = myTransform.position;
		if(col.gameObject.CompareTag("cloud")){
			GameObject cloudObj=col.gameObject;
			Transform cloudTrans = cloudObj.transform;
			Vector3 cloudPos=cloudTrans.position;
			if(pos.y>cloudPos.y){
				ftemp1=Mathf.Atan2((pos.y-cloudPos.y),(pos.x-cloudPos.x));
				vel.x=10.0f*Mathf.Cos(ftemp1);
				vel.y=10.0f*Mathf.Sin(ftemp1);
				cloudPos.z=-20f;
			}
			rigid.velocity=vel;
			cloudTrans.position=cloudPos;
		}
		if(col.gameObject.CompareTag("TP")){
			GameObject TPobj=col.gameObject;
			Transform TPtransform = TPobj.transform;
			Vector3 TPangle = TPtransform.eulerAngles;
			Vector3 TPsize = TPtransform.localScale;
			Vector3 TPpos = TPtransform.position;
			vel.x=50.0f*Mathf.Cos((TPangle.z+90)*Mathf.PI/180f)/(TPsize.x+1.0f);
			vel.y=50.0f*Mathf.Sin((TPangle.z+90)*Mathf.PI/180f)/(TPsize.x+1.0f);
			if(vel.y<0){
				vel.x=-vel.x;
				vel.y=-vel.y;
			}
			TPpos.z=-20.0f;
			
			TPtransform.position=TPpos;
			rigid.velocity=vel;
//			Debug.Log(TPangle); // ログを表示する
		}
		if(col.gameObject.CompareTag("Finish")){
			flag=-1;
			death.SetActive (true);
			Transform deathTrans = death.transform;
			Vector3 deathPos = deathTrans.position;
			deathPos.x=pos.x;
			deathPos.y=pos.y+1f;
			deathPos.z=pos.z;
			deathTrans.position=deathPos;
		}
		if(col.gameObject.CompareTag("Goal")){
			GameObject goalObj=col.gameObject;
			Transform goalTrans = goalObj.transform;
			Vector3 goalPos=goalTrans.position;
			if(pos.y>goalPos.y){
				pos.z=2;
				Transform danceTrans = dance.transform;
				Vector3 dancePos = danceTrans.position;
				dancePos.x=pos.x;
				dancePos.y=pos.y;
				dancePos.z=0;
				myTransform.position=pos;
				danceTrans.position=dancePos;
				flag=1;
				clear.SetActive (true);
			}
		}
	}
	void OnTriggerEnter(Collider col)
	{
		Rigidbody rigid = this.GetComponent<Rigidbody>();
		Vector3 vel = rigid.velocity;
		Transform myTransform = this.transform;
		Vector3 pos = myTransform.position;
		if(col.gameObject.CompareTag("TPblue")){
			GameObject TPobj=col.gameObject;
			Transform TPtransform = TPobj.transform;
			Vector3 TPangle = TPtransform.eulerAngles;
			Vector3 TPpos = TPtransform.position;
			vel.x=10.0f*Mathf.Cos((TPangle.z+90)*Mathf.PI/180f);
			vel.y=10.0f*Mathf.Sin((TPangle.z+90)*Mathf.PI/180f);
			if(vel.y<0){
				vel.x=-vel.x;
				vel.y=-vel.y;
			}
			
			TPtransform.position=TPpos;
			rigid.velocity=vel;
//			Debug.Log(TPangle); // ログを表示する
		}
		if(col.gameObject.CompareTag("TPred")){
			GameObject TPobj=col.gameObject;
			Transform TPtransform = TPobj.transform;
			Vector3 TPangle = TPtransform.eulerAngles;
			Vector3 TPpos = TPtransform.position;
			vel.x=50.0f*Mathf.Cos((TPangle.z+90)*Mathf.PI/180f);
			vel.y=50.0f*Mathf.Sin((TPangle.z+90)*Mathf.PI/180f);
			if(vel.y<0){
				vel.x=-vel.x;
				vel.y=-vel.y;
			}
			
			TPtransform.position=TPpos;
			rigid.velocity=vel;
//			Debug.Log(TPangle); // ログを表示する
		}
	}
}

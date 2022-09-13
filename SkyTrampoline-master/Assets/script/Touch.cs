using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
	private Vector3 touch_point;
	private Vector3 touch_point2;
	private int flag=0;
	int[] TPflag = new int[3];
	int itemp1;
	int itemp2;
	public GameObject[] gameobject=new GameObject[3];
	public GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
    	for(int i=0;i<3;i++){
    		TPflag[i]=0;
    	}
    }

    // Update is called once per frame
    void Update()
	{
		Transform myTransform = this.transform;
		Vector3 pos = myTransform.position;
		Vector3 size = myTransform.localScale;
		Vector3 angle = myTransform.eulerAngles;
		for(int i=0;i<3;i++){
			Transform TPtransform = gameobject[i].transform;
			Vector3 TPpos = TPtransform.position;
			if(TPpos.z>-10f){TPflag[i]++;}
			else{TPflag[i]=0;}
		}
//        Debug.Log("Screen Width : " + Screen.width);
//        Debug.Log("Screen  height: " + Screen.height);

//		Debug.Log(TPflag[0]);
//		Debug.Log(TPflag[1]);
//		Debug.Log(TPflag[2]);


		if (Input.GetMouseButton(0)) {
			if(flag==0){touch_point=Input.mousePosition;}
			flag=1;
			Transform cameraTrans = camera.transform;
			Vector3 cameraPos = cameraTrans.position;
			touch_point2=Input.mousePosition;
			pos.x=(touch_point.x+touch_point2.x)*4.5f/Screen.width -4.5f+cameraPos.x;
			pos.y=(touch_point.y+touch_point2.y)*8.0f/Screen.height-8.0f+cameraPos.y;
			pos.z=0f;
			size.x=Mathf.Sqrt((touch_point2.x-touch_point.x)*(touch_point2.x-touch_point.x)+(touch_point2.y-touch_point.y)*(touch_point2.y-touch_point.y))/80.0f;
			angle.z=Mathf.Atan2((touch_point2.y-touch_point.y),(touch_point2.x-touch_point.x))*180/Mathf.PI;
		}
		else {
			if(flag==1){
				for(int i=0;i<3;i++){
					if(TPflag[i]==0){
						itemp1=i;
						break;
					}
					if(i==0||TPflag[i]>itemp2){
						itemp1=i;
						itemp2=TPflag[i];
					}
				}
				TPflag[itemp1]=1;
				Transform TPtransform = gameobject[itemp1].transform;
				Vector3 TPpos = TPtransform.position;
				Vector3 TPsize = TPtransform.localScale;
				Vector3 TPangle = TPtransform.eulerAngles;
				TPpos.x=pos.x;
				TPpos.y=pos.y;
				TPpos.z=pos.z;
				TPsize.x=size.x;
				TPangle.z=angle.z;
				TPtransform.position = TPpos;
				TPtransform.localScale = TPsize;
				TPtransform.eulerAngles = TPangle;
				
				pos.z=-20f;
			}
			flag=0;
		}

		myTransform.position = pos;
		myTransform.localScale = size;
		myTransform.eulerAngles = angle;
	}
}

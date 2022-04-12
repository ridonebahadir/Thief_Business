using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class Projectile : MonoBehaviour
{
	public DynamicJoystick dynamicJoystick;
	[Tooltip("Position we want to hit")]
	public Transform targetPos;

	[Tooltip("Horizontal speed, in units/sec")]
	public float speed = 10;

	[Tooltip("How high the arc should be, in units")]
	public float arcHeight = 1;


	public Transform startPos;
    private Vector3 nextPos;
	public bool throwObj;
	public bool touch;
	public Animator[] anim;
	//public Collider colliderBusiness;
	//public Collider colliderThief;
	public Transform BusinessKucak;
	public Transform ThiefKucak;
	

	
	public List<Transform> listObj;

    private void Start()
    {
		//colliderBusiness.enabled = false;
		//colliderThief.enabled = true;



		
	}
    void Update()
	{
		
        if (dynamicJoystick.Horizontal<0)
        {
			//BusinessCharacter.GetChild(0).gameObject.SetActive(false);
			//BusinessCharacter.GetChild(1).gameObject.SetActive(true);
			//ThiefCharacter.GetChild(0).gameObject.SetActive(true);
			//ThiefCharacter.GetChild(1).gameObject.SetActive(false);

			
			
			
			//colliderBusiness.enabled = true;
			//colliderThief.enabled = false;
			throwObj = true;
			touch = true;
			

		
		}
        if(dynamicJoystick.Horizontal > 0)
        {
			//BusinessCharacter.GetChild(0).gameObject.SetActive(true);
			//BusinessCharacter.GetChild(1).gameObject.SetActive(false);
			//ThiefCharacter.GetChild(0).gameObject.SetActive(false);
			//ThiefCharacter.GetChild(1).gameObject.SetActive(true);

			
			
			

			//colliderBusiness.enabled = false;
			//colliderThief.enabled = true;
			throwObj = false;
			touch = true;
		
		}
        if (touch)
        {
			foreach (var item in listObj)
			{
				item.parent = transform;
				item.localPosition = new Vector3(item.localPosition.x, 0);
			}
			if (throwObj)
			{
                //BUS�NESS
               
				startPos = BusinessKucak;
				targetPos = ThiefKucak;
				Invoke("LateBusinessThrow", 0f);
				Invoke("LateBusiness", 0.65f);
				float x0 = startPos.position.x;
				float x1 = targetPos.position.x;
				MoveOtherSide(x0, x1);
			}
			else
			{
				
				//THIEF

				startPos = ThiefKucak;
				targetPos = BusinessKucak;
				Invoke("LateThiefThrow", 0f);
				Invoke("LateThief", 0.65f);
				float x0 = startPos.position.x;
				float x1 = targetPos.position.x;
				MoveOtherSide(x0, x1);

			}
		}
        

	}
	void LateThief()
    {
		anim[1].SetBool("isCarry", false);
		
		
		

	}
	void LateThiefThrow()
	{

		anim[0].SetBool("isCarry", true);


	}
	void LateBusiness()
    {
		anim[0].SetBool("isCarry", false);
		
		
	}
	void LateBusinessThrow()
	{
		
		anim[1].SetBool("isCarry", true);

	}



	//void Arrived()
	//{
	//	Destroy(gameObject);
	//}

	/// 
	/// This is a 2D version of Quaternion.LookAt; it returns a quaternion
	/// that makes the local +X axis point in the given forward direction.
	/// 
	/// forward direction
	/// Quaternion that rotates +X to align with forward
	/// 


	void MoveOtherSide(float x0,float x1)
    {
        
		float dist = x1 - x0;
		for (int i = 0; i < listObj.Count; i++)
        {
			float nextX = Mathf.MoveTowards(listObj[i].transform.position.x, x1, (speed -  i ) * Time.deltaTime);
			float baseY = Mathf.Lerp(startPos.position.y, targetPos.position.y, (nextX - x0) / dist);
			float arc = arcHeight * (nextX - x0) * (nextX - x1) / (-0.25f * dist * dist);
			nextPos = new Vector3(nextX, baseY + arc, (listObj[i].transform.position.z));
			//objs[i].transform.rotation = LookAt2D(nextPos - transform.position);
			listObj[i].transform.position = nextPos;
		}
		
	}
	static Quaternion LookAt2D(Vector2 forward)
	{
		return Quaternion.Euler(0, 0, Mathf.Atan2(forward.y, forward.x) * Mathf.Rad2Deg);
	}
}
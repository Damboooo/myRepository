using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	//private float ySpeed=0;

	//void Start(){
//		StartCoroutine();
	//}
	private int numberOfJumps=1;
	public int numberOfCoins=0;
	float myTimer = 3;
	private bool isItSpace = true;
	private Vector2 movement;
	public ParticleSystem fireEffect;
	//private int coin;
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			if(this.gameObject.transform.position.y>=-2.1 &&this.gameObject.transform.position.y<=-1.8){
				numberOfJumps=1;
				rigidbody2D.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
			}
			else
			if(this.gameObject.transform.position.y>-1.7f && this.gameObject.transform.position.y<=-0.5f && numberOfJumps<2){
			    rigidbody2D.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
				numberOfJumps++;
			}
		}

		if (Input.GetKeyDown (KeyCode.A)) {
			isItSpace=false;
			movement = new Vector2(0,2);
			myTimer=3;
		}
		if (myTimer > 0 && !isItSpace)
			myTimer -= Time.deltaTime;
		if (myTimer <= 0 && !isItSpace) {
			movement.y = 0;
			rigidbody2D.gravityScale=0;
		}
//		if (transform.position.y.Equals(270)) {
//			movement= new Vector2(0,0);
//		}
	}
	void OnTriggerEnter2D(Collider2D otherCollider){
		Tigh myTigh = otherCollider.gameObject.GetComponent<Tigh> ();
		CoinScript myCoin = otherCollider.gameObject.GetComponent<CoinScript> ();
		BombScript myBomb = otherCollider.gameObject.GetComponent<BombScript> ();
		if (myTigh != null && myCoin==null && myBomb==null) {
			myTigh.collider2D.isTrigger=false;
			this.transform.Rotate(0,0,-90,Space.Self);
			//transform.Rotate(90,0,0,Space.Self);
		//	Destroy(myTigh.gameObject);
		}

		if (myCoin != null && myTigh == null && myBomb == null) {
			this.numberOfCoins++;
			Destroy(myCoin.gameObject);
		}
		if(myBomb!=null && myCoin == null && myTigh==null){
			SpecialEffectsHelper.Instance.Explosion(transform.position);
			Destroy(myBomb.gameObject);
			Destroy(this.gameObject);
		}
	}
	void OnGUI(){
	//	GUI.skin = skin;
		//GUI.Label (new Rect (0, 0, Screen.width, Screen.height), score.ToString ());
		GUI.Label (new Rect (500, 10, Screen.width, Screen.height), numberOfCoins.ToString());
		
	}
	void FixedUpdate(){

		if (!isItSpace) {
		
			rigidbody2D.velocity = movement;
			//yield return WaitForSeconds(3);

		//	movement.y=0;
		//	rigidbody2D.velocity=movement;
		}
		//	if (transform.position.y.Equals(70)) {
	//			movement= new Vector2(0,0);
		//	}
	//	if(Time.time>=tempTime + 3)
	//	movement.y = 0;
	}

}

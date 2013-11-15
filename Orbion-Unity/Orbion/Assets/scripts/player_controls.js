#pragma strict

var speed : float = 5.0;
var bullet_prefab : Transform;


function Update () {

	if(Input.GetKey("w"))
	transform.position.y += speed * Time.deltaTime;
	
	if(Input.GetKey("a"))
	transform.position.x -= speed * Time.deltaTime;
	
	if(Input.GetKey("s"))
	transform.position.y -= speed * Time.deltaTime;
	
	if(Input.GetKey("d"))
	transform.position.x += speed * Time.deltaTime;

	if(Input.GetMouseButtonDown(0))
	Instantiate(bullet_prefab, transform.position, Quaternion.identity);

}
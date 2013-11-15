#pragma strict


var bullet_Spd : float = 5.0;


function Start () {

}

function Update () 

{
    rotateCharacter();
}

 

function rotateCharacter()

{

    var draai:float = Mathf.Atan2(  (Input.mousePosition.y - 0.5 * Screen.height) , 

                                                (Input.mousePosition.x - 0.5 * Screen.width));
	
    draai *= Mathf.Rad2Deg;
    var diry = Mathf.Sin(draai);
    var dirx = Mathf.Cos(draai);
    
    transform.position.x += bullet_Spd * dirx;
    transform.position.y += bullet_Spd * diry;
    Debug.Log(draai);
    transform.rotation.eulerAngles.z = draai + 90;
    //transform.position. += bullet_Spd * Time.deltaTime;

}
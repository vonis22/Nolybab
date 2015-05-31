#pragma strict

 var interval: float = 2.5; // interval to update enemy list
 private var enemyList: GameObject[]; // enemy list
 
 function Start(): IEnumerator { // make Start a coroutine
   while (true){ // refresh enemy list at interval seconds:
     enemyList = GameObject.FindGameObjectsWithTag("Enemy");
     yield WaitForSeconds(interval);
   }
 }
 
 // check if some enemy is at sight: if so, returns its game object reference, else returns null
 
 function CanSeeEnemy(): GameObject {
   var here = transform.position; 
   
   for (var enemy: GameObject in enemyList){
     // if enemy not destroyed yet, and is in front the camera...
     if (enemy && enemy.GetComponent.<Renderer>().isVisible){
       // do a Linecast:
       var pos = enemy.transform.position;
       var hit: RaycastHit;
       // if nothing is obscuring the enemy...
       if (Physics.Linecast(here, pos, hit) && hit.transform == enemy.transform){
         // finish function and return its GameObject reference:
         Debug.Log("Ik zie iets");
         return enemy;
       }
     }
   }
   Debug.Log("Ik zie niets");
   return null; // if none at sight, return null
 }
 
 function Update(){
   var enemyAtSight = CanSeeEnemy(); // check if some enemy at sight
   if (enemyAtSight){
   
     // player can see the enemy, and its GameObject reference is in enemyAtSight
   }
   // other Update code, if any
 }
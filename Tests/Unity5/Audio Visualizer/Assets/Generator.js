// The generation script is needlesly complex, because I recycled it from an earlier experiment

// If you want to improve the script - you should parent all objects with the same index and only make the parents
// change their scale, instead of having all the objects do that - the performance should be better.
// ^ I didnt do that because Im lazy

import System.Linq;
import System.Collections.Generic;

var prefab : GameObject;

private var generationList = new List.<Vector2>();

var size = 25;

function Start () {

map = new boolean[size,size];

for (var x:int=0; x<size; x++){

	for (var y:int=0; y<size; y++){

	generationList.Add(Vector2(x,y));

	}

}

StartCoroutine("Generate");

}

function Generate () {

var currentVector : Vector2;

while(generationList.Count!=0){

currentVector = generationList[Random.Range(0,generationList.Count)];

GenerateTile(currentVector);
generationList.Remove(currentVector);

}

print("Generation completed");

}

function GenerateTile (vc2:Vector2) {

// change the vc2 to vc3 and move it to the center

var pos : Vector3;
pos.x = vc2.x-(size/2);
pos.z = vc2.y-(size/2);

var spawnedTile = Instantiate(prefab,pos,prefab.transform.rotation);

var distIndex :int;
distIndex = Vector3.Distance(pos,Vector3.zero)-0.25;

spawnedTile.GetComponent("SpectrumController").spectrumIndex = distIndex;

}
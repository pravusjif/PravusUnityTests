#pragma strict

class TopDownSort extends MonoBehaviour {
	var layerId:float = 0;
	var offset:Vector3;
	var basePos:Vector3;
	var zScale:float = 0.01f;  // Level units for z sort
	var zLayerScale:float = 1;
	
	private var m_Vec:Vector3;

	function Start () {
		updateBasePos();
	}
	
	function updateBasePos() {
		var bounds:GameObject = GameObject.Find("Bounds");
		if(bounds){
			basePos = bounds.transform.position;
		}
	}
	
	// Update is called once per frame
	
	function Update () {
		
		m_Vec = transform.position;
		
		m_Vec.y = (layerId*zLayerScale) - ( (basePos.z-(m_Vec.z + offset.z )) * -zScale );
		
		transform.position = m_Vec;
	}
}
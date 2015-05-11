// this script only lerps the transform's Z scale to desired scale

var desiredScale = 1.0;

function FixedUpdate () {

transform.localScale.z = Mathf.Lerp(transform.localScale.z,desiredScale,Time.deltaTime*8);

}
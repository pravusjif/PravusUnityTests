var spectrumIndex : int;
var scaleComp : Component;
var scale = 32;

function FixedUpdate () {

scaleComp.desiredScale = 1+AudioManager.spectrum[spectrumIndex]*scale;

}
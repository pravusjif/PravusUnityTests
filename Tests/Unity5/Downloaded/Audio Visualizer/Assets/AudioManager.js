// feel free to change the sampling (1024s) to 512s or 2048s.

static var spectrum = new float[1024];

function Update () {

spectrum = GetComponent.<AudioSource>().GetSpectrumData(1024, 0, FFTWindow.BlackmanHarris);

}
Shader "uniSWF/Splash/SplashShaderAlpha" {
    Properties {
        _MainTex ("Texture to blend", 2D) = "black" {}
        _Color ("Color", Color) = (1,1,1,1) 
    }
    SubShader {
        Tags { "Queue" = "Transparent" }
        Pass {
            Blend SrcAlpha OneMinusSrcAlpha
           // Use texture alpha to blend up to white (= full illumination)
            SetTexture [_MainTex] {
                // Pull the color property into this blender
                constantColor [_Color]
                // And use the texture's alpha to blend between it and
                // vertex color
                combine constant lerp(constant) constant
            }
            // Multiply in texture
            SetTexture [_MainTex] {
                combine previous * texture
            }
        }
    }
}
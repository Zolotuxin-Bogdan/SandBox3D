Shader "Custom/Skybox_Shader" {
    Properties {
        _GroundColor ("Ground Color", Color) = (0, 0, 0, 0)
        _HorizonColor ("Horizon Color", Color) = (0, 0, 0, 0)
        
        _SkyColor ("Sky Color", Color) = (1, 1, 1, 1)
        _SkyExp ("Sky Exponent", Float) = 3
        _SkyIntens ("Sky Intensity", Float) = 1

        _SunColor ("Sun Color", Color) = (0, 0, 0, 0)
        _SunRadiusA ("Sun Radius A", Range (0,0.1)) = 0.03
        _SunRadiusB ("Sun Radius B", Range (0,0.1)) = 0.05
        _SunExp ("Sun Exponent", Float) = 2
        _SunIntens ("Sun Intensity", Float) = 5

    }
    SubShader {
        // CGPROGRAM

        //     #pragma vertex vert

        //     #include "UnityCG.cginc"

        //     struct appdata {
        //         float4 vertex: POSITION;
        //     }

        //     void initialize() {
                
        //     }

        //     float4 add_(float4 A, float4 B) {
        //         return A + B;
        //     }
        //     float add_(float A, float B) {
        //         return A + B;
        //     }

        //     float4 Sky(appdata v) {
        //         float4 Out;
        //         float3 norm = normalize(WorldPosition());
        //     }
            
        //     float4 WorldPosition() {
        //         return mul(unity_ObjectToWorld, v.vertex);
        //     }


        // ENDCG
        Pass {
            Lighting On
        }
    }
}

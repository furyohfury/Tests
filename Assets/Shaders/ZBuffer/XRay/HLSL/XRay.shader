Shader "XRay"
{
    Properties
    {
        _XrayColor ("Color", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
        Tags
        {
            "RenderType" = "Opaque"
            "Queue" = "Geometry"
            "RenderPipeline" = "UniversalPipeline"
        }
        Pass
        {
            ZTest GEqual
            ZWrite Off
            
            Tags
            {
                "LightMode" = "UniversalForward"
            }
            
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            
            struct appdata
            {
                float4 positionOS : Position;
            };

            struct v2f
            {
                float4 positionCS : SV_Position;
            };
            
            CBUFFER_START(UnityPerMaterial)
            float4 _XrayColor;
            CBUFFER_END

            v2f vert(appdata v)
            {
                v2f o;
                o.positionCS = TransformObjectToHClip(v.positionOS);
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                return _XrayColor;
            }
            ENDHLSL
        }
    }
}
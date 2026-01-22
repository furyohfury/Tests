Shader "StencilShow"
{
    Properties
    {
        [IntRange] _StencilRef("StencilValue", Range(0, 255)) = 1
        _BaseColor ("Base color", Color) = (1, 1, 1, 1)
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
            Tags
            {
                "LightMode" = "UniversalForward"
            }
            
            Stencil
            {
                Ref [_StencilRef]
                Comp Equal
            }
            
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct appdata
            {
                float4 positionOS : POSITION;
            };

            struct v2f
            {
                float4 positionCS : SV_POSITION;
            };
            
            CBUFFER_START(UnityPerMaterial)
            float4 _BaseColor;
            int _StencilRef;
            CBUFFER_END
            
            v2f vert(appdata i)
            {
                v2f o;
                o.positionCS = TransformObjectToHClip(i.positionOS);
                
                return o;
            }
            
            float4 frag(v2f i) : SV_Target
            {
                return _BaseColor;
            }
            
            ENDHLSL
        }
    }
    Fallback Off
}
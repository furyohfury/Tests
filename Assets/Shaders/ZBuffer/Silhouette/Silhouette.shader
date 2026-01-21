Shader "Silhouette"
{
    Properties
    {
        _ForegroundColor ("FG Color", Color) = (0, 0, 0, 1)
        _BackgroundColor ("BG Color", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
        Tags
        {
            "RenderType" = "Transparent"
            "Queue" = "Transparent"
            "RenderPipeline" = "UniversalPipeline"
        }
        Pass
        {
            Tags
            {
                "LightMode" = "UniversalForward"
            }
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DeclareDepthTexture.hlsl"
            
            struct appdata
            {
                float4 positionOS : Position;
            };

            struct v2f
            {
                float4 positionCS : SV_POSITION;
                float4 positionSS : TEXCOORD0;
            };
            
            CBUFFER_START(UnityPerMaterial)
            float4 _ForegroundColor;
            float4 _BackgroundColor;
            CBUFFER_END

            v2f vert(appdata v)
            {
                v2f o;
                o.positionCS = TransformObjectToHClip(v.positionOS);
                o.positionSS = ComputeScreenPos(o.positionCS);
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                float2 screenUVs = i.positionSS.xy / i.positionSS.w;
                float rawDepth = tex2D(_CameraDepthTexture,
                screenUVs).r;
            }
            ENDHLSL
        }
    }
}
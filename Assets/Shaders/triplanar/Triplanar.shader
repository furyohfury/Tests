Shader "Triplanar"
{
    Properties
    {
        _BaseColor ("Base Color", Color) = (1,
        1, 1, 1)
        _BaseTex("Base Texture", 2D) = "white"
        {}
        _Tile ("Tile", Float) = 1
        _BlendPower ("BP", Float) = 10
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
            
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            
            struct appdata
            {
                float4 positionOS : Position;
                float3 normalOS : NORMAL;
            };

            struct v2f
            {
                float4 positionCS : SV_Position;
                float3 positionWS : TEXCOORD0;
                float3 normalWS : TEXCOORD1;
            };
            
            CBUFFER_START(UnityPerMaterial)
            float4 _BaseTex_ST;
            float4 _BaseColor;
            float _Tile;
            float _BlendPower;
            CBUFFER_END
            sampler2D _BaseTex;

            v2f vert(appdata v)
            {
                v2f o;
                o.positionCS = TransformObjectToHClip(v.positionOS);
                o.positionWS = TransformObjectToWorld(v.positionOS.xyz);
                o.normalWS = TransformObjectToWorldNormal(v.normalOS);
                
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                float4 textureSample = tex2D(_BaseTex, i.uv);
                return textureSample * _BaseColor;
            }
            ENDHLSL
        }
    }
}
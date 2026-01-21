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
                float3 positionOS : TEXCOORD2;
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
                o.positionOS = v.positionOS;
                
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                float2 xAxisUV = i.positionOS.zy * _Tile;
                float2 yAxisUV = i.positionOS.xz * _Tile;
                float2 zAxisUV = i.positionOS.xy * _Tile;
                float4 xSample = tex2D(_BaseTex, xAxisUV);
                float4 ySample = tex2D(_BaseTex, yAxisUV);
                float4 zSample = tex2D(_BaseTex, zAxisUV);
                float3 normalAbs = abs(i.normalWS);
                float3 weights = pow(normalAbs, _BlendPower);
                weights /= (weights.x + weights.y + weights.z);
                float4 outColor = xSample * weights.x +
                ySample * weights.y + zSample * weights.z;
                return outColor;
            }
            ENDHLSL
        }
    }
}
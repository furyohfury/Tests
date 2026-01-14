Shader "Examples/TextureSample"
{
    Properties
    {
        _BaseColor ("Base Color", Color) = (1,
        1, 1, 1)
        _BaseTex ("Base Texture", 2D) = "white" // {} нужно?
        _Lod ("LOD", Int) = 0
        _SampleTex ("SampleTexture", 2D) = "white"
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
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 positionCS : SV_POSITION;
                float2 uv : TEXCOORD0;
            };
            
            Texture2D _BaseTex;
            Texture2D _SampleTex;
            CBUFFER_START(UnityPerMaterial)
            float4 _BaseTex_ST;
            float4 _SampleTex_ST;
            float4 _BaseColor;
            int _Lod;
            CBUFFER_END
            SamplerState sampler_SampleTex;
    
            v2f vert(appdata v)
            {
                v2f o;
                o.positionCS = TransformObjectToHClip(v.positionOS);
                o.uv = TRANSFORM_TEX(v.uv, _BaseTex);
                
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                float4 textureSample = SAMPLE_TEXTURE2D(_SampleTex, sampler_SampleTex, i.uv);
                
                return textureSample * _BaseColor;
            }
            ENDHLSL
        }
    }
}
Shader "Examples/FlatShading"
{
    Properties
    {
        _BaseColor ("Base Color", Color) = (1, 1, 1, 1)
         _BaseTex("Base Texture", 2D) = "white" {}
        _AmbientMultiplier("AmbientMultiplier", Float) = 1
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
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

            struct appdata
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
                float3 normalOS : NORMAL;
            };

            struct v2f
            {
                float4 positionCS : SV_POSITION;
                float2 uv : TEXCOORD0;
                nointerpolation  float4 flatLight : TEXCOORD1;
            };

            sampler2D _BaseTex;
            CBUFFER_START(UnityPerMaterial)
                float4 _BaseColor;
                float4 _BaseTex_ST;
            float _AmbientMultiplier;
            CBUFFER_END


            v2f vert(appdata v)
            {
                v2f o;
                o.positionCS = TransformObjectToHClip(v.positionOS.xyz);
                o.uv = TRANSFORM_TEX(v.uv, _BaseTex);
                float3 normalWS = TransformObjectToWorld(v.normalOS);
                float3 ambient = SampleSHVertex(normalWS);
                Light light = GetMainLight();
                half3 lightColor = light.color;
                half3 lightDir = light.direction;
                float3 diffuse = lightColor * max(0, dot(normalWS, lightDir));
                o.flatLight = float4(ambient * _AmbientMultiplier + diffuse, 1.0f);

                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                float4 textureSample = tex2D(_BaseTex, i.uv);
                return textureSample * _BaseColor * i.flatLight;
            }
            ENDHLSL
        }
    }
}
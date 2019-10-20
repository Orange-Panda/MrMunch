Shader "Unlit/Planet"
{
    Properties
    {
        _Noise1 ("Primary Noise Texture", 2D) = "white" {}
        _Noise2 ("Secondary Noise Texture", 2D) = "white" {}

		_Threshold ("Threshold Cutoff", float) = 1
		_StepAA ("Step Anti-Aliasing", float) = 0.01

		_Displacement ("Displacement Amount", float) = 1

		_BaseColor ("Base Color", Color) = (0.0, 0.0, 0.0, 1.0)
		_RaisedColor ("Raised Color", Color) = (1.0, 1.0, 1.0, 1.0)
    }
    SubShader
    {
        Tags { "RenderType" = "Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma tessellate:tessFixed
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"
			#include "Tessellation.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
				float3 normal : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _Noise1;
            sampler2D _Noise2;
            float4 _Noise1_ST;
            float4 _Noise2_ST;

			fixed _Threshold;
			fixed _Displacement;
			float _StepAA;

			fixed4 _BaseColor;
			fixed4 _RaisedColor;

			float smoothThreshold(float inputSample, float cutoff, float aa)
			{
				return smoothstep(
					cutoff - aa,
					cutoff + aa,
					inputSample
				);
			}

            v2f vert (appdata v)
            {
                v2f o;

				float4 noise1 = tex2Dlod(_Noise1, float4(v.uv.xy, 0, 0));
				float4 noise2 = tex2Dlod(_Noise2, float4(v.uv.xy, 0, 0));

				fixed noise = max(noise1.r, noise2.r);

				v.vertex.xyz += v.normal * _Displacement * noise;
				//v.vertex.x += sin(_Time.y * _Speed + v.vertex.y * _Amount) * _Distance;

				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _Noise1);

                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_Noise1, i.uv);
                fixed4 col2 = tex2D(_Noise2, i.uv);
				
				fixed noise = max(col.r, col2.r);

				noise = smoothThreshold(noise, _Threshold, _StepAA);

				fixed4 c = lerp(_BaseColor, _RaisedColor, noise);
				
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return c;
            }
            ENDCG
        }
    }
}

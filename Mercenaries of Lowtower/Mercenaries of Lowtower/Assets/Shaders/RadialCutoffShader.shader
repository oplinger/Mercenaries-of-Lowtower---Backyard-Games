// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/RadialCutoffShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	_SecondaryTex("Secondary Texture", 2D) = "white" {}
	_TransitionTex("Transition Texture", 2D) = "white"{}
	_Cutoff("Cutoff", Range(0, 1.1)) = 0
		_Color("Screen Color", Color) = (1,1,1,1)

	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _TransitionTex;
			sampler2D _SecondaryTex;

			sampler2D _MainTex;
			float4 _MainTex_ST;

			float _Cutoff;
			fixed4 _Color;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}

			v2f simplevert(appdata v) {

				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;

			}

			//fixed4 simplefrag(v2f i) : SV_Target
			//{
			//	if (i.uv.x < _Cutoff)
			//		return _Color;
			
			//return tex2D(_MainTex, i.uv);
			//}

			fixed4 simpleTexture(v2f i) : SV_Target
			{
				fixed4 transit = tex2D(_TransitionTex, i.uv);

			if (transit.b < _Cutoff)
				return _Color;

			return tex2D(_MainTex, i.uv);
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 transit = tex2D(_TransitionTex, i.uv);

			fixed2 direction = float2(0,0);
			

			fixed4 col = tex2D(_MainTex, i.uv + _Cutoff * direction);

			if (transit.b < _Cutoff)
				return col = lerp(col, _Color, .9);

			return col;
			}
			ENDCG
		}
	}
}

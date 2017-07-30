Shader "Custom/FlattenMesh" {
	Properties {
		_Color ("Color", Color) = (1.0, 1.0, 1.0, 1.0)
	}

	SubShader {
			Pass {
				CGPROGRAM

				#pragma vertex vert
				#pragma fragment frag
				uniform float4 _Color;
				float4 vert(float4 v:POSITION) : SV_POSITION {
					return UnityObjectToClipPos (v);
				}

				fixed4 frag() : COLOR {
					return _Color;
				}

				ENDCG
			}
		}
	FallBack "Diffuse"
}

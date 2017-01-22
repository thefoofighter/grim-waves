Shader "Custom/WaterWavesCg" {

	// Grab Properties
	Properties{
		_Displacement("Displacement Strength", Range(0, 1.0)) = 0.3
		_Color("Water Color", COLOR) = (1, 1, 1, 0.5)
		_NormalMap("First Normal Map", 2D) = "black" {}
		_NormalMap2("Second Normal Map", 2D) = "black" {}
		_FlowMap("Water Flow Map", 2D) = "black" {}
		_NoiseMap("Displacement Map", 2D) = "black" {}
		_CubeMap("Reflection Cubemap", Cube) = "white" { TexGen CubeReflect }
		_Cycle("Rotation", float) = 1.0
		_Speed("Speed", float) = 0.05
		_RippleSpeed("Ripple Speed", float) = 0.05
		_Scale("Scale", float) = 1
		_Frequency("Frequency", float) = 1
		_SpecColor("Specular Color", Color) = (0.5,0.5,0.5,1)
		_Shininess("Shininess", Range(0.01, 4)) = 0.078125
		_ReflectColor("Reflection Color", Color) = (1,1,1,0.5)
		[HideInInspector]_WaveAmplitude1 ("WaveAmplitude1", float) = 0
		[HideInInspector]_WaveAmplitude2 ("WaveAmplitude1", float) = 0
		[HideInInspector]_WaveAmplitude3 ("WaveAmplitude1", float) = 0
		[HideInInspector]_WaveAmplitude4 ("WaveAmplitude1", float) = 0
		[HideInInspector]_WaveAmplitude5 ("WaveAmplitude1", float) = 0
		[HideInInspector]_WaveAmplitude6 ("WaveAmplitude1", float) = 0
		[HideInInspector]_WaveAmplitude7 ("WaveAmplitude1", float) = 0
		[HideInInspector]_WaveAmplitude8 ("WaveAmplitude1", float) = 0
		[HideInInspector]_xImpact1 ("x Impact 1", float) = 0
		[HideInInspector]_zImpact1 ("z Impact 1", float) = 0
		[HideInInspector]_xImpact2 ("x Impact 2", float) = 0
		[HideInInspector]_zImpact2 ("z Impact 2", float) = 0
		[HideInInspector]_xImpact3 ("x Impact 3", float) = 0
		[HideInInspector]_zImpact3 ("z Impact 3", float) = 0
		[HideInInspector]_xImpact4 ("x Impact 4", float) = 0
		[HideInInspector]_zImpact4 ("z Impact 4", float) = 0
		[HideInInspector]_xImpact5 ("x Impact 5", float) = 0
		[HideInInspector]_zImpact5 ("z Impact 5", float) = 0
		[HideInInspector]_xImpact6 ("x Impact 6", float) = 0
		[HideInInspector]_zImpact6 ("z Impact 6", float) = 0
		[HideInInspector]_xImpact7 ("x Impact 7", float) = 0
		[HideInInspector]_zImpact7 ("z Impact 7", float) = 0
		[HideInInspector]_xImpact8 ("x Impact 8", float) = 0
		[HideInInspector]_zImpact8 ("z Impact 8", float) = 0

		[HideInInspector]_Distance1 ("Distance1", float) = 0
		[HideInInspector]_Distance2 ("Distance2", float) = 0
		[HideInInspector]_Distance3 ("Distance3", float) = 0
		[HideInInspector]_Distance4 ("Distance4", float) = 0
		[HideInInspector]_Distance5 ("Distance5", float) = 0
		[HideInInspector]_Distance6 ("Distance6", float) = 0
		[HideInInspector]_Distance7 ("Distance7", float) = 0
		[HideInInspector]_Distance8 ("Distance8", float) = 0
	}
		SubShader{
		Tags{ "RenderType" = "Transparent" "Queue" = "Transparent" }
		Blend SrcAlpha OneMinusSrcAlpha
		LOD 300

		CGPROGRAM
#pragma surface surf BlinnPhong vertex:vert keepalpha
//#pragma target 5.0

		float4 _Color;
	sampler2D _NormalMap;
	sampler2D _NormalMap2;
	samplerCUBE _CubeMap;
	sampler2D _FlowMap;
	sampler2D _NoiseMap;
	float _Cycle;
	float _Speed;
	float _RippleSpeed;
	float _Scale;
	float _Frequency;
	float _Shininess;
	float4 _ReflectColor;
	float _WaveAmplitude1, _WaveAmplitude2, _WaveAmplitude3, _WaveAmplitude4, _WaveAmplitude5, _WaveAmplitude6, _WaveAmplitude7, _WaveAmplitude8;
	float _OffsetX1, _OffsetZ1, _OffsetX2, _OffsetZ2, _OffsetX3, _OffsetZ3, _OffsetX4, _OffsetZ4, _OffsetX5, _OffsetZ5, _OffsetX6, _OffsetZ6, _OffsetX7, _OffsetZ7, _OffsetX8, _OffsetZ8;
	float _Distance1, _Distance2, _Distance3, _Distance4, _Distance5, _Distance6, _Distance7, _Distance8;
	float _xImpact1, _zImpact1, _xImpact2, _zImpact2, _xImpact3, _zImpact3, _xImpact4, _zImpact4, _xImpact5, _zImpact5, _xImpact6, _zImpact6,
		_xImpact7, _zImpact7, _xImpact8, _zImpact8;

	struct appdata {
		float4 vertex : POSITION;
		float4 tangent : TANGENT;
		float3 normal : NORMAL;
		float2 texcoord : TEXCOORD0;
	};

	float _Displacement;

	struct Input {
		float3 customValue;
		float2 uv_NormalMap;
		float2 uv_FlowMap;
		float3 worldRefl;
		float3 worldNormal;
		float3 viewDir;
		INTERNAL_DATA
	};

	void vert(inout appdata_full v, out Input o)
	{
		UNITY_INITIALIZE_OUTPUT(Input, o);
		half offsetvert = ((v.vertex.x * v.vertex.x) + (v.vertex.z * v.vertex.z));
		half offsetvert2 = v.vertex.x + v.vertex.z;

		half value0 = _Scale * sin(_Time.w * _RippleSpeed * _Frequency + offsetvert2);
		half value1 = _Scale * sin(_Time.w * _RippleSpeed * _Frequency + offsetvert + (v.vertex.x * _OffsetX1) + (v.vertex.z * _OffsetZ1));
		half value2 = _Scale * sin(_Time.w * _RippleSpeed * _Frequency + offsetvert + (v.vertex.x * _OffsetX2) + (v.vertex.z * _OffsetZ2));
		half value3 = _Scale * sin(_Time.w * _RippleSpeed * _Frequency + offsetvert + (v.vertex.x * _OffsetX3) + (v.vertex.z * _OffsetZ3));
		half value4 = _Scale * sin(_Time.w * _RippleSpeed * _Frequency + offsetvert + (v.vertex.x * _OffsetX4) + (v.vertex.z * _OffsetZ4));
		half value5 = _Scale * sin(_Time.w * _RippleSpeed * _Frequency + offsetvert + (v.vertex.x * _OffsetX5) + (v.vertex.z * _OffsetZ5));
		half value6 = _Scale * sin(_Time.w * _RippleSpeed * _Frequency + offsetvert + (v.vertex.x * _OffsetX6) + (v.vertex.z * _OffsetZ6));
		half value7 = _Scale * sin(_Time.w * _RippleSpeed * _Frequency + offsetvert + (v.vertex.x * _OffsetX7) + (v.vertex.z * _OffsetZ7));
		half value8 = _Scale * sin(_Time.w * _RippleSpeed * _Frequency + offsetvert + (v.vertex.x * _OffsetX8) + (v.vertex.z * _OffsetZ8));

		float3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;

		o.customValue += value0;

		// Hack Hack - Fake the displacement movement
		// Would be better to lookup the displacment map and use its data here.
		float2 vTexCoord = v.texcoord.xy + frac(_Time[1] / _Cycle * 0.25f);

		// Standard displacemnt Calc
		float d = tex2Dlod(_NoiseMap, float4(vTexCoord.xy, 0, 0)).r * _Displacement;
		v.vertex.xyz += v.normal * d;

		if (sqrt(pow(worldPos.x - _xImpact1, 2) + pow(worldPos.z - _zImpact1, 2)) < _Distance1)
		{
			v.vertex.y += value1 * _WaveAmplitude1;
			v.normal.y += value1 * _WaveAmplitude1;
			o.customValue += value1 * _WaveAmplitude1;
		}
		if (sqrt(pow(worldPos.x - _xImpact2, 2) + pow(worldPos.z - _zImpact2, 2)) < _Distance2)
		{
			v.vertex.y += value2 * _WaveAmplitude2;
			v.normal.y += value2 * _WaveAmplitude2;
			o.customValue += value2 * _WaveAmplitude2;
		}
		if (sqrt(pow(worldPos.x - _xImpact3, 2) + pow(worldPos.z - _zImpact3, 2)) < _Distance3)
		{
			v.vertex.y += value3 * _WaveAmplitude3;
			v.normal.y += value3 * _WaveAmplitude3;
			o.customValue += value3 * _WaveAmplitude3;
		}
		if (sqrt(pow(worldPos.x - _xImpact4, 2) + pow(worldPos.z - _zImpact4, 2)) < _Distance4)
		{
			v.vertex.y += value4 * _WaveAmplitude4;
			v.normal.y += value4 * _WaveAmplitude4;
			o.customValue += value4 * _WaveAmplitude4;
		}
		if (sqrt(pow(worldPos.x - _xImpact5, 2) + pow(worldPos.z - _zImpact5, 2)) < _Distance5)
		{
			v.vertex.y += value5 * _WaveAmplitude5;
			v.normal.y += value5 * _WaveAmplitude5;
			o.customValue += value5 * _WaveAmplitude5;
		}
		if (sqrt(pow(worldPos.x - _xImpact6, 2) + pow(worldPos.z - _zImpact6, 2)) < _Distance6)
		{
			v.vertex.y += value6 * _WaveAmplitude6;
			v.normal.y += value6 * _WaveAmplitude6;
			o.customValue += value6 * _WaveAmplitude6;
		}
		if (sqrt(pow(worldPos.x - _xImpact7, 2) + pow(worldPos.z - _zImpact7, 2)) < _Distance7)
		{
			v.vertex.y += value7 * _WaveAmplitude7;
			v.normal.y += value7 * _WaveAmplitude7;
			o.customValue += value7 * _WaveAmplitude7;
		}
		if (sqrt(pow(worldPos.x - _xImpact8, 2) + pow(worldPos.z - _zImpact8, 2)) < _Distance8)
		{
			v.vertex.y += value8 * _WaveAmplitude8;
			v.normal.y += value8 * _WaveAmplitude8;
			o.customValue += value8 * _WaveAmplitude8;
		}
	}

	

	void surf(Input IN, inout SurfaceOutput o) {
		float3 flowDir = tex2D(_FlowMap, IN.uv_FlowMap) * 2 - 1;
		flowDir *= _Speed;
		float3 noise = tex2D(_NoiseMap, IN.uv_FlowMap);

		float phase = _Time[1] / _Cycle + noise.r * 0.5f;
		float f = frac(phase);

		half3 n1 = UnpackNormal(tex2D(_NormalMap, IN.uv_NormalMap + flowDir.xy * frac(phase + 0.5f)));
		half3 n2 = UnpackNormal(tex2D(_NormalMap2, IN.uv_NormalMap + flowDir.xy * f));

		if (f > 0.5f)
			f = 2.0f * (1.0f - f);
		else
			f = 2.0f * f;

		o.Normal = lerp(n1, n2, f);
		o.Alpha = _Color.a;
		o.Gloss = 0.5f;
		o.Specular = _Shininess * 0.1f;

		fixed4 reflcol = texCUBE(_CubeMap, WorldReflectionVector(IN, o.Normal));
		o.Albedo = _Color.rgb;
		o.Emission = reflcol.rgb * _ReflectColor.rgb;
	}
	ENDCG
	}
		FallBack "Reflective/Bumped Specular"
}

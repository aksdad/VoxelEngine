Shader "Vertex Color" {
    Properties {
      _MainTex ("Texture", 2D) = "white" {}
      _RimColor ("Rim Color", Color) = (0.26,0.19,0.16,0.0)
      _RimPower ("Rim Power", Range(0.5,8.0)) = 3.0
      _FogColor ("Fog Color", Color) = (0.3, 0.4, 0.7, 1.0)
      _FogStart ("Fog Start", Range (100, 300)) = 200
      _FogEnd ("Fog End", Range (100, 300)) = 300
    }
    SubShader {
      Tags { "RenderType" = "Opaque"}
    	//Cull Off
    	Fog { Mode Off }
      CGPROGRAM
      #pragma surface surf Lambert vertex:vert finalcolor:finalcolor
      samplerCUBE _Skybox;
      struct Input {
          float2 uv_MainTex;
          float3 customColor;
          float3 viewDir;
          float4 pos;
 //         float4 color : COLOR;
//          float2 uv_MainTex;
         // float3 worldPos;
          //float distance;
          //float factor;
          //float2 distFact
      };
      void vert (inout appdata_full v, out Input o) {
          UNITY_INITIALIZE_OUTPUT(Input,o);
          o.customColor = v.color; // Save the vertex color to be used in the fragment stage
          float4 hpos = mul (UNITY_MATRIX_MVP, v.vertex);
          //o.fog = min (2, dot (hpos.xy, hpos.xy) * 0.001);
          o.pos = hpos;
          //float4 vertex = mul(UNITY_MATRIX_MVP, v.vertex);
          //float4 projPos = ComputeScreenPos( vertex );
          //o.distance = projPos.z;
          //o.factor = saturate((o.distance - 200) * 0.001f);
      }
      sampler2D _MainTex;
      float4 _RimColor;
      float _RimPower;
      void surf (Input IN, inout SurfaceOutput o) {
          o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
          o.Albedo *= (IN.customColor * 0.5);
          //half rim = 1.0 - saturate(dot (normalize(IN.viewDir), o.Normal)) + 0.15;
          //float4 c = tex2D( _MainTex, IN.uv_MainTex );
            
            //o.Albedo = lerp( c.rgb, IN.color.rgb, IN.color.a );
           // o.Emission = o.Albedo * lerp( c.a, IN.customColor, 0.5 );
            //o.Alpha = 1;
 
            //if( IN.distance > 200 )
            //{
            //    c = texCUBE( _Skybox, normalize(IN.viewDir) );
            //    o.Albedo = lerp( o.Albedo, c.rgb, saturate((IN.distance - 200) * 0.001f) );
            //    o.Emission = lerp( o.Emission, c.rgb, saturate((IN.distance - 200) * 0.001f) );
            //}
          //o.Emission = IN.customColor.rgb * pow (rim, _RimPower);
      }
      fixed4 _FogColor;
      float _FogStart;
      float _FogEnd;
      void finalcolor (Input IN, SurfaceOutput o, inout fixed4 color)
      {
          fixed3 fogColor = _FogColor.rgb;
          #ifdef UNITY_PASS_FORWARDADD
          fogColor = 0;
          #endif
          if(IN.pos.z > _FogStart){
	          if(IN.pos.z > _FogEnd) color.rgb = fogColor;
	          else color.rgb = lerp (color.rgb, fogColor, (IN.pos.z - _FogStart) / (_FogEnd - _FogStart));
          }
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }
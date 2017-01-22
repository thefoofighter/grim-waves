// Shader created with Shader Forge v1.32 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.32;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:32908,y:32742,varname:node_4013,prsc:2|emission-4372-U;n:type:ShaderForge.SFN_TexCoord,id:4372,x:31834,y:32827,varname:node_4372,prsc:2,uv:0;n:type:ShaderForge.SFN_ComponentMask,id:2611,x:32274,y:32662,varname:node_2611,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-1240-OUT;n:type:ShaderForge.SFN_RemapRange,id:1240,x:32114,y:32662,varname:node_1240,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-4372-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:7593,x:32274,y:32952,ptovrint:False,ptlb:node_7593,ptin:_node_7593,varname:node_7593,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:b6ddb029a8d718c42a25526d3c23776e,ntxv:0,isnm:False;n:type:ShaderForge.SFN_ArcTan2,id:3776,x:32451,y:32683,varname:node_3776,prsc:2,attp:2|A-2611-G,B-2611-R;n:type:ShaderForge.SFN_Append,id:5571,x:32626,y:32683,varname:node_5571,prsc:2|A-3776-OUT,B-3776-OUT;n:type:ShaderForge.SFN_Tex2d,id:7446,x:32661,y:32908,ptovrint:False,ptlb:node_7446,ptin:_node_7446,varname:node_7446,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-5571-OUT;n:type:ShaderForge.SFN_Append,id:9130,x:32463,y:32901,varname:node_9130,prsc:2;proporder:2449;pass:END;sub:END;*/

Shader "Shader Forge/SoulDisintegrate" {
    Properties {
        _node_2449 ("node_2449", 2D) = "white" {}
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float3 emissive = float3(i.uv0.r,i.uv0.r,i.uv0.r);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}

Shader "Custom/NormalMap" {
	Properties {
		_Color ("Diffuse Color", Color) = (1,1,1,1)
		_SpecularColor ("Specular Color", Color) = (1,1,1,1)
		_SpecularExponent ("Specular Exponent", Float) = 10
		_NormalMap ("Normal Map", 2D) = "bump" {}
	}
	SubShader {
		Pass {
			Tags { "LightMode" = "ForwardBase" }
			
			GLSLPROGRAM
	        #include "UnityCG.glslinc"
	        #if !defined _Object2World
	        #define _Object2World unity_ObjectToWorld
	        #endif

	        uniform vec4 _LightColor0;

	        uniform vec4 _Color;
	        uniform vec4 _SpecularColor;
	        uniform float _SpecularExponent;
	        
	        uniform sampler2D _NormalMap;
			uniform vec4 _NormalMap_ST;

	        #ifdef VERTEX
	        out vec4 normalMapCoord;
	        out vec4 glVertexWorld;
	        out mat3 tbn;
	        
	        attribute vec4 Tangent;
	        
	        void main() {	            
	            glVertexWorld = _Object2World * gl_Vertex;

				vec3 n = normalize((_Object2World * vec4(gl_Normal, 0.0)).xyz);
				vec3 t = normalize((_Object2World * vec4(Tangent.xyz, 0.0)).xyz);
				vec3 b = normalize(cross(n, t) * Tangent.w);
				tbn = mat3(t, b, n);

				normalMapCoord = gl_MultiTexCoord0;

	            gl_Position = gl_ModelViewProjectionMatrix * gl_Vertex;
	        }
	        #endif

	        #ifdef FRAGMENT
	        in vec4 normalMapCoord;
	        in vec4 glVertexWorld;
	        in mat3 tbn;

	        vec3 unpackNormalDXT5nm(vec4 packednormal) {
				vec3 normal;
				normal.xy = packednormal.wy * 2.0 - 1.0;
				normal.z = sqrt(1.0 - saturate(dot(normal.xy, normal.xy)));
				return normal;
			}

			vec3 unpackNormal(vec4 packednormal) {
				#if defined(UNITY_NO_DXT5nm)
					return packednormal.xyz * 2.0 - 1.0;
				#else
					return unpackNormalDXT5nm(packednormal);
				#endif
			}

	        void main() {
	            vec4 packedNormal = texture2D(_NormalMap, _NormalMap_ST.xy * normalMapCoord.xy + _NormalMap_ST.zw);            
	            vec3 tangentSpaceVector = unpackNormal(packedNormal);
		        vec3 surfaceNormal = normalize(tbn * tangentSpaceVector);

	        	vec3 ambientLight = gl_LightModel.ambient.xyz * vec3(_Color);
	        
				vec3 lightDirectionNormal = normalize(_WorldSpaceLightPos0.xyz);
	            vec3 diffuseReflection = _LightColor0.xyz * _Color.xyz * max(0.0, dot(surfaceNormal, lightDirectionNormal));

                vec3 viewDirectionNormal = normalize((vec4(_WorldSpaceCameraPos, 1.0) - glVertexWorld).xyz);
				vec3 specularReflection = _LightColor0.xyz * _SpecularColor.xyz
					* pow(max(0.0, dot(reflect(-lightDirectionNormal, surfaceNormal), viewDirectionNormal)), _SpecularExponent);                      
	        
	        	gl_FragColor = vec4(ambientLight + diffuseReflection + specularReflection, 1.0);
	        }
	        #endif

	        ENDGLSL
         }
	} 
	//FallBack "Diffuse"
}

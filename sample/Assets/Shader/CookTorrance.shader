Shader "Custom/CookTorrance" {
	Properties {
		_Color ("Diffuse Color", Color) = (1,1,1,1)
		_Roughness ("Roughness", Float) = 0.5
		_FresnelReflectance ("Fresnel Reflectance", Float) = 0.5
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
	        uniform float _Roughness;
	        uniform float _FresnelReflectance;
	        
	        varying vec4 glVertexWorld;
	        varying vec3 surfaceNormal;

	        #ifdef VERTEX
	        void main() {	            
	            surfaceNormal = normalize((_Object2World * vec4(gl_Normal, 0.0)).xyz);
	            glVertexWorld = _Object2World * gl_Vertex;

	            gl_Position = gl_ModelViewProjectionMatrix * gl_Vertex;
	        }
	        #endif

	        #ifdef FRAGMENT
	        void main() {
	        	vec3 ambientLight = gl_LightModel.ambient.xyz * vec3(_Color);
	        
				vec3 lightDirectionNormal = normalize(_WorldSpaceLightPos0.xyz);
				float NdotL = saturate(dot(surfaceNormal, lightDirectionNormal));

			   	vec3 viewDirectionNormal = normalize((vec4(_WorldSpaceCameraPos, 1.0) - glVertexWorld).xyz);
			   	float NdotV = saturate(dot(surfaceNormal, viewDirectionNormal));

			    vec3 halfVector = normalize(lightDirectionNormal + viewDirectionNormal);
			    float NdotH = saturate(dot(surfaceNormal, halfVector));
			    float VdotH = saturate(dot(viewDirectionNormal, halfVector));

				float roughness = saturate(_Roughness);
			    float alpha = roughness * roughness;
			    float alpha2 = alpha * alpha;
				float t = ((NdotH * NdotH) * (alpha2 - 1.0) + 1.0);
				float PI = 3.1415926535897;
				float D = alpha2 / (PI * t * t);

			    float F0 = saturate(_FresnelReflectance);
			    float F = pow(1.0 - VdotH, 5.0);
			    F *= (1.0 - F0);
			    F += F0;

			    float NH2 = 2.0 * NdotH;
			    float g1 = (NH2 * NdotV) / VdotH;
			    float g2 = (NH2 * NdotL) / VdotH;
			    float G = min(1.0, min(g1, g2));

			    float specularReflection = (D * F * G) / (4.0 * NdotV * NdotL + 0.000001);
				vec3 diffuseReflection = _LightColor0.xyz * _Color.xyz * NdotL;

			    gl_FragColor = vec4(ambientLight + diffuseReflection + specularReflection, 1.0);
	        }
	        #endif

	        ENDGLSL
         }
	} 
	//FallBack "Diffuse"
}

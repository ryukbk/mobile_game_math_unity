Shader "Custom/Diffuse" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
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
	         
	        #ifdef VERTEX
			out vec4 color;

	        void main() {	            
	            vec3 surfaceNormal = normalize(vec3(_Object2World * vec4(gl_Normal, 0.0)));
	            vec3 lightDirectionNormal = normalize(vec3(_WorldSpaceLightPos0));
	            vec3 diffuseReflection = vec3(_LightColor0) * vec3(_Color) * max(0.0, dot(surfaceNormal, lightDirectionNormal));
	            color = vec4(diffuseReflection, 1.0);
	            gl_Position = gl_ModelViewProjectionMatrix * gl_Vertex;
	        }
	        #endif

	        #ifdef FRAGMENT
			in vec4 color;

	        void main() {
	           gl_FragColor = color;
	        }
	        #endif

	        ENDGLSL
         }
	} 
	//FallBack "Diffuse"
}

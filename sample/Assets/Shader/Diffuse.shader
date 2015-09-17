Shader "Custom/Diffuse" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
	}
	SubShader {
		Pass {
			Tags { "LightMode" = "ForwardBase" }
			
			GLSLPROGRAM
	        #include "UnityCG.glslinc"
	        uniform vec4 _LightColor0;

	        uniform vec4 _Color;
	        varying vec4 color;
	         
	        #ifdef VERTEX
	        void main() {	            
	            vec3 surfaceNormal = normalize(vec3(_Object2World * vec4(gl_Normal, 0.0)));
	            vec3 lightDirectionNormal = normalize(vec3(_WorldSpaceLightPos0));
	            vec3 diffuseReflection = vec3(_LightColor0) * vec3(_Color) * max(0.0, dot(surfaceNormal, lightDirectionNormal));
	            color = vec4(diffuseReflection, 1.0);
	            gl_Position = gl_ModelViewProjectionMatrix * gl_Vertex;
	        }
	        #endif

	        #ifdef FRAGMENT
	        void main() {
	           gl_FragColor = color;
	        }
	        #endif

	        ENDGLSL
         }
	} 
	//FallBack "Diffuse"
}

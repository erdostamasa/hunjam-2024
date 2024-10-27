Shader "Legacy Shaders/HomokScrol - Worldspace" {
Properties {
    _Color ("Main Color", Color) = (1,1,1,1)
    _MainTex ("Base (RGB)", 2D) = "white" {}
    _Scale("Texture Scale", Float) = 1.0
    _YOffset("Y Offset", Float) = 0.0 // New property for Y offset
    _YOffsetMultiplier("Y Offset Multiplier", Float) = 1.0
}
SubShader {
    Tags { "RenderType"="Opaque" }
    LOD 200

CGPROGRAM
#pragma surface surf Lambert

sampler2D _MainTex;
fixed4 _Color;
float _Scale;
float _YOffset; // New variable for Y offset
float _YOffsetMultiplier;

struct Input {
    float3 worldNormal;
    float3 worldPos;
};

void surf (Input IN, inout SurfaceOutput o) {
    float2 UV;
    fixed4 c;

    // Apply the Y offset to the world position for UV calculations
    float adjustedY = IN.worldPos.y + (_YOffset * _YOffsetMultiplier); // Offset the Y coordinate

    if (abs(IN.worldNormal.x) > 0.5) {
        UV = float2(adjustedY, IN.worldPos.z); // side
        c = tex2D(_MainTex, UV * _Scale); // use WALLSIDE texture
    }
    else if (abs(IN.worldNormal.z) > 0.5) {
        UV = float2(IN.worldPos.x, adjustedY); // front
        c = tex2D(_MainTex, UV * _Scale); // use WALL texture
    }
    else {
        UV = float2(IN.worldPos.x, adjustedY); // top
        c = tex2D(_MainTex, UV * _Scale); // use FLR texture
    }

    o.Albedo = c.rgb * _Color;
}
ENDCG
}

Fallback "Legacy Shaders/VertexLit"
}

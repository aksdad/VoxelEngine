using UnityEngine;
using System.Collections.Generic;
public class MeshData{
	public List<Vector3> vertices = new List<Vector3>();
	public List<int> triangles = new List<int>();
	public List<Color> colors = new List<Color>();

	public MeshData(){ }

	public void AddCube(Vector3 pos, Color color){
		int vertexIndex = vertices.Count;
		vertices.AddRange(new Vector3[] {
	        new Vector3(0 + pos.x, 0 + pos.y, 1 + pos.z),
	        new Vector3(1 + pos.x, 0 + pos.y, 1 + pos.z),
	        new Vector3(0 + pos.x, 1 + pos.y, 1 + pos.z),
	        new Vector3(1 + pos.x, 1 + pos.y, 1 + pos.z),
	        new Vector3(1 + pos.x, 0 + pos.y, 0 + pos.z),
	        new Vector3(1 + pos.x, 1 + pos.y, 0 + pos.z),
	        new Vector3(0 + pos.x, 1 + pos.y, 0 + pos.z),
	        new Vector3(0 + pos.x, 0 + pos.y, 0 + pos.z)
	    });

		triangles.AddRange(new int[] { 
	        0 + vertexIndex, 1 + vertexIndex, 2 + vertexIndex, 1 + vertexIndex, 3 + vertexIndex, 2 + vertexIndex,
	        1 + vertexIndex, 4 + vertexIndex, 3 + vertexIndex, 4 + vertexIndex, 5 + vertexIndex, 3 + vertexIndex,
	        4 + vertexIndex, 7 + vertexIndex, 5 + vertexIndex, 7 + vertexIndex, 6 + vertexIndex, 5 + vertexIndex,
	        7 + vertexIndex, 0 + vertexIndex, 6 + vertexIndex, 0 + vertexIndex, 2 + vertexIndex, 6 + vertexIndex,
	        7 + vertexIndex, 4 + vertexIndex, 0 + vertexIndex, 4 + vertexIndex, 1 + vertexIndex, 0 + vertexIndex,
	        2 + vertexIndex, 3 + vertexIndex, 6 + vertexIndex, 3 + vertexIndex, 5 + vertexIndex, 6 + vertexIndex
	    });

	    colors.AddRange(new Color[]{
	    		color, color, color, color, color, color, color, color
	    	});
	}

	public void CreateFace(Vector3 pos, Vector3 v1, Vector3 v2, Vector3 v3, Vector3 v4, Color[] color, bool flipped = false){
		int vertexIndex = vertices.Count;
		
        vertices.Add( pos + v1);
        vertices.Add( pos + v2);
        vertices.Add( pos + v3);
        vertices.Add( pos + v4);

        // Create the triangles using the winding order to avoid calculate the normals
		
		if(flipped){
			// first triangle 
			triangles.Add(vertexIndex);
	        triangles.Add(vertexIndex+1);
	        triangles.Add(vertexIndex+3);
	         
	        // second triangle 
	        triangles.Add(vertexIndex+3);
	        triangles.Add(vertexIndex+1);
	        triangles.Add(vertexIndex+2);
		}else{
			// first triangle 
			triangles.Add(vertexIndex);
	        triangles.Add(vertexIndex+1);
	        triangles.Add(vertexIndex+2);
	         
	        // second triangle 
	        triangles.Add(vertexIndex+2);
	        triangles.Add(vertexIndex+3);
	        triangles.Add(vertexIndex);
	       	
		}
        colors.AddRange(color);
		// Light
		// byte c1Byte = (byte)c1;
		// byte c2Byte = (byte)c2;
		// byte c3Byte = (byte)c3;
		// byte c4Byte = (byte)c4;
		
		// _colors.Add ( new Color32(c1Byte, c1Byte, c1Byte, 0) );
		// _colors.Add ( new Color32(c2Byte, c2Byte, c2Byte, 0) );
		// _colors.Add ( new Color32(c3Byte, c3Byte, c3Byte, 0) );
		// _colors.Add ( new Color32(c4Byte, c4Byte, c4Byte, 0) );
		
		// // UV
		// float _uvsize = 0.25f;
		// _uvs.Add(new Vector2(texUV.x, texUV.y));
		// _uvs.Add(new Vector2(texUV.x, texUV.y+_uvsize));
		// _uvs.Add(new Vector2(texUV.x+_uvsize, texUV.y+_uvsize));
		// _uvs.Add(new Vector2(texUV.x+_uvsize, texUV.y));
	}
}
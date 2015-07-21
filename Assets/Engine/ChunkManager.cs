using UnityEngine;
using System.Threading;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;

public class ChunkManager : MonoBehaviour{
	World world;
	Vector3 gridPos;	
	Chunk[,] cameraChunks;
	Camera cam;
	bool startDebug = false;
    private Plane[] planes;
    FirstPersonController cont;
	void Start(){
		world = World.instance;
		gridPos = Vector3.zero;
		cameraChunks = new Chunk[21, 21];
		cam = gameObject.GetComponent<Camera>();
		planes = GeometryUtility.CalculateFrustumPlanes(cam);
		startDebug = true;
		// cont = transform.parent.GetComponent<FirstPersonController>();
		// cont.changeGrav(0f);
		// Plane[] planes = GeometryUtility.CalculateFrustumPlanes(cam);
	}

	void Update(){
		UpdateGrid();
	}

	void UpdateGrid(){
		bool flag = true;
		// first check that we are in the middle
		int side = (int)Mathf.Sqrt(((float)cameraChunks.Length + 0));
		int center = (int)Mathf.Round(((float)side + 0) * 0.5f);
		 
		// calculate if we've moved off the center of the grid
		int dx = (int)Mathf.Floor((transform.position.x - gridPos.x) / 32f);
		int dz = (int)Mathf.Floor((transform.position.z - gridPos.z) / 32f);
		 
		// if we've moved then we need to drop/load chunks
		if (dx != 0 || dz != 0)
		{
		    Chunk[,] temp = new Chunk[side, side];
		 
		    // shift the matrix
		    for (int x = 0; x < side; x++)
		    {
		        if (x + dx >= 0 && x + dx < side)
		        {
		            for (int z = 0; z < side; z++)
		            {
		                if (z + dz >= 0 && z + dz < side)
		                {
		                    temp[x, z] = cameraChunks[x + dx, z + dz];
		                    cameraChunks[x + dx, z + dz] = null;
		                }
		            }
		        }
		    }
		 
		    // figure out which voxel chunks can be destroyed
		    for (int x = 0; x < side; x++)
		    {
		        for (int z = 0; z < side; z++)
		        {
		            if (cameraChunks[x, z] != null)
		            {
		                world.DestroyChunk(cameraChunks[x, z]);
		                // cameraChunks[x, z].Dispose();
		            }
		        }
		    }
		 
		    cameraChunks = temp;
		    gridPos = new Vector3(gridPos.x + 32f * dx, gridPos.y, gridPos.z + 32f * dz);
		}
		Plane[] planes = GeometryUtility.CalculateFrustumPlanes(cam);
		for (int x = 0; x < side && flag; x++)
		{
		    for (int z = 0; z < side && flag; z++)
		    {
		        if (cameraChunks[x, z] != null) continue;
		 		Vector3 nPos = new Vector3(gridPos.x/32f + x - center, 0, gridPos.z/32f + z - center);
		        // Vector3 chunkPosition = new Vector3(gridPos.x + x * 32 - center * 32, gridPos.y, gridPos.z + z * 32 - center * 32);
		        // if (frustum.Intersects(new AxisAlignedBoundingBox(chunkPosition, ))) 
		        Bounds b = new Bounds(new Vector3(nPos.x*32f + 16f, 0, nPos.z*32f + 16f), new Vector3(32f,32f,32f));
		        // Debug.Log(b);
		        if(GeometryUtility.TestPlanesAABB(planes, b)){
		        	// Debug.Log("hallehujah");
		        	for(int y = 0; y <= 1; y++){
		        		Vector3 chunkPos = nPos + new Vector3(0, y, 0);
		        		// Debug.Log("Creating " + chunkPos);
		        		world.CreateChunk(chunkPos);
		        	}
		        	cameraChunks[x, z] = world.chunks[nPos];
		        	flag = false;
		        }
		        	
		    }
		}
	}
}
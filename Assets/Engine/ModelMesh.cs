using UnityEngine;
using System.Collections;

public class ModelChunk : MonoBehaviour {
    public const int Size = 32;

    MeshData meshData = new MeshData();
    MeshFilter filter;
    MeshCollider coll;

    public bool delete = false;

    public mBlock[,,] blocks = new mBlock[Size, Size, Size];

	// Use this for initialization
	void Start () {
        filter = gameObject.GetComponent<MeshFilter>();
        coll = gameObject.GetComponent<MeshCollider>();
	}
	
	// Update is called once per frame
	void Update () {
        if (delete) {
            Destroy(filter.sharedMesh);
            Destroy(gameObject);
        }
	}

    public mBlock GetBlock(float x, float y, float z){
        if (x >= Size || y >= Size || z >= Size || x < 0 || y < 0 || z < 0)
            return new mBlock(false);
        mBlock block = blocks[(int)x, (int)y, (int)z];
        return block;
    }

    public Color GetBlockColor(float x, float y, float z) {
        mBlock b = GetBlock(x, y, z);
        if (b.solid) {
            return new Color(b.r, b.g, b.b);
        }

        return Color.white;
    }

    private float vertexAO(int side1, int side2, int corner)
    {
        int r = 0;
        if (side1 == 1 && side2 == 1){
            r = 0;
        }else{
            r = 3 - (side1 + side2 + corner);
        }
        switch (r){
            case 0:
                return 0.7f;
            case 1:
                return 0.8f;
            case 2:
                return 0.85f;
            case 3:
                return 1f;
            default:
                return 1f;
        }
    }

    public void BuildMeshData() {
        for (int x = 0; x < Size; x++) {
            for (int y = 0; y < Size; y++) {
                for (int z = 0; z < Size; z++) {
                    int block = GetBlock(x, y, z);
                    if (block != 0) {
						int top = GetBlock(x, y + 1, z);
						int bot = GetBlock(x, y - 1, z);
						int front = GetBlock(x, y, z + 1);
						int back = GetBlock(x, y, z - 1);
						int left = GetBlock(x + 1, y, z);
						int right = GetBlock(x - 1, y, z);
						Color color = GetBlockColor(x, y, z);
						int side1;
						int side2;
						int corner;
						float ao1;
						float ao2;
						float ao3;
						float ao4;
						Vector3 vPos = new Vector3(x, y, z);
						Color[] colors;
						if (top == 0) {
							colors = new Color[4];
							if (GetBlock(x - 1, y + 1, z) != 0) {
								side1 = 1;
							} else {
								side1 = 0;
							}
							if (GetBlock(x, y + 1, z - 1) != 0) {
								side2 = 1;
							} else {
								side2 = 0;
							}
							if (GetBlock(x - 1, y + 1, z - 1) != 0) {
								corner = 1;
							} else {
								corner = 0;
							}
							ao1 = vertexAO(side1, side2, corner);
							colors[0] = new Color(color.r * ao1, color.g * ao1, color.b * ao1, color.a);

							if (GetBlock(x - 1, y + 1, z) != 0) {
								side1 = 1;
							} else {
								side1 = 0;
							}
							if (GetBlock(x, y + 1, z + 1) != 0) {
								side2 = 1;
							} else {
								side2 = 0;
							}
							if (GetBlock(x - 1, y + 1, z + 1) != 0) {
								corner = 1;
							} else {
								corner = 0;
							}
							ao2 = vertexAO(side1, side2, corner);
							colors[1] = new Color(color.r * ao2, color.g * ao2, color.b * ao2, color.a);

							if (GetBlock(x + 1, y + 1, z) != 0) {
								side1 = 1;
							} else {
								side1 = 0;
							}
							if (GetBlock(x, y + 1, z + 1) != 0) {
								side2 = 1;
							} else {
								side2 = 0;
							}
							if (GetBlock(x + 1, y + 1, z + 1) != 0) {
								corner = 1;
							} else {
								corner = 0;
							}
							ao3 = vertexAO(side1, side2, corner);
							colors[2] = new Color(color.r * ao3, color.g * ao3, color.b * ao3, color.a);

							if (GetBlock(x + 1, y + 1, z) != 0) {
								side1 = 1;
							} else {
								side1 = 0;
							}
							if (GetBlock(x, y + 1, z - 1) != 0) {
								side2 = 1;
							} else {
								side2 = 0;
							}
							if (GetBlock(x + 1, y + 1, z - 1) != 0) {
								corner = 1;
							} else {
								corner = 0;
							}
							ao4 = vertexAO(side1, side2, corner);
							colors[3] = new Color(color.r * ao4, color.g * ao4, color.b * ao4, color.a);

							if (ao1 + ao3 < ao2 + ao4) {
								meshData.CreateFace(vPos, new Vector3(0, 1, 0), new Vector3(0, 1, 1), new Vector3(1, 1, 1), new Vector3(1, 1, 0), colors, true);
							} else meshData.CreateFace(vPos, new Vector3(0, 1, 0), new Vector3(0, 1, 1), new Vector3(1, 1, 1), new Vector3(1, 1, 0), colors, false);
						}
						if (front == 0) {
							colors = new Color[4];
							if (GetBlock(x - 1, y, z + 1) != 0) {
								side1 = 1;
							} else {
								side1 = 0;
							}
							if (GetBlock(x, y - 1, z + 1) != 0) {
								side2 = 1;
							} else {
								side2 = 0;
							}
							if (GetBlock(x - 1, y - 1, z + 1) != 0) {
								corner = 1;
							} else {
								corner = 0;
							}
							ao1 = vertexAO(side1, side2, corner);
							colors[0] = new Color(color.r * ao1, color.g * ao1, color.b * ao1, color.a);

							if (GetBlock(x, y - 1, z + 1) != 0) {
								side1 = 1;
							} else {
								side1 = 0;
							}
							if (GetBlock(x + 1, y, z + 1) != 0) {
								side2 = 1;
							} else {
								side2 = 0;
							}
							if (GetBlock(x + 1, y - 1, z + 1) != 0) {
								corner = 1;
							} else {
								corner = 0;
							}
							ao2 = vertexAO(side1, side2, corner);
							colors[1] = new Color(color.r * ao2, color.g * ao2, color.b * ao2, color.a);

							if (GetBlock(x, y + 1, z + 1) != 0) {
								side1 = 1;
							} else {
								side1 = 0;
							}
							if (GetBlock(x + 1, y + 1, z + 1) != 0) {
								side2 = 1;
							} else {
								side2 = 0;
							}
							if (GetBlock(x + 1, y + 1, z + 1) != 0) {
								corner = 1;
							} else {
								corner = 0;
							}
							ao3 = vertexAO(side1, side2, corner);
							colors[2] = new Color(color.r * ao3, color.g * ao3, color.b * ao3, color.a);

							if (GetBlock(x, y + 1, z + 1) != 0) {
								side1 = 1;
							} else {
								side1 = 0;
							}
							if (GetBlock(x - 1, y, z + 1) != 0) {
								side2 = 1;
							} else {
								side2 = 0;
							}
							if (GetBlock(x - 1, y + 1, z + 1) != 0) {
								corner = 1;
							} else {
								corner = 0;
							}
							ao4 = vertexAO(side1, side2, corner);
							colors[3] = new Color(color.r * ao4, color.g * ao4, color.b * ao4, color.a);
							if (ao1 + ao3 < ao2 + ao4) {
								meshData.CreateFace(vPos, new Vector3(0, 0, 1), new Vector3(1, 0, 1), new Vector3(1, 1, 1), new Vector3(0, 1, 1), colors, true);
							} else {
								meshData.CreateFace(vPos, new Vector3(0, 0, 1), new Vector3(1, 0, 1), new Vector3(1, 1, 1), new Vector3(0, 1, 1), colors, false);
							}
						}

						if (left == 0) {
							colors = new Color[4];
							if (GetBlock(x + 1, y, z - 1) != 0) {
								side1 = 1;
							} else {
								side1 = 0;
							}
							if (GetBlock(x + 1, y - 1, z) != 0) {
								side2 = 1;
							} else {
								side2 = 0;
							}
							if (GetBlock(x + 1, y - 1, z - 1) != 0) {
								corner = 1;
							} else {
								corner = 0;
							}
							ao1 = vertexAO(side1, side2, corner);
							colors[0] = new Color(color.r * ao1, color.g * ao1, color.b * ao1, color.a);

							if (GetBlock(x + 1, y + 1, z) != 0) {
								side1 = 1;
							} else {
								side1 = 0;
							}
							if (GetBlock(x + 1, y, z - 1) != 0) {
								side2 = 1;
							} else {
								side2 = 0;
							}
							if (GetBlock(x + 1, y + 1, z - 1) != 0) {
								corner = 1;
							} else {
								corner = 0;
							}
							ao2 = vertexAO(side1, side2, corner);
							colors[1] = new Color(color.r * ao2, color.g * ao2, color.b * ao2, color.a);

							if (GetBlock(x + 1, y + 1, z) != 0) {
								side1 = 1;
							} else {
								side1 = 0;
							}
							if (GetBlock(x + 1, y, z + 1) != 0) {
								side2 = 1;
							} else {
								side2 = 0;
							}
							if (GetBlock(x + 1, y + 1, z + 1) != 0) {
								corner = 1;
							} else {
								corner = 0;
							}
							ao3 = vertexAO(side1, side2, corner);
							colors[2] = new Color(color.r * ao3, color.g * ao3, color.b * ao3, color.a);

							if (GetBlock(x + 1, y, z + 1) != 0) {
								side1 = 1;
							} else {
								side1 = 0;
							}
							if (GetBlock(x + 1, y - 1, z) != 0) {
								side2 = 1;
							} else {
								side2 = 0;
							}
							if (GetBlock(x + 1, y - 1, z + 1) != 0) {
								corner = 1;
							} else {
								corner = 0;
							}
							ao4 = vertexAO(side1, side2, corner);
							colors[3] = new Color(color.r * ao4, color.g * ao4, color.b * ao4, color.a);
							if (ao1 + ao3 < ao2 + ao4) {
								meshData.CreateFace(vPos, new Vector3(1, 0, 0), new Vector3(1, 1, 0), new Vector3(1, 1, 1), new Vector3(1, 0, 1), colors, true);
							} else {
								meshData.CreateFace(vPos, new Vector3(1, 0, 0), new Vector3(1, 1, 0), new Vector3(1, 1, 1), new Vector3(1, 0, 1), colors, false);
							}
						}

						if (back == 0) {
							colors = new Color[4];
							if (GetBlock(x - 1, y, z - 1) != 0) {
								side1 = 1;
							} else {
								side1 = 0;
							}
							if (GetBlock(x, y - 1, z - 1) != 0) {
								side2 = 1;
							} else {
								side2 = 0;
							}
							if (GetBlock(x - 1, y - 1, z - 1) != 0) {
								corner = 1;
							} else {
								corner = 0;
							}
							ao1 = vertexAO(side1, side2, corner);
							colors[0] = new Color(color.r * ao1, color.g * ao1, color.b * ao1, color.a);

							if (GetBlock(x - 1, y, z - 1) != 0) {
								side1 = 1;
							} else {
								side1 = 0;
							}
							if (GetBlock(x, y + 1, z - 1) != 0) {
								side2 = 1;
							} else {
								side2 = 0;
							}
							if (GetBlock(x - 1, y + 1, z - 1) != 0) {
								corner = 1;
							} else {
								corner = 0;
							}
							ao2 = vertexAO(side1, side2, corner);
							colors[1] = new Color(color.r * ao2, color.g * ao2, color.b * ao2, color.a);

							if (GetBlock(x, y + 1, z - 1) != 0) {
								side1 = 1;
							} else {
								side1 = 0;
							}
							if (GetBlock(x + 1, y, z - 1) != 0) {
								side2 = 1;
							} else {
								side2 = 0;
							}
							if (GetBlock(x + 1, y + 1, z - 1) != 0) {
								corner = 1;
							} else {
								corner = 0;
							}
							ao3 = vertexAO(side1, side2, corner);
							colors[2] = new Color(color.r * ao3, color.g * ao3, color.b * ao3, color.a);
							if (GetBlock(x + 1, y, z - 1) != 0) {
								side1 = 1;
							} else {
								side1 = 0;
							}
							if (GetBlock(x, y - 1, z - 1) != 0) {
								side2 = 1;
							} else {
								side2 = 0;
							}
							if (GetBlock(x + 1, y - 1, z - 1) != 0) {
								corner = 1;
							} else {
								corner = 0;
							}
							ao4 = vertexAO(side1, side2, corner);

							colors[3] = new Color(color.r * ao4, color.g * ao4, color.b * ao4, color.a);
							if (ao1 + ao3 > ao2 + ao4) {
								meshData.CreateFace(vPos, new Vector3(0, 0, 0), new Vector3(0, 1, 0), new Vector3(1, 1, 0), new Vector3(1, 0, 0), colors, true);
							} else {
								meshData.CreateFace(vPos, new Vector3(0, 0, 0), new Vector3(0, 1, 0), new Vector3(1, 1, 0), new Vector3(1, 0, 0), colors, false);
							}
						}

						colors = new Color[4] {
							color, color, color, color
						};
						if (right == 0) {
							colors = new Color[4];
							if (GetBlock(x - 1, y, z + 1) != 0) {
								side1 = 1;
							} else {
								side1 = 0;
							}
							if (GetBlock(x - 1, y - 1, z) != 0) {
								side2 = 1;
							} else {
								side2 = 0;
							}
							if (GetBlock(x - 1, y - 1, z + 1) != 0) {
								corner = 1;
							} else {
								corner = 0;
							}
							ao1 = vertexAO(side1, side2, corner);
							colors[0] = new Color(color.r * ao1, color.g * ao1, color.b * ao1, color.a);

							if (GetBlock(x - 1, y + 1, z) != 0) {
								side1 = 1;
							} else {
								side1 = 0;
							}
							if (GetBlock(x - 1, y, z + 1) != 0) {
								side2 = 1;
							} else {
								side2 = 0;
							}
							if (GetBlock(x - 1, y + 1, z + 1) != 0) {
								corner = 1;
							} else {
								corner = 0;
							}
							ao2 = vertexAO(side1, side2, corner);
							colors[1] = new Color(color.r * ao2, color.g * ao2, color.b * ao2, color.a);

							if (GetBlock(x - 1, y + 1, z) != 0) {
								side1 = 1;
							} else {
								side1 = 0;
							}
							if (GetBlock(x - 1, y, z - 1) != 0) {
								side2 = 1;
							} else {
								side2 = 0;
							}
							if (GetBlock(x - 1, y + 1, z - 1) != 0) {
								corner = 1;
							} else {
								corner = 0;
							}
							ao3 = vertexAO(side1, side2, corner);
							colors[2] = new Color(color.r * ao3, color.g * ao3, color.b * ao3, color.a);

							if (GetBlock(x - 1, y, z - 1) != 0) {
								side1 = 1;
							} else {
								side1 = 0;
							}
							if (GetBlock(x - 1, y - 1, z) != 0) {
								side2 = 1;
							} else {
								side2 = 0;
							}
							if (GetBlock(x - 1, y - 1, z - 1) != 0) {
								corner = 1;
							} else {
								corner = 0;
							}
							ao4 = vertexAO(side1, side2, corner);
							colors[3] = new Color(color.r * ao4, color.g * ao4, color.b * ao4, color.a);

							if (ao1 + ao3 < ao2 + ao4) {
								meshData.CreateFace(vPos, new Vector3(0, 0, 1), new Vector3(0, 1, 1), new Vector3(0, 1, 0), new Vector3(0, 0, 0), colors, true);
							} else {
								meshData.CreateFace(vPos, new Vector3(0, 0, 1), new Vector3(0, 1, 1), new Vector3(0, 1, 0), new Vector3(0, 0, 0), colors, false);
							}
						}

						if (bot == 0) {
							colors = new Color[4];
							if (GetBlock(x, y - 1, z - 1) != 0) {
								side1 = 1;
							} else {
								side1 = 0;
							}
							if (GetBlock(x - 1, y - 1, z) != 0) {
								side2 = 1;
							} else {
								side2 = 0;
							}
							if (GetBlock(x - 1, y - 1, z - 1) != 0) {
								corner = 1;
							} else {
								corner = 0;
							}
							ao1 = vertexAO(side1, side2, corner);
							colors[0] = new Color(color.r * ao1, color.g * ao1, color.b * ao1, color.a);

							if (GetBlock(x + 1, y - 1, z) != 0) {
								side1 = 1;
							} else {
								side1 = 0;
							}
							if (GetBlock(x, y - 1, z - 1) != 0) {
								side2 = 1;
							} else {
								side2 = 0;
							}
							if (GetBlock(x + 1, y - 1, z - 1) != 0) {
								corner = 1;
							} else {
								corner = 0;
							}
							ao2 = vertexAO(side1, side2, corner);
							colors[1] = new Color(color.r * ao2, color.g * ao2, color.b * ao2, color.a);

							if (GetBlock(x + 1, y - 1, z) != 0) {
								side1 = 1;
							} else {
								side1 = 0;
							}
							if (GetBlock(x, y - 1, z + 1) != 0) {
								side2 = 1;
							} else {
								side2 = 0;
							}
							if (GetBlock(x + 1, y - 1, z + 1) != 0) {
								corner = 1;
							} else {
								corner = 0;
							}
							ao3 = vertexAO(side1, side2, corner);
							colors[2] = new Color(color.r * ao3, color.g * ao3, color.b * ao3, color.a);

							if (GetBlock(x - 1, y - 1, z) != 0) {
								side1 = 1;
							} else {
								side1 = 0;
							}
							if (GetBlock(x, y - 1, z + 1) != 0) {
								side2 = 1;
							} else {
								side2 = 0;
							}
							if (GetBlock(x - 1, y - 1, z + 1) != 0) {
								corner = 1;
							} else {
								corner = 0;
							}
							ao4 = vertexAO(side1, side2, corner);
							colors[3] = new Color(color.r * ao4, color.g * ao4, color.b * ao4, color.a);
							if (ao1 + ao3 < ao2 + ao4) {
								meshData.CreateFace(vPos, new Vector3(0, 0, 0), new Vector3(1, 0, 0), new Vector3(1, 0, 1), new Vector3(0, 0, 1), colors, true);
							} else {
								meshData.CreateFace(vPos, new Vector3(0, 0, 0), new Vector3(1, 0, 0), new Vector3(1, 0, 1), new Vector3(0, 0, 1), colors, false);
							}
						}
					}
                }
            }
        }
    }
}

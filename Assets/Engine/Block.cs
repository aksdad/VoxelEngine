using System.Collections;
using UnityEngine;
public struct Block {
	public readonly byte type;
	public byte light;

	public Block(int type){
		this.type = (byte)type;
		light = 255;
	}

	public static implicit operator int(Block block){
		return (int)block.type;
	}

	public override string ToString(){
		return ((int)type).ToString();
	}
}

public struct mBlock {
    public readonly byte r;
    public readonly byte g;
    public readonly byte b;
    public bool solid;

    public mBlock(bool solid) {
        this.solid = solid;
        r = b = g = 0;
    }

    public mBlock(Color32 color) {
        this.r = color.r;
        this.g = color.g;
        this.b = color.b;
        solid = true;
    }

    public static implicit operator bool (mBlock block) {
        return block.solid;
    }
}
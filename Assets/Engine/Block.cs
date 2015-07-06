using System.Collections;

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
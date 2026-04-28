class Sound : BlitzType<Sound> {
	public int internalHandle;
	public string name;
	public int[] channels = new int[32];
	public int releaseTime;
}
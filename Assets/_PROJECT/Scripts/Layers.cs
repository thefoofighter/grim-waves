namespace GrimWaves
{
	public static class Layers
	{
		public const int WATER = 4;
		public const int FERRY = 8;
		public const int OBSTACLE = 9;
		public const int TILE = 10;

		/// Mask of all layers that should be affected by water.
		public const int WATER_AFFECTED_MASK = (1 << OBSTACLE) | (1 << FERRY);
	}
}

namespace GraphMagic.GraphMagicUtility
{
	class StartParams
	{
		public StartParams(int? fieldSize, int rectsNum, int mapsNum, string folderPath, ImageModeType imageMode)
		{
            FieldSize = fieldSize;
            RectsNum = rectsNum;
            MapsNum = mapsNum;
            FolderPath = folderPath;
            ImageMode = imageMode;
        }

		public int? FieldSize { get; private set; }

		public int RectsNum { get; private set; }

        public int MapsNum { get; private set; }

        public string FolderPath { get; private set; }

        public ImageModeType ImageMode { get; private set; }

    }
}
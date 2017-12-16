namespace GraphMagic.GraphMagicUtility
{
	class StartParams
	{
		public StartParams(int? fieldSize, int rectsNum, int mapsNum, string folderPath)
		{
            FieldSize = fieldSize;
            RectsNum = rectsNum;
            MapsNum = mapsNum;
            FolderPath = folderPath;
        }

		public int? FieldSize { get; private set; }

		public int RectsNum { get; private set; }

        public int MapsNum { get; private set; }

        public string FolderPath { get; private set; }
    }
}
using System;

namespace GraphMagic.GraphMagicUtility
{
	class StartParamsParser
	{
		public StartParams Parse(string[] args)
		{
            int? fieldSize = null;

            if (IsKeyPassed(args, "s"))
            {
                var fieldSizeParam = GetKeyValue(args, "s");
                if (string.IsNullOrEmpty(fieldSizeParam))
                    throw new ArgumentException("�� ������ �������� ��������� 's' - ����������� �� ������ �����");

                int fieldSizeValue;
                if (!int.TryParse(fieldSizeParam, out fieldSizeValue) || fieldSizeValue <= 0)
                    throw new ArgumentException("�������� �������� ��� ��������� 's' - ����������� �� ������ �����. ��������� ������������� ����� �����");

                fieldSize = fieldSizeValue;
            }

            var rectsNumParam = GetKeyValue(args, "r");
			if (string.IsNullOrEmpty(rectsNumParam))
				throw new ArgumentException("�� ����� ������������ �������� 'r' - ���������� ��������������� �� �����");

			int rectsNum;
			if (!int.TryParse(rectsNumParam, out rectsNum) || rectsNum < 0)
				throw new ArgumentException("�������� �������� ��� ��������� 'r' (���������� ��������������� �� �����). ��������� ��������������� ����� �����");

			var mapsNumParam = GetKeyValue(args, "m");
			if (string.IsNullOrEmpty(mapsNumParam))
				throw new ArgumentException("�� ����� ������������ �������� 'm' - ���������� ���� ��� ���������");

			int mapsNum;
			if (!int.TryParse(mapsNumParam, out mapsNum) || mapsNum <= 0)
				throw new ArgumentException("�������� �������� ��� ��������� 'm' (���������� ���� ��� ���������). ��������� ������������� ����� �����");

            var folderPath = GetKeyValue(args, "f");
            if (string.IsNullOrEmpty(folderPath))
                throw new ArgumentException("�� ����� ������������ �������� 'f' - ���� �� ����� ��� ���������� ����");

            var imageMode = ImageModeType.Real;

            if (IsKeyPassed(args, "i"))
            {
                var imageModeParam = GetKeyValue(args, "i");
                if (string.IsNullOrEmpty(imageModeParam))
                    throw new ArgumentException("�� ������ �������� ��������� 'i' - ������ ����������� ��� ���������� �����");

                if (!Enum.TryParse(imageModeParam, true, out imageMode))
                    throw new ArgumentException("�������� �������� ��� ��������� 'i' - ������ ����������� ��� ���������� �����. ��������� ���� �� ��������: small, large, real");
            }

            return new StartParams(fieldSize, rectsNum, mapsNum, folderPath, imageMode);
		}

		private static string GetKeyValue(string[] args, string key)
		{
			var prefixedKey = $"-{key}";
			var keyIndex = Array.IndexOf(args, prefixedKey);
			if (keyIndex == -1 || keyIndex == args.Length - 1 || args[keyIndex + 1].StartsWith("-"))
				return null;
			return args[keyIndex + 1];
		}

		private static bool IsKeyPassed(string[] args, string key)
		{
			var prefixedKey = $"-{key}";
			var keyIndex = Array.IndexOf(args, prefixedKey);
			return keyIndex >= 0;
		}
	}
}
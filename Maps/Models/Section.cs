namespace GraphMagic.Maps
{
    public class Section
    {
        public int LeftNum { get; private set; }
               
        public int RightNum { get; private set; }

        public Section(int num1, int num2)
        {
            if (num1 < num2)
            {
                LeftNum = num1;
                RightNum = num2;
            }
            else
            {
                LeftNum = num2;
                RightNum = num1;
            }
        }

        public bool Intersects(Section section)
        {
            Section leftSection, rightSection;
            if (LeftNum <= section.LeftNum)
            {
                leftSection = this;
                rightSection = section;
            }
            else
            {
                leftSection = section;
                rightSection = this;
            }

            return rightSection.LeftNum <= leftSection.RightNum;
        }
    }
}
